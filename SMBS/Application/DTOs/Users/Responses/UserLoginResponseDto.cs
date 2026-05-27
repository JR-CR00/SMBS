namespace Application.DTOs.Users.Responses;

public class UserLoginResponseDto
{
    public UserDto? User { get; set; }
    public string? Token { get; set; }
    public string? Message { get; set; }
    public int StatusCode { get; set; }
}