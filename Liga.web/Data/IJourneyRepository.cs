using Liga.web.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Liga.web.Data
{
    public interface IJourneyRepository : IGenericRepository<Journey>
    {
        Task<IQueryable<Journey>>GetJourneyAsync(string userName);
        Task<IQueryable<JourneyDetailTemp>> GetJourneyDetailTempAsync(string userName);
    }
}
