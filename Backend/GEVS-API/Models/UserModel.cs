using System.ComponentModel.DataAnnotations.Schema;

namespace GEVS_API.Models;

public class UserModel
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }
    public DateOnly DoB { get; set; }
    

    public Guid RoleId { get; set; }
    public Guid ConstituencyId { get; set; }
    public Guid UniqueVoterCodeId { get; set; }
}