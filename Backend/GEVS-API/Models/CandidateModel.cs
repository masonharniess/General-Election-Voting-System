using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GEVS_API.Models;

public class CandidateModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    
    public Guid ConstituencyId { get; set; }
    public Guid PartyId { get; set; }
}