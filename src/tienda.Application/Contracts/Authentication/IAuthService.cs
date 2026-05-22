using System.Security.Claims;

namespace tienda.Application.Contracts.Authentication;

public interface IAuthService
{
    string GenerateToken(string userId, string email, string role, DateTime expiresAt);
    ClaimsPrincipal ValidateToken(string token);
}