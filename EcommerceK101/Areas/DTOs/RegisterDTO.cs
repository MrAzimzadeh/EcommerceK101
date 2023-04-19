using System.ComponentModel.DataAnnotations;

namespace EcommerceK101.Areas.DTOs
{
    public class RegisterDTO
    {
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        [MinLength(3, ErrorMessage = "3 simvoldan cox olmalidir"), MaxLength(25, ErrorMessage = "max 25 simvoldan ibaret olmalidir ")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Surname is required.")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Pasword and password repead is not match.")]
        public string RepetPassword { get; set; }

    }
}
