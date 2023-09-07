using Liga.web.Data.Entity;
using Liga.web.Helpers;
using Liga.web.Models.Entity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Liga.web.Data
{
    public class SeedDb
    {
        private readonly DataContext _dataContext;
        private readonly IUserHelper _userHelper;
        private Random _random;


        public SeedDb(DataContext dataContext,IUserHelper userHelper)
        {
            _dataContext = dataContext;
            _userHelper = userHelper;
            _random = new Random();
        }

        public async Task SeedAsync()
        {
            await _dataContext.Database.EnsureCreatedAsync();


            await _userHelper.CheckRoleAsync("Admin");
            //await _userHelper.CheckRoleAsync("Player");
            await _userHelper.CheckRoleAsync("TeamManager");
            await _userHelper.CheckRoleAsync("Employee");

            var user = await _userHelper.GetUserByEmailAsync("reinaldo_7531@hotmail.com");
            if (user == null)
            {
                user = new User
                {
                    FirstName = "Reinaldo",
                    LastName = "Souza",
                    Email = "reinaldo_7531@hotmail.com",
                    UserName = "reinaldo_7531@hotmail.com",
                    PhoneNumber="123456789"
                };
                var result=await _userHelper.AddUserAsync(user,"123456");
                if(result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create user in seeder");
                }

                await _userHelper.AddUserToRoleAsync(user,"Admin");

            }

            var isInRole = await _userHelper.IsUserInRoleAsync(user, "admin");
            if (!isInRole)
            {
                await _userHelper.AddUserToRoleAsync(user, "Admin");

            }

            if (!_dataContext.Teams.Any())
            {
                AddTeams("Barcelona",user);
                AddTeams("Real Madrid",user);
                AddTeams("Benfica",user);
                AddTeams("Porto FC",user);
                AddTeams("Flamengo",user);
                AddTeams("Palmeiras",user);
                AddTeams("Liverpool",user);
                AddTeams("Arsenal",user);
                AddTeams("PSG",user);
                AddTeams("Juventus",user);
                await _dataContext.SaveChangesAsync();
            }
        }

        private void addPlayers()
        {
            throw new NotImplementedException();
        }

        private void AddTeams(string name,User user)
        {
            _dataContext.Teams.Add(new TeamEntity
            {
                Name= name,
                User= user
            });
        }
    }
}
