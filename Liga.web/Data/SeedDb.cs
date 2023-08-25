using Liga.web.Models.Entity;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Liga.web.Data
{
    public class SeedDb
    {
        private readonly DataContext _dataContext;
        private Random _random;
        public SeedDb(DataContext dataContext)
        {
            _dataContext = dataContext;
            _random = new Random();
        }

        public async Task SeedAsync()
        {
            await _dataContext.Database.EnsureCreatedAsync();

            if(!_dataContext.Teams.Any())
            {
                AddTeams("Barcelona");
                AddTeams("Real Madrid");
                AddTeams("Benfica");
                AddTeams("Porto FC");
                AddTeams("Flamengo");
                AddTeams("Palmeiras");
                AddTeams("Liverpool");
                AddTeams("Arsenal");
                AddTeams("PSG");
                AddTeams("Juventus");
                await _dataContext.SaveChangesAsync();
            }
        }

        private void addPlayers()
        {
            throw new NotImplementedException();
        }

        private void AddTeams(string name)
        {
            _dataContext.Teams.Add(new TeamEntity
            {
                Name= name
            });
        }
    }
}
