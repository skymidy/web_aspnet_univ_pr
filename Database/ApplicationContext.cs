using ASPnetWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPnetWebApp.Database;

public class ApplicationContext : DbContext 
{
    public DbSet<User> Users { get; set; } 
    public DbSet<UserProfile> UsersProfile { get; set; } 
    public DbSet<PairRecord> PairRecords { get; set; } 
    public ApplicationContext(DbContextOptions<ApplicationContext> contextOptions) : base(contextOptions)
    {
        Database.EnsureCreated();
    }
}