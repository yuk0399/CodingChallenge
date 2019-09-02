using System;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employee { get;set;}
        public DbSet<Department> Department { get; set; }
    }
}
