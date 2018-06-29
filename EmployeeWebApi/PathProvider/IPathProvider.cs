using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeWebApi.PathProvider
{
    public interface IPathProvider
    {
        string MapPath();
    }
}