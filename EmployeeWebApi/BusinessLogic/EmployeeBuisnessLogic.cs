using EmployeeWebApi.Models;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using System.Text;
using System;

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

        public Employee FindEmployeeById(int id)
        {
            Employee result;

            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                result = ((EmployeeList)serializer.Deserialize(fs)).Employees.Find(emp => emp.Id == id);
                //result = ((EmployeeList)serializer.Deserialize(fs)).Employees.Find(emp => { return emp.Id == id; });
            }
            return result;
        }

        public int UpdateEmployee(Employee employee)
        {
            EmployeeList result;
            if (File.Exists(path))
            {
                using (FileStream fileStream = new FileStream(path, FileMode.Open))
                {
                    result = (EmployeeList)serializer.Deserialize(fileStream);
                    fileStream.Close();
                }
                var employeeFound = result.Employees.Find(emp => emp.Id == employee.Id);
                if (employeeFound != null)
                {
                    employeeFound.Id = employee.Id;
                    employeeFound.City = employee.City;
                    employeeFound.Name = employee.Name;
                    employeeFound.Phone = employee.Phone;
                    using (FileStream fileStream = new FileStream(path, FileMode.Create))
                    {
                        XmlWriter writer = new XmlTextWriter(fileStream, Encoding.Unicode);
                        serializer.Serialize(writer, result);
                        writer.Close();
                        fileStream.Close();
                    }
                }
            }
            return 0;
        }

        public int DeleteEmployee(int id)
        {
            EmployeeList result;
            if (File.Exists(path))
            {
                using (FileStream fileStream = new FileStream(path, FileMode.Open))
                {
                    result = (EmployeeList)serializer.Deserialize(fileStream);
                    fileStream.Close();
                }

                var employeeFound = result.Employees.Find(emp => emp.Id == id);
                result.Employees.Remove(employeeFound);

                using (FileStream fileStream = new FileStream(path, FileMode.Create))
                {
                    XmlWriter writer = new XmlTextWriter(fileStream, Encoding.Unicode);
                    serializer.Serialize(writer, result);
                    writer.Close();
                    fileStream.Close();
                }
            }
            return 0;
        }

        public int AddEmployee(Employee employee)
        {
            EmployeeList result;
            if (File.Exists(path))
            {
                using (FileStream fileStream = new FileStream(path, FileMode.Open))
                {
                    result = (EmployeeList)serializer.Deserialize(fileStream);
                    fileStream.Close();
                }
                result.Employees.Add(employee);
                using (FileStream fileStream = new FileStream(path, FileMode.Create))
                {
                    XmlWriter writer = new XmlTextWriter(fileStream, Encoding.Unicode);
                    serializer.Serialize(writer, result);
                    writer.Close();
                    fileStream.Close();
                }
            }
            return 0;
        }
    }
}