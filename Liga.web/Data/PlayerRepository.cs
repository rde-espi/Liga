using Liga.web.Models.Entity;

namespace Liga.web.Data
{
    public class PlayerRepository : GenericRepository<PlayerEntity>, IPlayerRepository
    {
        public PlayerRepository(DataContext dataContext) : base(dataContext)
        {

        }
    }
}
