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
        public DbSet<Journey>Journeys { get; set; }
        public DbSet<Game>Games { get; set; }
        public DbSet<GameDetailTemp>GameDetailTemp { get; set; }
        public DataContext(DbContextOptions<DataContext>options) : base(options)
        {

        }
        public DbSet<Liga.web.Data.Entity.Game> Game { get; set; }
    }
}
