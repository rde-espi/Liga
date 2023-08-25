using Liga.web.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace Liga.web.Data
{
    public class DataContext : DbContext
    {

        public DbSet<PlayerEntity> Players { get; set; }
        public DbSet<TeamEntity> Teams { get; set; }
        public DataContext(DbContextOptions<DataContext>options) : base(options)
        {

        }
    }
}
