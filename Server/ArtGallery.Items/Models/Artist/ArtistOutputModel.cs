﻿namespace ArtGallery.Items.Models
{
    using ArtGallery.Items.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ArtistOutputModel
    {
        public string Id { get; }

        public string ImageUrl { get; set; }

        public Category Category { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public ICollection<Item> Items { get; set; }
    }
}
