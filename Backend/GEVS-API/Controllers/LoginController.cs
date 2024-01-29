using GEVS_API.Context;
using GEVS_API.Controllers;
using GEVS_API.DTOs;
using GEVS_API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GEVS_API.Controllers;

[Route("api")]
[ApiController]
public class LoginController : ControllerBase
{
    private readonly GevsContext _context;
    
    public LoginController(GevsContext context)
    {
        _context = context; 
    }
    
    [HttpPost("login")]
    public async Task<ActionResult> Login(LoginDto loginDto)
    {
        var hashingService = new HashingService();
    
        var user = await _context.UserEntities.Include(u => u.Role)
            .FirstOrDefaultAsync(u => u.Email == loginDto.Email);

        if (user != null && hashingService.VerifyPassword(user.Password, loginDto.Password))
        {
            return Ok(new 
            {
                message = "Login successful",
                role = user.Role.Title,
                userId = user.Id.ToString()  // Convert GUID to string if necessary
            });
        }

        return Unauthorized(new { message = "Email or password is incorrect" });
    }
    
    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        return Ok(new { message = "Logged out successfully" });
    }

}