namespace ArtGallery.Blog.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Article
    {   
        public Article()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Key]
        public string Id { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public DateTime Date { get; set; } = DateTime.Now;

        [Required]
        public string Title { get; set; }
    }
}
