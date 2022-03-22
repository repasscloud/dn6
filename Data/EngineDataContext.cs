using Microsoft.EntityFrameworkCore;
using Models.Engine.Public;
using Models.Engine.Reference;
using Models.Engine.Private;


namespace EngineData
{
    public class EngineDataContext : DbContext
    {
        public EngineDataContext (DbContextOptions<EngineDataContext> options)
            : base(options)
        {
        }

        public DbSet<Application> Applications { get; set; }

        public DbSet<ExploitReport> ExploitReports { get; set; }
        public DbSet<VirusTotalScan> VirusTotalScans { get; set;}

        public DbSet<ApplicationCategory> ApplicationCategories { get; set; }
        public DbSet<BaseImage> BaseImages { get; set; }
        public DbSet<BaseImageEdition> BaseImageEditions { get; set; }
        public DbSet<BaseImageFileType> BaseImageFileTypes { get; set; }
        public DbSet<Executable> Executables { get; set; }
        public DbSet<UninstallProcess> UninstallProcesses { get; set; }
    }
}