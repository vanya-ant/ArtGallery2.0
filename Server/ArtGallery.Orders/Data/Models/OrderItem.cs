namespace ArtGallery.Orders.Data.Models
{
    using System;

    public class OrderItem
    {
        public OrderItem()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public string ItemId { get; set; }

        public decimal Price { get; set; }

        public string ImageUrl { get; set; }

        public int Quantity { get; set; }
    }
}
