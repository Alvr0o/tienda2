using MediatR;
using Microsoft.AspNetCore.Mvc;
using tienda.Application.Features.Authentication.Commands.Login;
using tienda.Application.Features.Authentication.Commands.Register;
using tienda.WebApi.Controllers.Requests;

namespace tienda.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Registra un nuevo usuario. El rol asignado es Customer por defecto.
    /// </summary>
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request, CancellationToken ct)
    {
        // El controller mapea el Request (capa HTTP) al Command (capa Application)
        var command = new RegisterCommand
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            Password = request.Password
        };

        var result = await _mediator.Send(command, ct);
        return Ok(result);
    }

    /// <summary>
    /// Inicia sesión y devuelve un token JWT con el rol del usuario.
    /// </summary>
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request, CancellationToken ct)
    {
        // El controller mapea el Request (capa HTTP) al Command (capa Application)
        var command = new LoginCommand
        {
            Email = request.Email,
            Password = request.Password
        };

        var result = await _mediator.Send(command, ct);
        return Ok(result);
    }
}
