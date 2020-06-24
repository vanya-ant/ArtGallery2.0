using Microsoft.EntityFrameworkCore.Query;
using System;
using System.ComponentModel.DataAnnotations;

namespace ArtGallery.Server.Data.Models
{
    public class Item
    {
        public Item()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        public Artist Author { get; set; }

        [Required]
        public string AuthorId { get; set; }

        public Category Category { get; set; }

        [Required]
        public string CategoryId {get; set;}

        [Required]
        public string ImageUrl { get; set; }

        [MaxLength(300)]
        public string Description { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public decimal Price { get; set; }
    }
}
