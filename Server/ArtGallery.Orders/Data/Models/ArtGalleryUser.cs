namespace ArtGallery.Orders.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;

    public class ArtGalleryUser : IdentityUser
    {
        public ArtGalleryUser()
        {
            this.Orders = new HashSet<Order>();
        }

        public ICollection<Order> Orders { get; set; }
    }
}
