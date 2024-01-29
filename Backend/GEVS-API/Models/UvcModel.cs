namespace GEVS_API.Models;

public class UvcModel
{
    public Guid Id { get; set; }
    public string UniqueVoterCode { get; set; }
    public bool isUsed { get; set; }
}