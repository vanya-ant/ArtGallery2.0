namespace ArtGallery.Server.Data.Models
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Artist
    {
        public Artist()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Items = new HashSet<ArtistItems>();
        }

        public string Id { get; set; }

        public string ImageUrl { get; set; }

        public string Filed { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public ICollection<ArtistItems> Items { get; set; }

    }
}
