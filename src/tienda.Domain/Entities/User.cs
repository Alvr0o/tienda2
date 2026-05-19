// Entities/User.cs
using tienda.Domain.ValueObjects;
using tienda.Domain.Exceptions;

namespace tienda.Domain.Entities;

public class User : BaseEntity
{
    public string FirstName { get; private set; } = null!;
    public string LastName { get; private set; } = null!;
    public Email Email { get; private set; } = null!;
    public bool IsActive { get; private set; }

    private User() { }

    public static User Create(string firstName, string lastName, Email email)
    {
        if (string.IsNullOrWhiteSpace(firstName))
            throw new DomainException("El nombre es obligatorio.");

        if (string.IsNullOrWhiteSpace(lastName))
            throw new DomainException("El apellido es obligatorio.");

        return new User
        {
            FirstName = firstName.Trim(),
            LastName = lastName.Trim(),
            Email = email,
            IsActive = true
        };
    }

    public void UpdateName(string newFirstName, string newLastName)
    {
        if (string.IsNullOrWhiteSpace(newFirstName) || string.IsNullOrWhiteSpace(newLastName))
            throw new DomainException("El nombre y apellido no pueden estar vacíos.");

        FirstName = newFirstName.Trim();
        LastName = newLastName.Trim();
    }

    public void Deactivate() => IsActive = false;
}