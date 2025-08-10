namespace AuthService.DTOs.Auth;

public class AuthResponse
{
    public string Id { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Token { get; set; }
    public string RefreshToken { get; set; }
}