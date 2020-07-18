namespace ArtGallery.Artists.Models
{
    using ArtGallery.Artists.Data.Models;

    public class ArtistInputModel
    {
        public string ImageUrl { get; set; }

        public string Category { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }
    }
}
