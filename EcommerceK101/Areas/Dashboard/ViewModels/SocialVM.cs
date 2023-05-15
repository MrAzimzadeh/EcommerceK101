using EcommerceK101.Models;

namespace EcommerceK101.Areas.Dashboard.ViewModels
{
    public class SocialVM
    {
        //public int Id { get; set; }
        public Team Team { get; set; }
        public List<SocialNetwork> SocialNetworks { get; set; }

        public List<TeamsNetwork> TeamsNetworks { get; set; }
        

    }
}
