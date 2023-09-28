using Liga.web.Data.Entity;
using Liga.web.Models.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Liga.web.Data
{
    public class DataContext : IdentityDbContext<User>
    {

        public DbSet<PlayerEntity> Players { get; set; }
        public DbSet<TeamEntity> Teams { get; set; }
        public DbSet<Journey> Journeys { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<GameDetailTemp> GameDetailTemp { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Liga.web.Data.Entity.Game> Game { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    var cascadeFKs = modelBuilder.Model
        //        .GetEntityTypes()
        //        .SelectMany(t => t.GetForeignKeys())
        //        .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

        //    foreach (var fk in cascadeFKs)
        //    {
        //        fk.DeleteBehavior = DeleteBehavior.Restrict;
        //    }
        //    base.OnModelCreating(modelBuilder);
        //}

    }
}
