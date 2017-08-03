using Microsoft.EntityFrameworkCore;
using GomelRectorCouncilWebApi.Models;

namespace GomelRectorCouncilWebApi.Data
{
    public class CouncilDbContext:DbContext
    {
        public CouncilDbContext(DbContextOptions<CouncilDbContext> options) : base(options)
        {}
        public DbSet<Rector> Rectors { get; set; }
        public DbSet<University> Universities { get; set; }
        public DbSet<Indicator> Indicators { get; set; }
        public DbSet<Achievement> Achievements { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Chairperson> Chairpersons { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
