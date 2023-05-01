using EcommerceK101.Models;

namespace EcommerceK101.Areas.Dashboard.ViewModels
{
    public class ArticleVM
    {
        public Article Article { get; set; }
        public List<Tag> Tags { get; set; }
    }
}
