using Domain.ValueObjects;

namespace Domain.Entities;

public class UserEntity
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public bool IsActive { get; set; }
    public CadastralControl? CadastralControl { get; set; }
    public ICollection<Role> Roles { get; set; }

    public UserEntity()
    {   
    }

    public UserEntity(Guid id, string? name, string? email, bool isActive, CadastralControl? cadastralControl,
        ICollection<Role> roles)
    {
        Id = id;
        Name = name;
        Email = email;
        IsActive = isActive;
        CadastralControl = cadastralControl;
        Roles = roles ?? throw new ArgumentNullException(nameof(roles));
    }
}