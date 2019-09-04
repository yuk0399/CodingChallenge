using EmployeeManagement.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmployeeManagement.MSTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {

            var first = "Taro";
            var last = "Yamada";

            var expected = "Taro Yamada";

            var person = new Employee()
            {
                FirstName = first,
                LastName = last,
            };

            Assert.AreEqual(expected, person.Name);
        }
    }
}
