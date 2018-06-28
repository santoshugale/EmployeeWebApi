using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace EmployeeWebApi.Models
{
    public class EmployeeList
    {
        [XmlElement("Employee")]
        public List<Employee> Employees { get; set; }
    }
    public class Employee
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string City { get; set; }
        [MinLength(10)]
        [MaxLength(10)]
        public int Phone { get; set; }
    }
}