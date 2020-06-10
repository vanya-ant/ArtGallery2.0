namespace ArtGallery.Server.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Article
    {
        public string Id { get; set; }

        public string Author { get; set; }

        public string Content { get; set; }

        public DateTime Date { get; set; }

        public string Title { get; set; }
    }
}
