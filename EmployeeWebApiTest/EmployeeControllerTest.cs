using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmployeeWebApi.Controllers;
using EmployeeWebApi.Models;
using EmployeeWebApi.BusinessLogic;
using Moq;
using System.Web.Http.Results;
using System.Collections.Generic;

namespace EmployeeWebApiTest
{
    [TestClass]
    public class EmployeeControllerTest
    {
        [TestMethod]
        public void GetEmployeeListShouldReturnAllEmployees()
        {
            Mock<IEmployeeBuisnessLogic> mock = new Mock<IEmployeeBuisnessLogic>();
            mock.Setup(x => x.GetEmpList()).Returns(new EmployeeList
            {
                Employees = new List<Employee>
                {
                    new Employee
                    {
                        City = "Pune",
                        Id = 1,
                        Name = "santosh",
                        Phone = 12233
                    }
                },
                NextId = 1
            });

            EmployeeController controller = new EmployeeController(mock.Object);
            var result = controller.GetEmployeeList();
            Assert.IsNotNull(result);
            var negResult = result as OkNegotiatedContentResult<List<Employee>>;
            Assert.AreEqual(negResult.Content.Count, 1);
        }
    }
}
