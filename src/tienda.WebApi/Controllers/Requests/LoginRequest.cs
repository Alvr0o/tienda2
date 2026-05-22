namespace tienda.WebApi.Controllers.Requests;

public record LoginRequest(
    string Email,
    string Password);
