using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmployeeManagement.Models
{
    [Table("Employee")]
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(20)]
        public string LastName { get; set; }

        [Required]
        [Range(1, 100)]
        public int Age { get; set; }
        [Required]
        public int Gender { get; set; }

        [ForeignKey("Department")]
        public int? DepartmentId { get; set; }

        public int? ManagerId { get; set; }

        public int? Salary { get; set; }
        public DateTime JoiningDate { get; set; }

        [NotMapped]
        public string ManagerName { get; set; }

        [NotMapped]
        public string DepartmentName { get; set; }

        [NotMapped]
        public string FormattedId
        {
            get { return this.Id.ToString("#EM000"); }
        }
        [NotMapped]
        public string Name
        {
            get { return this.FirstName + " " + this.LastName; }
        }

        [NotMapped]
        public string GenderValue
        {
            get
            {
                if (this.Gender == 1)
                    return "Male";
                else if (this.Gender == 2)
                    return "Female";
                else
                    return "No Answer";
            }
        }

        [NotMapped]
        public Employee[] Managers { get; set; }

        [NotMapped]
        public List<SelectListItem> DepartmentSelectList { get; set; }

        [NotMapped]
        public List<SelectListItem> GenderSelectList = new List<SelectListItem>() {
            new SelectListItem() { Text = "Male", Value = "1"},
            new SelectListItem() { Text = "Female", Value = "2"},
            new SelectListItem() { Text = "No Answer", Value = "3"},
        };

        [NotMapped]
        public List<SelectListItem> ManagerSelectList { get; set; }
        
    }

    public class EmployeeDetail
    {
        public List<Employee> ChildrenEmployeeList { get; set; }
        public Employee BaseEmployee { get; set; }
        public Employee[] Managers { get; set; }
    }
}