public class UserRepository : IUserRepository
{
    public readonly AppContext _db;

    public UserRepository(AppContext db)
    {
        _db = db;   
    }
    public ApplicationUser? GetUser(string id)
    {
        return _db.Users.FirstOrDefault(u => u.Id == id);
    }

    public bool IsUniqueEmail(string email)
    {
        return !_db.Users.Any(u => u.Email != null && u.Email.Trim().ToLower() == email.Trim().ToLower());
    }

    public Task<ApplicationUser?> Register(ApplicationUser user)
    {
        throw new NotImplementedException();
    }

    public Task<ApplicationUser?> Login(ApplicationUser user)
    {
        throw new NotImplementedException();
    }
}