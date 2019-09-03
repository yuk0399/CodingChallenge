using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmployeeManagement.Controllers
{
    public class EmployeeController: Controller
    {
        private readonly MyContext _context;

        public EmployeeController(MyContext context)
        {
            this._context = context;
        }

        public ActionResult Index(string name, string ageStart, string ageEnd, string managerId, string departmentId)
        {
            var joinedList = (
            from ti in _context.Employee
            from st in _context.Department.Where(j => j.Id == ti.DepartmentId).DefaultIfEmpty()
            from emp in _context.Employee.Where(s => s.Id == ti.ManagerId).DefaultIfEmpty()
            select new Employee { Id = ti.Id, FirstName= ti.FirstName, LastName=ti.LastName, DepartmentId = ti.DepartmentId, DepartmentName = st.DepartmentName, ManagerId = ti.ManagerId, ManagerName = emp.Name, Age = ti.Age, JoiningDate = ti.JoiningDate, Gender = ti.Gender, Salary = ti.Salary }
            );

            if (!string.IsNullOrEmpty(name))
            {
                joinedList = joinedList.Where(s => s.FirstName.Contains(name) || s.LastName.Contains(name));  
            }

            if (!string.IsNullOrEmpty(ageStart) || !string.IsNullOrEmpty(ageEnd))
            {
                int age1 = 0;
                if (ageStart != null) int.TryParse(ageStart, out age1);
                int age2 = 99;
                if (ageEnd != null) int.TryParse(ageEnd, out age2);

                joinedList = joinedList.Where(s => s.Age >= age1 && s.Age <=age2);
            }

            if(!string.IsNullOrEmpty(managerId))
            {
                joinedList = joinedList.Where(s => s.ManagerId == int.Parse(managerId));
            }

            if (!string.IsNullOrEmpty(departmentId))
            {
                joinedList = joinedList.Where(s => s.DepartmentId == int.Parse(departmentId));
            }


            var employeeSearchVM = new EmployeeSearchViewModel()
            {
                Employees = joinedList.ToList(),
                ManagerList = GetManagerSelectList(),
                DepartmentList = GetDepartmentSelectList()
        };

            return View(employeeSearchVM);
        }

        private List<SelectListItem> GetDepartmentSelectList()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var department in _context.Department)
            {
                SelectListItem item = new SelectListItem() { Text = department.DepartmentName, Value = department.Id.ToString() };
                items.Add(item);
            }
            return items;
        }

        private List<SelectListItem> GetManagerSelectList()
        {
            List<SelectListItem> managerItems = new List<SelectListItem>();
            foreach (var emp in _context.Employee)
            {
                SelectListItem item = new SelectListItem() { Text = emp.Name, Value = emp.Id.ToString() };
                managerItems.Add(item);
            }

            return managerItems;
        }

        public ActionResult Create()
        {
            Employee employee = new Employee();
            employee.DepartmentSelectList = GetDepartmentSelectList();
            employee.ManagerSelectList = GetManagerSelectList();

            return View(employee);
        }
        [HttpPost]
        public ActionResult CreateEmployee(Employee employee)
        {
            employee.JoiningDate = DateTime.Now;
            _context.Employee.Add(employee);
            _context.SaveChanges();
            return RedirectToAction("Index", "Employee");
        }

        [HttpPost]
        public bool Delete(int id)
        {
            try
            {
                Employee employee = _context.Employee.Where(s => s.Id == id).First();
                _context.Employee.Remove(employee);
                _context.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }

        }
        public ActionResult Update(int id)
        {
            Employee employee = _context.Employee.Where(s => s.Id == id).First();
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var department in _context.Department)
            {
                SelectListItem item = new SelectListItem() { Text = department.DepartmentName, Value = department.Id.ToString() };
                items.Add(item);
            }
            employee.DepartmentSelectList = items;
            List<SelectListItem> managerItems = new List<SelectListItem>();
            foreach (var emp in _context.Employee.Where(s=> s.Id != employee.Id))
            {
                SelectListItem item = new SelectListItem() { Text = emp.FormattedId + " " + emp.Name, Value = emp.Id.ToString() };
                managerItems.Add(item);
            }
            employee.ManagerSelectList = managerItems;
            return View(employee);
        }

        public ActionResult Detail(int id)
        {
            var query= from ti in _context.Employee.Where(s => s.Id == id)
                                from st in _context.Department.Where(j => j.Id == ti.DepartmentId).DefaultIfEmpty()
                                from emp in _context.Employee.Where(s => s.Id == ti.ManagerId).DefaultIfEmpty()
                       select new Employee { Id = ti.Id, FirstName = ti.FirstName, LastName = ti.LastName, DepartmentName = st.DepartmentName ?? "unknown", ManagerId = ti.ManagerId, ManagerName = emp.Name ?? "unknown", Age = ti.Age, JoiningDate = ti.JoiningDate, Gender = ti.Gender, Salary = ti.Salary ?? 0 };
            Employee employee = query.First();
            EmployeeDetail detail = new EmployeeDetail();
            detail.BaseEmployee = employee;
            var query2 = from ti in _context.Employee.Where(s => s.ManagerId == id)
                                          from st in _context.Department.Where(j => j.Id == ti.DepartmentId).DefaultIfEmpty()
                                          select new Employee { Id = ti.Id, FirstName = ti.FirstName, LastName = ti.LastName, DepartmentName = st.DepartmentName};
            detail.ChildrenEmployeeList = query2.ToList();
            if (employee.ManagerId != null)
                detail.Managers = GetManagers(employee.ManagerId.Value);

            return View(detail);
        }

        private Employee[] GetManagers(int directManagerId)
        {
            List<Employee> list = new List<Employee>();
            GetManagersHierarchicalData(ref list, directManagerId);
            list.Reverse();
            return list.ToArray();
        }

        private void GetManagersHierarchicalData(ref List<Employee> list, int managerId)
        {
            Employee manager = _context.Employee.Where(s => s.Id == managerId).First();
            if (manager is null)
                return;
            else
            {
                list.Add(manager);
                if (manager.ManagerId != null)
                    GetManagersHierarchicalData(ref list, manager.ManagerId.Value);
            }
        }


        [HttpPost]
        public ActionResult UpdateEmployee(Employee employee)
        {

            Employee d = _context.Employee.Where(s => s.Id == employee.Id).First();
            d.FirstName = employee.FirstName;
            d.LastName = employee.LastName;
            d.Gender = employee.Gender;
            d.Age = employee.Age;
            d.Salary = employee.Salary;

            _context.SaveChanges();
            return RedirectToAction("Index", "Employee");

        }

        //public async Task<IActionResult> Index(string sortOrder)
        //{
        //    ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
        //    ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
        //    var employees = from s in _context.Employee
        //                   select s;
        //    switch (sortOrder)
        //    {
        //        case "name_desc":
        //            employees = employees.OrderByDescending(s => s.LastName);
        //            break;
        //        case "Date":
        //            employees = employees.OrderBy(s => s.JoiningDate);
        //            break;
        //        case "date_desc":
        //            employees = employees.OrderByDescending(s => s.JoiningDate);
        //            break;
        //        default:
        //            employees = employees.OrderBy(s => s.LastName);
        //            break;
        //    }
        //    return View(await employees.AsNoTracking().ToListAsync());
        //}
    }
}
