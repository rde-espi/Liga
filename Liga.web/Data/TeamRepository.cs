using Liga.web.Models.Entity;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Liga.web.Data
{
    public class TeamRepository : GenericRepository<TeamEntity>,ITeamRepository
    {
        private readonly DataContext _context;

        public TeamRepository(DataContext dataContext) : base(dataContext)
        {
            _context = dataContext;
        }

        public IQueryable GetAllWithUsers()
        {
            return _context.Teams.Include(t => t.User);
        }
    }
}
