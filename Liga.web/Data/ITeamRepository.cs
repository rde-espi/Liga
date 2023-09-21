using Liga.web.Models.Entity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace Liga.web.Data
{
    public interface ITeamRepository : IGenericRepository<TeamEntity>
    {
        public IQueryable GetAllWithUsers();
        IEnumerable<SelectListItem> GetComboTeams();

    }
}
