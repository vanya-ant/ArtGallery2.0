namespace ArtGallery.Artists.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    public class Item
    {
        public Item()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public Artist Author { get; set; }

        [Required]
        public string AuthorId { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        [RegularExpression(DataConstants.Item.ImageUrlRegularExpression)]
        public string ImageUrl { get; set; }

        [MaxLength(300)]
        public string Description { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public decimal Price { get; set; }
    }
}
