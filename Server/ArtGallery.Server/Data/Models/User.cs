namespace ArtGallery.Server.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.Collections;
    using System.Collections.Generic;

    public class User : IdentityUser
    {
        public User()
        {
            this.Orders = new HashSet<UserOrders>();
        }

        public ICollection<UserOrders> Orders { get; set; }
    }
}
