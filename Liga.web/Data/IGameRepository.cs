using Liga.web.Data.Entity;
using System.Linq;

namespace Liga.web.Data
{
    public interface IGameRepository : IGenericRepository<Game>
    {
        public IQueryable GetAllWithUsers();
}
    
}
