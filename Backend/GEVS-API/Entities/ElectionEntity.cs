namespace GEVS_API.Entities;

public class ElectionEntity
{
    public Guid Id { get; set; }
    public DateTime StartDateTime { get; set; }
    public DateTime EndDateTime { get; set; } = DateTime.MaxValue;
}