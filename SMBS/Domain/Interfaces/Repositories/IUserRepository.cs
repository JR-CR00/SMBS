using Application.DTOs.Users.Requests;
using Application.DTOs.Users.Responses;

public interface IUserRepository
{
    bool IsUniqueEmail(string email);
    Task<ApplicationUser?> Register(ApplicationUser user);
    Task<UserLoginResponseDto?> Login(UserLoginDto user);
    ApplicationUser? GetUser(string id);
}