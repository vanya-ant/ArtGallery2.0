namespace ArtGallery.Server.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;
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
