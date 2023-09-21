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
        public DbSet<JourneyDetail>JourneyDetails { get; set; } 
        public DbSet<JourneyDetailTemp>journeyDetailTemp { get; set; }
        public DataContext(DbContextOptions<DataContext>options) : base(options)
        {

        }
        public DbSet<Liga.web.Data.Entity.Game> Game { get; set; }
    }
}
