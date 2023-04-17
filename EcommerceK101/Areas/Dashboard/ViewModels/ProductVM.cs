using EcommerceK101.Models;
using WebApp.Models;

namespace EcommerceK101.Areas.Dashboard.ViewModels
{
    public class ProductVM
    {
        public Product Products { get; set; }
        public List<Category> Categories { get; set; }

    }
}
