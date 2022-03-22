using Microsoft.EntityFrameworkCore;
using Models.Shared;

namespace SharedData
{
    public class SharedDataContext : DbContext
    {
        public SharedDataContext (DbContextOptions<SharedDataContext> options)
            : base(options)
        {
        }

        public DbSet<CpuArch> CpuArches { get; set; }
        public DbSet<DetectionProcess> DetectionProcesses { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Locale> Locales { get; set; }
        public DbSet<PackageDetection> PackageDetections { get; set; }
        public DbSet<TransferMethod> TransferMethods { get; set; }
        public DbSet<Country> Countries { get; set; }
    }
}