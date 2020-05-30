
using EmployeeManagement.Models.Employees;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.DAL.DataAccessRepository
{
    public interface IEmployeeDataAccess
    {
        Task<List<Employee>> GetEmployees();
        Task<int> CreateEmployeeAsync(Employee employeetoCreate);
        Task<int> DeleteEmployeeAsync(int id);
        Task<List<Employee>> GetAllEmployeeAsync();
        Task<Employee> GetEmployeeAsync(int id);
        Task<int> UpdateEmployeeAsync(int id, Employee employeetoUpdate);


    }
}
