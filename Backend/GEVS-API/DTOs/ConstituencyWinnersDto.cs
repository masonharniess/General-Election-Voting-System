namespace GEVS_API.DTOs;

public class ConstituencyWinnersDto
{
    public Guid ConstituencyId { get; set; }
    public string ConstituencyName { get; set; }
    public Guid WinningCandidateId { get; set; }
    public string WinningCandidateName { get; set; }
    public Guid PartyId { get; set; }
    public string PartyName { get; set; }
}