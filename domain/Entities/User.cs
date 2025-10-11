using Domain.ValueObjects;

namespace Domain.Entities;

public class User
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public bool IsActive { get; set; }
    public CadastralControl? CadastralControl { get; set; }
    public ICollection<Role> Roles { get; set; }

    public User(Guid id, string? name, string? email, bool isActive, CadastralControl? cadastralControl,
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