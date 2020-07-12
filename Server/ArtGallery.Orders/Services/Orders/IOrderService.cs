namespace ArtGallery.Orders.Services.Orders
{
    using ArtGallery.Orders.Models;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface IOrderService
    {
        public Task<string> AddToCart();

        public Task<ShoppingCartOutputModel> Order();

        public Task<string> DeleteItem(string itemId);
    }
}
