using Domain.Entities;

namespace Domain.ValueObjects;

public class CadastralControl
{
    public DateTime CreatedAt { get; set; }
    public User? CreatedBy { get; set; }
    public DateTime UpdatedAt { get; set; }
    public User? UpdatedBy { get; set; }
}