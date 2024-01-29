namespace GEVS_API.Entities;

public class UvcEntity
{
    public Guid Id { get; set; }
    public string UniqueVoterCode { get; set; }
    public bool isUsed { get; set; }
}