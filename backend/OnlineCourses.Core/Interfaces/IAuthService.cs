using OnlineCourses.Core.Entities;

namespace OnlineCourses.Core.Interfaces;

public interface IAuthService
{
    Task<User> RegisterAsync(string nombre, string correo, string password, string rol);
    Task<AuthResult> LoginAsync(string correo, string password);
    Task<AuthResult> RefreshTokenAsync(string refreshToken);
}

public record AuthResult(string AccessToken, string RefreshToken, int ExpiresIn);
