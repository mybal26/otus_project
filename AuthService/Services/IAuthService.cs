using AuthService.DTOs;

namespace AuthService.Services;

public interface IAuthService
{
    public Task<string> RegisterAsync(RegisterRequest request);
    public Task<string> LoginAsync(string email, string password);

}