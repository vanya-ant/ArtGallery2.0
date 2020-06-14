namespace ArtGallery.Server.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class UserOrders
    {
        public virtual User User { get; set; }

        public string UserId { get; set; }

        public virtual Order Order { get; set; }
    
        public string OrderId { get; set; }
    }
}
