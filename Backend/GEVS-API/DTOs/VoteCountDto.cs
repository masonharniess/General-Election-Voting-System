namespace GEVS_API.DTOs;

public class VoteCountDto
{
    public Guid ConstituencyId { get; set; }
    public string ConstituencyName { get; set; }
    public Guid CandidateId { get; set; }
    public string CandidateName { get; set; }
    public int VoteCount { get; set; }
}