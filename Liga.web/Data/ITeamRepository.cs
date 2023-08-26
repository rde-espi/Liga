using Liga.web.Models.Entity;
using System.Linq;

namespace Liga.web.Data
{
    public interface ITeamRepository : IGenericRepository<TeamEntity>
    {
        public IQueryable GetAllWithUsers();
    }
}
