namespace ArtGallery.Items.Data.Models
{
    using ArtGallery.Orders.Data.Models;
    using Microsoft.EntityFrameworkCore.Migrations;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Text;

    public class UserShoppingCart
    {
        public UserShoppingCart(string userId)
        {
            this.UserId = userId;
            this.Items = new HashSet<OrderItem>();
        }

        public string UserId { get; set; }

        public ICollection<OrderItem> Items { get; set; }

    }
}
