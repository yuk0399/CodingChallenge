using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagement.Models
{
    public class Department
    {
        public int Id { get; set; }
        // public int? ParentId { get; set; }
        [Required]
        [StringLength(50)]
        public string DepartmentName { get; set; }
        // public string DepartmentFullName { get; set; }

        [NotMapped]
        public string DepartmentIdValue
        { get { return this.Id.ToString("#D000"); } }
    }
}
