using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace EmployeeManagement.Models
{
    public class EmployeeSearchViewModel
    {
        public List<Employee> Employees { get; set; }

        public List<SelectListItem> DepartmentList { get; set; }
        public List<SelectListItem> ManagerList { get; set; }
        public string name { get; set; }
        public string ageStart { get; set; }
        public string ageEnd { get; set; }
        public string departmentId { get; set; }
        public string managerId { get; set; }

        public EmployeeSearchViewModel()
        {
        }
    }
}
