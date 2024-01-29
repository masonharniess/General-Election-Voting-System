using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GEVS_API.Models;

public class VoteModel
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid CandidateId { get; set; }
}