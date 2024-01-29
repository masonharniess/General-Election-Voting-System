using GEVS_API.Context;
using GEVS_API.DTOs;
using GEVS_API.Entities;
using GEVS_API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GEVS_API.Controllers;

[Route("api")]
[ApiController]
public class RegistrationController : ControllerBase
{
    private readonly GevsContext _context;

    public RegistrationController(GevsContext context)
    {
        _context = context;
    }

[HttpPost("registration")]
public async Task<ActionResult<UserEntity>> PostRegistration(UserRegistrationDto registrationDto)
{
    var hashingService = new HashingService();
    
    var existingUserWithEmail = await _context.UserEntities
        .AnyAsync(u => u.Email == registrationDto.Email);
    if (existingUserWithEmail)
    {
        return BadRequest(new { message = "The provided email is already in use. Please use a different email." });
    }
    
    var uvc = await _context.UvcEntities
        .FirstOrDefaultAsync(u => u.UniqueVoterCode == registrationDto.UniqueVoterCode);
    if (uvc == null)
    {
        return BadRequest(new { message = "This unique voter code is not valid." });
    }

    if (uvc.isUsed)
    {
        return BadRequest(new { message = "This unique voter code is already used." });
    }

    uvc.isUsed = true;

    // Hash the password
    string hashedPassword = hashingService.HashPassword(registrationDto.Password);

    // Create new user entity
    var userEntity = new UserEntity
    {
        Email = registrationDto.Email,
        Password = hashedPassword,
        Name = registrationDto.Name,
        DoB = registrationDto.DateOfBirth,
        RoleId = await AssignDefaultRoleId(),
        Uvc = uvc
    };

    // Fetch Constituency entity by name
    var constituency = await _context.ConstituencyEntities
        .FirstOrDefaultAsync(c => c.Name == registrationDto.ConstituencyName);
    if (constituency == null)
    {
        return BadRequest(new { message = "This constituency does not exist." });
    }

    userEntity.Constituency = constituency;

    // Save the new user
    _context.UserEntities.Add(userEntity);
    await _context.SaveChangesAsync();

    // Fetch the role title from the database
    var roleTitle = await _context.RoleEntities
        .Where(r => r.Id == userEntity.RoleId)
        .Select(r => r.Title)
        .FirstOrDefaultAsync();

    // Prepare the result
    var result = new
    {
        Id = userEntity.Id,
        Email = userEntity.Email,
        Name = userEntity.Name,
        DateOfBirth = userEntity.DoB,
        Role = roleTitle
    };

    return CreatedAtAction(nameof(PostRegistration), new { id = userEntity.Id }, result);
}

private async Task<Guid> AssignDefaultRoleId()
{
    var defaultRole = await _context.RoleEntities.FirstOrDefaultAsync(r => r.Title == "Voter");
    return defaultRole?.Id ?? Guid.Empty;
}

}