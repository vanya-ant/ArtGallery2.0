namespace ArtGallery.Items.Models
{
    using ArtGallery.Items.Data.Models;

    public class ArtistInputModel
    {
        public string ImageUrl { get; set; }

        public Category Category { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }
    }
}
