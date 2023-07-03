using System.Collections.Generic;
using System.IO;

namespace Liga.web.Models.Entity
{
    public class TeamEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PathLogo { get; set; }

        public Dictionary<PlayerEntity, string> Players { get; set; }
    }
}
