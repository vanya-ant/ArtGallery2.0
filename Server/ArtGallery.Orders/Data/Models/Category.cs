namespace ArtGallery.Orders.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class Category
    {
    
        [Key]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Item> Items { get; set; }

        public ICollection<Artist> Artists { get; set; }

    }
}
