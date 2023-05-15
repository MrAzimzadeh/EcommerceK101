using Microsoft.AspNetCore.Mvc;

namespace EcommerceK101.Models
{
    [ModelMetadataType(typeof(ContactMetadata))]
    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }

        //testemonia ucun elave sadece admin
        public bool IsPopular { get; set; }

    }
}
