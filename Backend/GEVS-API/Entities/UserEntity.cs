using System.ComponentModel.DataAnnotations.Schema;

namespace GEVS_API.Entities;

public class UserEntity
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }
    public DateOnly DoB { get; set; }

    public Guid RoleId { get; set; }
    public Guid ConstituencyId { get; set; }
    public Guid UvcId { get; set; }
    
    public virtual RoleEntity Role { get; set; }
    public virtual ConstituencyEntity Constituency { get; set; }
    public virtual UvcEntity Uvc { get; set; }
}