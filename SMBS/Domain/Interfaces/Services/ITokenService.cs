using Microsoft.AspNetCore.Identity;

public interface ITokenService
{
    string CreateToken(ApplicationUser user, IdentityRole role);
}