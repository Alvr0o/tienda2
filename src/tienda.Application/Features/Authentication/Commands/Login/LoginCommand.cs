using MediatR;
using tienda.Application.Contracts.Authentication;

namespace tienda.Application.Features.Authentication.Commands.Login;

public class LoginCommand : IRequest<AuthResponse>
{
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
}
