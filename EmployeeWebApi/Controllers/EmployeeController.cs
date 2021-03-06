﻿using EmployeeWebApi.BusinessLogic;
using EmployeeWebApi.Models;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EmployeeWebApi.Controllers
{
    //[EnableCors(origins: "*", headers: "*", methods: "*")] // no need to provide here as its provided globally
    public class EmployeeController : ApiController
    {
        private IEmployeeBuisnessLogic employeeBuisnessLogic;
        public EmployeeController(IEmployeeBuisnessLogic employeeBuisnessLogicObj)
        {
            employeeBuisnessLogic = employeeBuisnessLogicObj;
        }

        /// <summary>
        /// Get All the Employees
        /// </summary>
        /// <remarks>
        /// Simple comment
        /// </remarks>
        /// <param></param>
        /// <returns>Returns employees</returns>
        /// <response code="200">Returns employees</response>
        [HttpGet]
        public IHttpActionResult GetEmployeeList()
        {
            return Ok(employeeBuisnessLogic.GetEmpList().Employees);
        }

        /// <summary>
        /// Get Employee by id
        /// </summary>
        /// <remarks>
        /// Simple comment
        /// </remarks>
        /// <param name="id"></param>
        /// <returns>Returns employee</returns>
        /// <response code="200">Returns employee</response>
        [HttpGet]
        [ActionName("GetEmployee")]
        public HttpResponseMessage FindEmployee(int id)
        {
            if (!ModelState.IsValid) return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            Employee emp = employeeBuisnessLogic.FindEmployeeById(id);
            if (emp == null)
            {
                var httpResMsg = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format("No Employee With Id = {0}", id)),
                    ReasonPhrase = "Product ID Not Found"
                };
                throw new HttpResponseException(httpResMsg);
            }
            return Request.CreateResponse(HttpStatusCode.OK, emp);
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
