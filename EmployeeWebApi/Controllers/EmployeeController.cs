using EmployeeWebApi.BusinessLogic;
using EmployeeWebApi.Models;
using System.Web.Http;
using System.Web.Http.Cors;

namespace EmployeeWebApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
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
            return Ok(employeeBuisnessLogic.GetEmpList().Employees);
        }

        [HttpGet]
        [ActionName("GetEmployee")]
        public IHttpActionResult FindEmployee(int id)
        {
            return Ok(employeeBuisnessLogic.FindEmployeeById(id));
        }

        [HttpPut]
        public IHttpActionResult UpdateEmployee([FromBody] Employee employee)
        {
            return Ok(employeeBuisnessLogic.UpdateEmployee(employee));
        }

        [HttpPost]
        public IHttpActionResult AddEmployee([FromBody] Employee employee)
        {
            return Ok(employeeBuisnessLogic.AddEmployee(employee));
        }

        [HttpDelete]
        public IHttpActionResult DeleteEmployee(int id)
        {
            return Ok(employeeBuisnessLogic.DeleteEmployee(id));
        }

        // To prevent a method from getting invoked as an action, 
        //use the NonAction attribute. This signals to the framework that the method is not an action, 
        //even if it would otherwise match the routing rules.
        // Not an action method.
        // [NonAction]
    }
}
