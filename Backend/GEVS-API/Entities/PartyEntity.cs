namespace GEVS_API.Entities;

public class PartyEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    
    public virtual ICollection<CandidateEntity> Candidates { get; set; }
}