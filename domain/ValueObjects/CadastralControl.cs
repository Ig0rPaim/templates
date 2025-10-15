using Domain.Entities;

namespace Domain.ValueObjects;

public class CadastralControl
{
    public DateTime CreatedAt { get; set; }
    public UserEntity? CreatedBy { get; set; }
    public DateTime UpdatedAt { get; set; }
    public UserEntity? UpdatedBy { get; set; }
}