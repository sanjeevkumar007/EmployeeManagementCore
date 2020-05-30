using EmployeeManagement.Models.Employees;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace EmployeesManagement.BAL.Repository.EmployeeRepository
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetAllEmployeeAsync();
        Task<Employee> GetEmployeeAsync(int id);
        Task<bool> CreateEmployeeAsync(Employee employeetoCreate);
        Task<Dictionary<bool, string>> UpdateEmployeeAsync(int id, Employee employeetoCreate);
        Task<Dictionary<bool,string>> DeleteEmployeeAsync(int id);

    }
}
