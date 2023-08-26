using Liga.web.Data.Entity;
using Liga.web.Models.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Liga.web.Data
{
    public class DataContext : IdentityDbContext<User>
    {

        public DbSet<PlayerEntity> Players { get; set; }
        public DbSet<TeamEntity> Teams { get; set; }
        public DataContext(DbContextOptions<DataContext>options) : base(options)
        {

        }
    }
}
