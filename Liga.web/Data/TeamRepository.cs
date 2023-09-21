using Liga.web.Models.Entity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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

        public IEnumerable<SelectListItem> GetComboTeams()
        {
            var list= _context.Teams.Select(t => new SelectListItem
            {
                Text = t.Name,
                Value=t.Id.ToString()
            }).ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "(Select a Team...)",
                Value = "0"
            });
            return list;
        }
    }
}
