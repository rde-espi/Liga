using Liga.web.Data.Entity;
using Liga.web.Helpers;
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
                    .Include(j => j.Games)
                    .ThenInclude(g => g.Games)
                    .OrderByDescending(j => j.JourneyEnd);
            }
            return _context.Journeys
                 .Include(j => j.Games)
                    .ThenInclude(g => g.Games)
                    .Where(j => j.User == user)
                    .OrderByDescending(j => j.JourneyStart);
        }

        public async Task<IQueryable<JourneyDetailTemp>> GetJourneyDetailTempAsync(string userName)
        {
            var user = await _userHelper.GetUserByEmailAsync(userName);
            if (user == null)
            {
                return null;
            }
            return _context.journeyDetailTemp
                .Include(g => g.Games)
                .Where(u => u.User == user);
                
                
        }
    }
}
