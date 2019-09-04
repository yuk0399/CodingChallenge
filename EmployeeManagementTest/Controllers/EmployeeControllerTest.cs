using System;
using System.Collections.Generic;
using EmployeeManagement.Controllers;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace EmployeeManagementTest.Controllers
{
    public class EmployeeControllerTest : IDisposable
    {

        [Fact]
        public void SampleTest()
        {
            var first = "Taro";
            var last = "Yamada";

            var expected = "Taro Yamada";

            var person = new Employee()
            {
                FirstName = first,
                LastName = last,
            };

            Assert.Equal(expected, person.Name, ignoreCase: true);
        }


        public void Dispose()
        {
            
        }
    }
}
