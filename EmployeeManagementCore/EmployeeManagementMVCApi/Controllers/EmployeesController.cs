using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Models.Employees;
using EmployeesManagement.BAL.Repository.EmployeeRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Extensions;

namespace EmployeeManagementMVCApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ILogger<EmployeesController> _logger;

        public EmployeesController(IEmployeeRepository employeeRepository,ILogger<EmployeesController> logger)
        {
            _employeeRepository = employeeRepository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployeesAsync()
        {
            try
            {

                var employees = await _employeeRepository.GetAllEmployeeAsync();

                return Ok(employees);

            }
            catch (Exception ex)
            {

                _logger.LogError($"The Path {ex.StackTrace} threw an exception {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }


        [HttpGet]
        [Route("/GetEmployee/{id}")]
        public async Task<IActionResult> GetEmployeeByIdAsync(int id)
        {
            try
            {
              
                var employee = await _employeeRepository.GetEmployeeAsync(id);

                return Ok(employee);

            }
            catch (Exception ex)
            {
               
                _logger.LogError($"The Path {ex.StackTrace} threw an exception {ex.Message}");

                return StatusCode(500, ex.Message);
            }
        }
                                                               
        [HttpPost]
        [Route("/CreateEmployee")]
        public async Task<IActionResult> CreateEmployeeAsync(Employee employee)
        {
            try
            {
                var result = await _employeeRepository.CreateEmployeeAsync(employee);

                return Ok(result);

            }
            catch (Exception ex)
            {

                
                _logger.LogError($"The Path {ex.StackTrace} threw an exception {ex.Message}");

                return StatusCode(500, ex.Message);
            }
        }

        // PUT: api/Employee/5
        [HttpPut]
        [Route("/UpdateEmployee/{id}")]
        public async Task<IActionResult> UpdateEmployeeAsync(int id, [FromBody] Employee employee)
        {
            try
            {
                var result = await _employeeRepository.UpdateEmployeeAsync(id, employee);
                if (result.ContainsKey(true))
                {
                    return Ok(result[true]);
                }

                else if (result[false] == "No Record Found")
                {
                    return NotFound(result[false]);
                }
                else
                {
                    return new BadRequestResult();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"The Path {ex.StackTrace} threw an exception {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete]
        [Route("/DeleteEmployee/{id}")]
        public async Task<IActionResult> DeleteEmployeeAsync(int id)
        {
            try
            {
                var result = await _employeeRepository.DeleteEmployeeAsync(id);
                if (result.ContainsKey(true))
                {
                    return Ok(result[true]);
                }

                else
                {
                    return NotFound(result[false]);
                }

            }
            catch (Exception ex)
            {

                _logger.LogError($"The Path {ex.StackTrace} threw an exception {ex.Message}");

                return StatusCode(500, ex.Message);
            }
        }
    }
}
