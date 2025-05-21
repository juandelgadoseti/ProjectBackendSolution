using Microsoft.AspNetCore.Mvc;
using APIProjectBackend.EntititesDto;
using APIProjectBackend.Service;
using APIProjectBackend.Service.Contracts;

namespace APIProjectBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var user = _authService.Login(request.Correo, request.Password);
            if (user == null)
                return Unauthorized("Credenciales inv�lidas");

            var token = _authService.GenerateJwtToken(user);
            return Ok(new { token });
        }
    }
}