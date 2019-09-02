using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EmployeeManagement.Models;

namespace EmployeeManagement.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly MyContext _context;

        public DepartmentController(MyContext context)
        {
            this._context = context;
        }

        public IActionResult List()
        {
            return View(this._context.Department);
        }

        public ActionResult Index()
        {
            return View(_context.Department.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateDepartment(Department department)
        {

            _context.Department.Add(department);
            _context.SaveChanges();
            return RedirectToAction("Index", "Department");

        }
        [HttpPost]
        public bool Delete(int id)
        {
            try
            {
                Department department = _context.Department.Where(s => s.Id == id).First();
                _context.Department.Remove(department);
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
            return View(_context.Department.Where(s => s.Id == id).First());
            
        }
        [HttpPost]
        public ActionResult UpdateDepartment(Department department)
        {

            Department d = _context.Department.Where(s => s.Id == department.Id).First();
            d.DepartmentName = department.DepartmentName;

            _context.SaveChanges();
            return RedirectToAction("Index", "Department");

        }
    }
}
