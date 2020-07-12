namespace ArtGallery.Items.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Category
    {
        public Category()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Items = new HashSet<Item>();
        }

        [Key]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Item> Items { get; set; }

        public ICollection<Artist> Artists { get; set; }

    }
}