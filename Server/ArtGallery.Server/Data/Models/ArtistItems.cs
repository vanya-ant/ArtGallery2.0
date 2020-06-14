namespace ArtGallery.Server.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ArtistItems
    {
        public string ArtistId { get; set; }

        public virtual Artist Artist { get; set; }

        public string ItemId { get; set; }

        public virtual Item Item { get; set; }
    }
}
