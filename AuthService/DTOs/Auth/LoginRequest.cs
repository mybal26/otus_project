using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AuthService.DTOs;

/// <summary>
/// Модель запроса для аутентификации пользователя
/// </summary>
public class LoginRequest
{
    /// <summary>
    /// Логин пользователя (email или username)
    /// </summary>
    [Required(ErrorMessage = "Логин обязателен")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Логин должен быть от 3 до 50 символов")]
    [JsonPropertyName("login")]
    public required string Login { get; set; }

    /// <summary>
    /// Пароль пользователя
    /// </summary>
    [Required(ErrorMessage = "Пароль обязателен")]
    [StringLength(100, MinimumLength = 6, ErrorMessage = "Пароль должен быть от 6 до 100 символов")]
    [DataType(DataType.Password)]
    [JsonPropertyName("password")]
    public required string Password { get; set; }

    /// <summary>
    /// Конструктор для десериализации
    /// </summary>
    public LoginRequest() { }

    /// <summary>
    /// Конструктор с параметрами
    /// </summary>
    public LoginRequest(string login, string password)
    {
        Login = login;
        Password = password;
    }
}