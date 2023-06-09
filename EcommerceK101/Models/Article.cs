﻿using System.ComponentModel.DataAnnotations;

namespace EcommerceK101.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string PhotoUrl { get; set; }
        [Required]
        [MinLength(5, ErrorMessage = "Title min  5 simvol")]
        public string Title { get; set; }
        public string Description { get; set; }
        public string SeoUrl { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public virtual List<ArticleTag> ArticleTags{ get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public bool IsPopular { get; set; }
        public string CoverPhoto { get; set; }
    }
}
