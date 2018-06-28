using System;
using System.Net.Http;
using System.Net;
using System.Web.Http.Filters;

namespace EmployeeWebApi.Filters
{
    public class NotImplExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Exception is NotImplementedException)
            {
                actionExecutedContext.Response = new HttpResponseMessage(HttpStatusCode.NotImplemented);
            }
        }
    }
}

//There are several ways to register a Web API exception filter:
//By action
//By controller
//Globally