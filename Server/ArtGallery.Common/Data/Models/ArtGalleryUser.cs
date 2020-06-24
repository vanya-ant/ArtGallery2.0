namespace ArtGallery.Server.Data.Models
{
    using System.Collections.Generic;

    public class ArtGalleryUser
    {
        public ArtGalleryUser()
        {
            this.Orders = new HashSet<UserOrders>();
        }

        public string Id { get; set; }

        public string Email { get; set; }

        public string UserId { get; set; }

        public ICollection<UserOrders> Orders { get; set; }
    }
}
