using MediatR;
using tienda.Application.Contracts.Authentication;

namespace tienda.Application.Features.Authentication.Commands.Register;

public class RegisterCommand : IRequest<AuthResponse>
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
}
