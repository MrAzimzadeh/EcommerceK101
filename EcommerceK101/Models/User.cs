using Microsoft.AspNetCore.Identity;

namespace EcommerceK101.Models
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string PhotoUrl { get; set; }

    }
}
