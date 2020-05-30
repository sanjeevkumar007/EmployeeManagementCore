
using EmployeeManagement.DAL.DataAccessRepository;
using EmployeeManagement.Models.Employees;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace EmployeesManagement.BAL.Repository.EmployeeRepository
{
    public class EmployeeRepository : IEmployeeRepository
    {

        IEmployeeDataAccess _employeeDataAccess = null;
        public EmployeeRepository(IEmployeeDataAccess employeeDataAccess)
        {
            _employeeDataAccess = employeeDataAccess;

        }
        public async Task<bool> CreateEmployeeAsync(Employee employeetoCreate)
        {
            var result =await _employeeDataAccess.CreateEmployeeAsync(employeetoCreate);
            if (result==1)
            {
                return true;
            }
            else
            {
                return false;
            }    
            
        }

        public async Task<Dictionary<bool,string>> DeleteEmployeeAsync(int id)
        {
            Dictionary<bool, string> responseDic = new Dictionary<bool, string>();
            var employee=await GetEmployeeAsync(id);
            if (employee == null)
            {
                responseDic.Add(false, "No Record Found");

            }
            else
            {
            var result= await _employeeDataAccess.DeleteEmployeeAsync(id);
                if (result == 1)
                    responseDic.Add(true, "Record Deleted");
                else if(result==0)
                    responseDic.Add(false, "No Record Found");
                else
                    responseDic.Add(false, "Exception Raised");
            }

            return responseDic;

        }

        public async Task<List<Employee>> GetAllEmployeeAsync()
        {
            return await _employeeDataAccess.GetEmployees();
        }

        public async Task<Employee> GetEmployeeAsync(int id)
        {
            return await _employeeDataAccess.GetEmployeeAsync(id);
        }

        public async Task<Dictionary<bool,string>> UpdateEmployeeAsync(int id, Employee employeetoUpdate)
        {
            Dictionary<bool, string> responseDic = new Dictionary<bool, string>();
            var employee = await GetEmployeeAsync(id);
            if (employee == null)
            {
                responseDic.Add(false, "No Record Found");

            }
            else
            {
                var result = await _employeeDataAccess.UpdateEmployeeAsync(id,employeetoUpdate);
                if (result==1)
                    responseDic.Add(true, "Record Updated");
                else if(result==0)
                    responseDic.Add(false, "No Record Found");
                else
                    responseDic.Add(false, "Exception Raised");

            }

            return responseDic;
        }
    }
}
