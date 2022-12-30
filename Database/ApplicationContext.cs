using ASPnetWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPnetWebApp.Database;

public class ApplicationContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<UserProfile> UsersProfile { get; set; } = null!; 
    public DbSet<PairRecord> PairRecords { get; set; } = null!; 
    public ApplicationContext(DbContextOptions<ApplicationContext> contextOptions) : base(contextOptions)
    {
        // Database.EnsureDeleted();
        Database.EnsureCreated();
    }
}