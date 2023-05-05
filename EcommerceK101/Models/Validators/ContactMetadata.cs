
using System.ComponentModel.DataAnnotations;

namespace EcommerceK101.Models
{
    public class ContactMetadata
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MinLength(5), MaxLength(20)]
        public string Subject { get; set; }
        [MaxLength(250)]
        public string Message { get; set; }
    }
}