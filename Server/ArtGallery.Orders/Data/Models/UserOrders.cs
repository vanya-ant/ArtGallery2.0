namespace ArtGallery.Orders.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class UserOrders
    {
        public virtual ArtGalleryUser User { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual Order Order { get; set; }

        [Required]
        public string OrderId { get; set; }
    }
}
