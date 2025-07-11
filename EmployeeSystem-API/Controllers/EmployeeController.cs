﻿using MyApp.Core.DTOs.Request;
using MyApp.Core.Interfaces;
using MyApp.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeSystem_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private readonly IEmployee _appService;

        public EmployeeController(IEmployee appService)
        {
            _appService = appService;
        }


        
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateEmployee(CreateEmployeeInputDTO input)
        {
            try
            {
                var response = await _appService.CreateEmployee(input);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


      

        [HttpPost("[action]")]
        public async Task<IActionResult> UploadImage(int id, IFormFile profileImage)
        {
            try
            {
                var response = await _appService.UploadImage(id, profileImage);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }



        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            try
            {
                var response = await _appService.DeleteEmployee(id);
                if (response.Contains("not found"))
                    return NotFound(response);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            var employee = await _appService.GetEmployee(id);

            if (employee == null || !employee.Any())
                return NotFound($"Employee with ID {id} not found.");

            return Ok(employee);
        }

        [HttpGet("GetAllEmployees")]
        public async Task<IActionResult> GetAllEmployees()
        {
            try
            {
                var employees = await _appService.GetAllEmployee();

                if (employees == null || !employees.Any())
                    return NotFound("No employees found.");

                return Ok(employees);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpPut("update")]
        public async Task<IActionResult> UpdateEmployee([FromBody] UpdateEmployeeDTO input)
        {
            var result = await _appService.UpdateEmployee(input);

            if (result.Contains("successfully"))
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPost("upload-image/{id}")]
        public async Task<IActionResult> UpdateImageUpload(int id, IFormFile profileImage)
        {
            var result = await _appService.UpdateImageUpload(id, profileImage);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

    }
}
