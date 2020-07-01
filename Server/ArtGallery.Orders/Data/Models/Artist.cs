namespace ArtGallery.Orders.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Artist
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public Category Category { get; set; }

        public string CategoryID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        public ICollection<ArtistItems> Items { get; set; }
    }
}
