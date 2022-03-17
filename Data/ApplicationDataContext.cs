using Microsoft.EntityFrameworkCore;
using Models.Engine.Public;

namespace ApplicationData
{
    public class ApplicationDataContext : DbContext
    {
        public ApplicationDataContext (DbContextOptions<ApplicationDataContext> options)
            : base(options)
        {
        }

        public DbSet<Application> Applications { get; set; }
    }
}