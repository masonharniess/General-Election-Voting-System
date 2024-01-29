using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GEVS_API.Models;

namespace GEVS_API.Entities;

public class VoteEntity
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid CandidateId { get; set; }
    
    public virtual UserEntity User { get; set; }
    public virtual CandidateEntity Candidate { get; set; }
}