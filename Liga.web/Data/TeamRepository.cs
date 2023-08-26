using Liga.web.Models.Entity;

namespace Liga.web.Data
{
    public class TeamRepository : GenericRepository<TeamEntity>,ITeamRepository
    {
        private readonly DataContext _context;

        public TeamRepository(DataContext dataContext) : base(dataContext)
        {
            _context = dataContext;
        }
    }
}
