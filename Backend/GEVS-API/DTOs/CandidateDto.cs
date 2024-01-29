namespace GEVS_API.DTOs;

public class CandidateDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    
    public string PartyName { get; set; }
    public string ConstituencyName { get; set; }
    public int VoteCount { get; set; } 
}
