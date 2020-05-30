using EmployeeManagement.DAL.DBAccess;
using EmployeeManagement.Models.Employees;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.DAL.DataAccessRepository
{
    public class EmployeeDataAccess : IEmployeeDataAccess
    {
        //SQLDataAccess _sqlDataAccess;

        private readonly ISQLDataAccess _sqlDataAccess;

        string ConnectionStringSettings;

        public  IConfiguration Configuration { get;  }

        public EmployeeDataAccess(ISQLDataAccess sQLDataAccess,IConfiguration configuration)
        {
            Configuration = configuration;
            _sqlDataAccess = sQLDataAccess;
            ConnectionStringSettings = Configuration.GetConnectionString("EmployeeConnectionString");
        }
        public async Task<List<Employee>> GetEmployees()
        {
            var parameter = new { };
            var result = await _sqlDataAccess.LoadData<Employee, dynamic>("sp_GetAllEmployees", parameter, Configuration.GetConnectionString("EmployeeConnectionString"));
            return result;
        }

        public async Task<int> CreateEmployeeAsync(Employee employeetoCreate)
        {
            var result = 0;
            try
            {
                var parameter = new { employee = employeetoCreate };

                result = await _sqlDataAccess.ExecuteData("sp_InsertEmployee", employeetoCreate, "EmployeeConnectionString");

            }
            catch (Exception)
            {
                result = -1;
            }            
            return result;
        }

        public async Task<int> DeleteEmployeeAsync(int id)
        {
            var result = 0;

            try
            {
                var employee = await GetEmployeeAsync(id);

                if (employee == null)
                    return result;

                Dictionary<bool, string> returnDic = new Dictionary<bool, string>();

                var parameters = new { Id = id };

                result = await _sqlDataAccess.RemoveData("sp_DeleteEmployee", parameters, "EmployeeConnectionString");

            }
            catch (Exception)
            {

                result = -1;
            }
            return result;
        }

        public Task<List<Employee>> GetAllEmployeeAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Employee> GetEmployeeAsync(int id)
        {
            var parameter = new { Id = id };
            var result = await _sqlDataAccess.LoadData<Employee, dynamic>("sp_GetEmployeeById", parameter, "EmployeeConnectionString");
            return result.FirstOrDefault();
        }

        public async Task<int> UpdateEmployeeAsync(int id, Employee employeeToUpdate)
        {
            var result = 0;

            try
            {
               
                var parameters = new
                {
                    Id = id,
                    FirstName = employeeToUpdate.FirstName,
                    LastName = employeeToUpdate.LastName,
                    EmailAddress = employeeToUpdate.EmailAddress,
                    Gender = employeeToUpdate.Gender,
                    Salary = employeeToUpdate.Salary,
                    Department = employeeToUpdate.Department,
                    Role = employeeToUpdate.Role,
                    ModifiedDate = DateTime.Now,
                };

                result = await _sqlDataAccess.ExecuteData("sp_UpdateEmployee", parameters, "EmployeeConnectionString");

            }
            catch (Exception)
            {
                result = -1;
            }
            return result;
        }
    }
}