using Liga.web.Models;
using Liga.web.Models.Entity;
using System.IO;

namespace Liga.web.Helpers
{
    public class ConverterHelper : IConverterHelper
    {
        public TeamEntity ToTeam(TeamViewModel model,string path ,bool isNew)
        {
            return new TeamEntity
            {
                Id = isNew ? 0 : model.Id,
                Name = model.Name,
                PathLogo = path,
                User = model.User
            };
        }

        public TeamViewModel ToTeamViewModel(TeamEntity teamEntity)
        {
            return new TeamViewModel
            {
                Id = teamEntity.Id,
                Name = teamEntity.Name,
                PathLogo = teamEntity.PathLogo,
                User = teamEntity.User
            };
        }
    }
}
