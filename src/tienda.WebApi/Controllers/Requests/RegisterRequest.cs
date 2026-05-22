namespace tienda.WebApi.Controllers.Requests;

public record RegisterRequest(
    string FirstName,
    string LastName,
    string Email,
    string Password);
