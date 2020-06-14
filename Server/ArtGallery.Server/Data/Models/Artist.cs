namespace ArtGallery.Server.Data.Models
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Artist
    {
        public Artist()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Items = new HashSet<ArtistItems>();
        }

        [Key]
        public string Id { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public string Filed { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        public ICollection<ArtistItems> Items { get; set; }

    }
}
