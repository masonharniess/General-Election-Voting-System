using System.ComponentModel.DataAnnotations;

namespace GEVS_API.Models;

public class ElectionModel
{
    public Guid Id { get; set; }
    public DateTime StartDateTime { get; set; }
    public DateTime EndDateTime { get; set; } = DateTime.MaxValue;
}