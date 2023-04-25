namespace EcommerceK101.Models
{
    public class ArticleTag
    {
        public int Id { get; set; }
        public int ArtcleId { get; set; }
        public Article Article { get; set; }
        public int TagId { get; set; }
        public Tag Tag { get; set; }


    }
}
