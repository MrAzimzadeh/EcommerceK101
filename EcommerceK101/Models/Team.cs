namespace EcommerceK101.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string PhotoUrl { get; set; }
        public string Name { get; set; }
        public int PositionId { get; set; }
        public Position Position { get; set; }
        public List<TeamsNetwork> TeamsNetworks { get; set; }
    }
}
