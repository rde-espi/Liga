using Liga.web.Data.Entity;
using Liga.web.Helpers;
using Liga.web.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Liga.web.Data
{
    public class JourneyRepository : GenericRepository<Journey>,IJourneyRepository
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;

        public JourneyRepository(DataContext context, IUserHelper userHelper) : base(context)
        {
            _context = context;
            _userHelper = userHelper;
        }

        public async Task AddGameToJourneyAsync(AddItemsViewModel model, string userName)
        {
            var user = await _userHelper.GetUserByEmailAsync(userName);
            if(user == null)
            {
                return;
            }
            var teamA = await _context.Teams.FindAsync(model.TeamAId);
            var teamB = await _context.Teams.FindAsync(model.TeamBId);
            if(teamA == null || teamB == null)
            {
                return;
            }

            var game = await _context.GameDetailTemp
                .Where(g => g.User == user && g.TeamA == teamA && g.TeamB == teamB)
                .FirstOrDefaultAsync();

            if(game == null && teamA != teamB)
            {
                game = new GameDetailTemp
                {
                    User = user,
                   TeamA= teamA,
                   TeamB= teamB,
                   GolsTeamA=0,
                   GolsTeamB=0,
                   YellowCardA=0,
                   YellowCardB=0,
                   RedCardA=0,
                   RedCardB=0,
                   IsConcluded = false
                };
                _context.GameDetailTemp.Add(game);
            }
            else
            {
                game.IsConcluded = model.IsConcluded;
                _context.GameDetailTemp.Update(game);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<IQueryable<Journey>> GetJourneyAsync(string userName)
        {
            var user = await _userHelper.GetUserByEmailAsync(userName);
            if (user == null)
            {
                return null;
            }
            if(await _userHelper.IsUserInRoleAsync(user, "Admin"))
            {
                return _context.Journeys
                    .Include(u =>u.User)
                    .Include(j => j.Games)
                    .ThenInclude(t=>t.Teams)
                    .OrderByDescending(j => j.JourneyEnd);
            }
            return _context.Journeys
                 .Include(j => j.Games)
                 .ThenInclude(t=>t.Teams)
                    .Where(j => j.User == user)
                    .OrderByDescending(j => j.JourneyEnd);
        }

        public async Task<IQueryable<GameDetailTemp>> GetJourneyDetailTempsAsync(string userName)
        {
            var user = await _userHelper.GetUserByEmailAsync(userName);
            if (user == null)
            {
                return null;
            }
            return _context.GameDetailTemp
                .Include(g => g.TeamA)
                .Include(g => g.TeamB)
                .Where(u => u.User == user)
                .OrderBy(g => g.IsConcluded);
                
                
        }

        public async Task ModifyGameAsync(int id, bool isConclude)
        {
            var game = await _context.GameDetailTemp.FindAsync(id);
            if(game == null)
            {
                return;
            }
            game.IsConcluded = isConclude;
            _context.GameDetailTemp.Update(game);
            await _context.SaveChangesAsync();
        }
    }
}
