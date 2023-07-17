namespace Liga.web.Models.Entity
{
    public class PlayerEntity : IPlayerEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TeamEntity PlayerTeam { get; set; }

    }
}
