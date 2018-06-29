using System;
using System.IO;

namespace EmployeeWebApi.PathProvider
{
    public class ServerPathProvider : IPathProvider
    {
        public string MapPath()
        {
            return System.Web.HttpContext.Current.Request.MapPath("~\\BusinessLogic\\employee.xml");
        }
    }
}