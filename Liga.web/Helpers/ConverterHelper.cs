using Liga.web.Models;
using Liga.web.Models.Entity;
using System;
using System.IO;

namespace Liga.web.Helpers
{
    public class ConverterHelper : IConverterHelper
    {
        public TeamEntity ToTeam(TeamViewModel model,Guid imageId ,bool isNew)
        {
            return new TeamEntity
            {

                Id = isNew ? 0 : model.Id,
                Name = model.Name,
                ImageId = imageId,
                User = model.User
            };
        }

        public TeamViewModel ToTeamViewModel(TeamEntity teamEntity)
        {
            return new TeamViewModel
            {
                Id = teamEntity.Id,
                Name = teamEntity.Name,
                ImageId = teamEntity.ImageId,
                User = teamEntity.User
            };
        }
    }
}
