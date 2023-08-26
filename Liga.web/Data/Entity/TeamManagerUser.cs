using Liga.web.Models.Entity;

namespace Liga.web.Data.Entity
{
    public class TeamManagerUser:User
    {
        public TeamEntity Team { get; set; }
    }
}
