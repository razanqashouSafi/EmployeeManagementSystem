using EmployeeSystem_API.DTOs.Request;
using EmployeeSystem_API.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeSystem_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminAuthController : ControllerBase
    {

        private readonly IAdminAuth _service;

        public AdminAuthController(IAdminAuth service)
        {
            _service = service;
        }



        [HttpPost("signup")]
        public async Task<IActionResult> Signup(SignupAdmnDTO dto)
        {
            var result = await _service.Signup(dto);
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(String email, string pass)
        {
            var result = await _service.Login(email, pass);

           
            if (result.StartsWith("Invalid"))
                return Unauthorized(result);

           
            return Ok(new { Token = result });
        }

    }
}
