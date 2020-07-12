namespace ArtGallery.Orders.Services.Orders
{
    using ArtGallery.Orders.Models;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public class OrderService : IOrderService
    {
        public Task<string> AddToCart()
        {
            throw new NotImplementedException();
        }

        public Task<string> DeleteItem(string itemId)
        {
            throw new NotImplementedException();
        }

        public Task<ShoppingCartOutputModel> Order()
        {
            throw new NotImplementedException();
        }
    }
}
