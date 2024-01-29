namespace GEVS_API.DTOs;

public class UserRegistrationDto
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public string ConstituencyName { get; set; }
    public string UniqueVoterCode { get; set; }
}