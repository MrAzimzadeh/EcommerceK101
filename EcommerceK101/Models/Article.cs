﻿namespace EcommerceK101.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string PhotoUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public List<Tag> Tags { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}