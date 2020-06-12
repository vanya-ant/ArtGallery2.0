namespace ArtGallery.Server.Data.Models
{
    public class Comment
    {
        public string Id { get; set; }

        public Article Article { get; set; }

        public string ArticleId { get; set; }

        public User Autor { get; set; }

        public string AuthorId { get; set; }
    }
}
