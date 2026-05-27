
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class AppContext : IdentityDbContext<ApplicationUser>
{
    public AppContext(DbContextOptions<AppContext> options) : base(options)
    {
    }

    public DbSet<UserStatus> UserStatuses { get; set; }
}