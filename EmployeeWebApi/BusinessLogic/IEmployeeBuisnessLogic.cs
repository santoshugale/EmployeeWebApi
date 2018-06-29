using EmployeeWebApi.Models;

namespace EmployeeWebApi.BusinessLogic
{
    public interface IEmployeeBuisnessLogic
    {
        int AddEmployee(Employee employee);
        int DeleteEmployee(int id);
        Employee FindEmployeeById(int id);
        EmployeeList GetEmpList();
        int UpdateEmployee(Employee employee);
    }
}