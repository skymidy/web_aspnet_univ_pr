using Microsoft.EntityFrameworkCore;

namespace ASPnetWebApp.Repositories;

public class ApplicationContext : DbContext 
{
    public ApplicationContext(DbContextOptions<ApplicationContext> contextOptions) : base(contextOptions)
    {
        
    }
}