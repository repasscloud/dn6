using Microsoft.EntityFrameworkCore;
using Models.Engine.Public;
using Models.Engine.Reference;

namespace ApplicationData
{
    public class EngineDataContext : DbContext
    {
        public EngineDataContext (DbContextOptions<EngineDataContext> options)
            : base(options)
        {
        }

        public DbSet<Application> Applications { get; set; }
    }
}