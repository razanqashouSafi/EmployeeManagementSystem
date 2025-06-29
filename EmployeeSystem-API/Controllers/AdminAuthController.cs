using MyApp.Core.DTOs.Request;
using MyApp.Core.Interfaces;
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
        public async Task<IActionResult> Login([FromBody] LoginReqDTO input)
        {
            var result = await _service.Login(input);

            if (!result.IsSuccess)
                return Unauthorized(new { error = result.ErrorMessage });

            return Ok(new { token = result.Token });
        }

    }
}
