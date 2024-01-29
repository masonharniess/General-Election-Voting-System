using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GEVS_API.Entities;

public class CandidateEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    
    public Guid ConstituencyId { get; set; }
    public Guid PartyId { get; set; }
    
    public virtual ConstituencyEntity Constituency { get; set; }
    public virtual PartyEntity Party { get; set; }
    
    public virtual ICollection<VoteEntity> Votes { get; set; }

}