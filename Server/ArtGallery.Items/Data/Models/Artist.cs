namespace ArtGallery.Items.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Artist
    {
        public Artist()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Items = new HashSet<Item>();
        }

        [Key]
        public string Id { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public Category Category { get; set; }

        public string CategoryId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        public ICollection<Item> Items { get; set; }
    }
}
