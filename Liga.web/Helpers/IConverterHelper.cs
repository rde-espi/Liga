using Liga.web.Models;
using Liga.web.Models.Entity;
using System;

namespace Liga.web.Helpers
{
    public interface IConverterHelper
    {
        TeamEntity ToTeam(TeamViewModel model,Guid imageId, bool isNew);
        TeamViewModel ToTeamViewModel(TeamEntity team);
        
    }
}
