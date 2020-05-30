﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Models.Employees;
using EmployeesManagement.BAL.Repository.EmployeeRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
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

                throw ex;
            }
        }


        [HttpGet]
        public async Task<IActionResult> GetEmployeeByIdAsync(int id)
        {
            try
            {

                var employee = await _employeeRepository.GetEmployeeAsync(id);

                return Ok(employee);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPost]

        public async Task<IActionResult> CreateEmployeeAsync(Employee employee)
        {
            try
            {
                var result = await _employeeRepository.CreateEmployeeAsync(employee);

                return Ok(result);

            }
            catch (Exception)
            {

                throw;
            }
        }

        // PUT: api/Employee/5
        [HttpPut("{id}")]
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
            catch (Exception)
            {

                throw;
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeAsync(int id)
        {
            try
            {
                var result = await _employeeRepository.DeleteEmployeeAsync(id);
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

                throw ex;
            }
        }



    }
}
