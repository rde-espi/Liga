using Liga.web.Models;
using Liga.web.Models.Entity;

namespace Liga.web.Helpers
{
    public interface IConverterHelper
    {
        TeamEntity ToTeam(TeamViewModel model,string path, bool isNew);
        TeamViewModel ToTeamViewModel(TeamEntity team);
        
    }
}
