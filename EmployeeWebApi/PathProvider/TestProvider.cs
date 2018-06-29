using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace EmployeeWebApi.PathProvider
{
    public class TestProvider : IPathProvider
    {
        public string MapPath()
        {
            return Path.Combine(Environment.CurrentDirectory, @"BusinessLogic\employee.xml");
        }
    }
}