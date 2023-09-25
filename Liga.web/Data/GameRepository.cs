using Liga.web.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Liga.web.Data
{
    public class GameRepository : GenericRepository<Game>,IGameRepository
    {
        private readonly DataContext _context;
        public GameRepository(DataContext context) : base(context)
        {
            _context = context;
        }
        public IQueryable GetAllWithUsers()
        {
            return _context.GameDetailTemp.Include(t => t.User);
        }
    }
}
