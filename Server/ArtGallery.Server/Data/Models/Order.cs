﻿
namespace ArtGallery.Server.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Order
    {
        public Order()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Items = new HashSet<ArtistItems>();
        }

        public string Id { get; set; }

        public ICollection<ArtistItems> Items { get; set; }

        public User Buyer { get; set; }
    }
}
