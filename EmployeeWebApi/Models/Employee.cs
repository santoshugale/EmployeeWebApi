using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace EmployeeWebApi.Models
{
    public class EmployeeList
    {
        [XmlElement("Employee")]
        public List<Employee> Employees { get; set; }

        public int NextId { get; set; }
    }
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public int Phone { get; set; }
    }
}