using EmployeeWebApi.BusinessLogic;
using EmployeeWebApi.Models;
using System.Web.Http;

namespace EmployeeWebApi.Controllers
{
    public class EmployeeController : ApiController
    {
        private EmployeeBuisnessLogic employeeBuisnessLogic;
        public EmployeeController()
        {
            // use simple injector to get the buisnes logic obj
            employeeBuisnessLogic = new EmployeeBuisnessLogic();
        }

        [HttpGet]
        public IHttpActionResult GetEmployeeList()
        {
            return Ok(employeeBuisnessLogic.GetEmpList());
        }

        [HttpPost]
        public IHttpActionResult AddEmployee([FromBody] Employee employee)
        {
            return Ok(employeeBuisnessLogic.AddEmployee(employee));
        }
    }
}
