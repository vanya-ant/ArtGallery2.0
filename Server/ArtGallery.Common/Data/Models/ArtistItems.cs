namespace ArtGallery.Server.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class ArtistItems
    {
        [Required]
        public string ArtistId { get; set; }

        public virtual Artist Artist { get; set; }

        [Required]
        public string ItemId { get; set; }

        public virtual Item Item { get; set; }
    }
}
