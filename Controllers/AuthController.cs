using Microsoft.AspNetCore.Mvc;
using ProductCRUD.DTOs;
using ProductCRUD.Services;

namespace ProductCRUD.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // กลายเป็น URL: api/auth
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        // 📥 POST: api/auth/register
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto dto)
        {
            var result = await _authService.RegisterAsync(dto);
            if (result.Message == "Username นี้มีผู้ใช้งานแล้ว")
            {
                return BadRequest(new { message = result.Message });
            }
            return Ok(result);
        }

        // 📥 POST: api/auth/login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var result = await _authService.LoginAsync(dto);
            if (result == null)
            {
                return Unauthorized(new { message = "Username หรือ Password ไม่ถูกต้อง" });
            }
            return Ok(result);
        }

        // [HttpDelete("{id}")]
        // public async Task<IActionResult> Delete(int id)
        // {
        //     var success = await _authService.DeleteAsync(id);
        //     return success ? NoContent() : NotFound();
        // }
    }
}