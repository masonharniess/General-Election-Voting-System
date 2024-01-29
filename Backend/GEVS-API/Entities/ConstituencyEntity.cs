using System.ComponentModel.DataAnnotations;

namespace GEVS_API.Entities;

public class ConstituencyEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    
    public virtual ICollection<CandidateEntity> Candidates { get; set; }
    
}