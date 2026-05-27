public interface IUserRepository
{
    bool IsUniqueEmail(string email);
    Task<ApplicationUser?> Register(ApplicationUser user);
    Task<ApplicationUser?> Login(ApplicationUser user);
    ApplicationUser? GetUser(string id);
}