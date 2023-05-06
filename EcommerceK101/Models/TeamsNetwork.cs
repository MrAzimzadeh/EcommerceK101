namespace EcommerceK101.Models
{
    public class TeamsNetwork
    {
        public  int Id { get; set; }
        public string UserUrl { get; set; }
        public int TeamId { get; set; }
        public Team Team { get; set; }
        public int SocialNetworkId { get; set; }
        public SocialNetwork SocialNetwork { get; set; }
    }
}
