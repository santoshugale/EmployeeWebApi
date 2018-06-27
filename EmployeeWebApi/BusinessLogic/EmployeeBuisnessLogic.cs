using EmployeeWebApi.Models;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using System.Xml.Serialization;
using System;
using System.Xml;
using System.Text;

namespace EmployeeWebApi.BusinessLogic
{
    public class EmployeeBuisnessLogic
    {
        XmlSerializer serializer;
        string path;

        public EmployeeBuisnessLogic()
        {
            serializer = new XmlSerializer(typeof(EmployeeList));
            path = System.Web.HttpContext.Current.Request.MapPath("~\\BusinessLogic\\employee.xml");
        }
        public EmployeeList GetEmpList()
        {
            EmployeeList result;
            using (FileStream fileStream = new FileStream(path, FileMode.Open))
            {
                result = (EmployeeList)serializer.Deserialize(fileStream);
            }
            return result;
        }

        public int AddEmployee(Employee employee)
        {
            EmployeeList result;
            if (File.Exists(path))
            {
                using (FileStream fileStream = new FileStream(path, FileMode.Open))
                {
                    result = (EmployeeList)serializer.Deserialize(fileStream);
                }
                result.Employees.Add(employee);
                using (FileStream fileStream = new FileStream(path, FileMode.Open))
                {
                    XmlWriter writer = new XmlTextWriter(fileStream, Encoding.Unicode);
                    serializer.Serialize(writer, result);
                    writer.Close();
                }
            }
            return 0;
        }
    }
}