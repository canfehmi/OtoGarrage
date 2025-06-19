using AuthService.Dtos;
using AuthService.Interfaces;
using AuthService.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly JwtGenerator _jwtGenerator;

        public AuthController(IUserService userService, JwtGenerator jwtGenerator)
        {
            _userService = userService;
            _jwtGenerator = jwtGenerator;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            var user = await _userService.RegisterAsync(dto);
            if (user == null)
            {
                return BadRequest("User registration failed.");
            }
            return Ok("Kayıt Başarılı");
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var user = await _userService.LoginAsync(dto);
            if (user == null)
            {
                return Unauthorized("Invalid credentials.");
            }
            var token = _jwtGenerator.GenerateToken(user);
            return Ok(new { Token = token });
        }
    }
}
