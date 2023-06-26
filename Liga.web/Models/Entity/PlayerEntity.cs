namespace Liga.web.Models.Entity
{
    public class PlayerEntity : IPlayerEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Team PlayerTeam { get; set; }

    }
}
