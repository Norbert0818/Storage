using CoreBuisness.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace StorageSystem.Data;

public class AccountContext : IdentityDbContext<AppUser>
{
    public AccountContext(DbContextOptions<AccountContext> options)
        : base(options)
    {
    }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Worker> Workers { get; set; }
    public DbSet<AppUser> Customers { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
