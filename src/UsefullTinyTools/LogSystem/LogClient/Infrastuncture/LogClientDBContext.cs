using LogClient.Domain.Entity;
using LogClient.Infrastuncture.Core;
using Microsoft.EntityFrameworkCore;

namespace LogClient.Infrastuncture
{
    public class LogClientDBContext : EfCoreDbContext
    {
        protected DbSet<StudentTrackLog> StudentTrackLog { get; set; }
        public LogClientDBContext( DbContextOptions<LogClientDBContext> options ) : base(options)
        {

        }
        protected override void OnModelCreating( ModelBuilder builder )
        {
            base.OnModelCreating(builder);
        }
    }
}
