namespace ArtGallery.Orders.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Order
    {
        public Order()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Items = new HashSet<OrderItem>();
        }

        [Key]
        public string Id { get; set; }

        [Required]
        public ICollection<OrderItem> Items { get; set; }

        public ArtGalleryUser Buyer { get; set; }

        public string BuyerId { get; set; }
    }
}
