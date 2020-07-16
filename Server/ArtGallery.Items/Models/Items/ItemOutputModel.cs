using ArtGallery.Items.Data.Models;

namespace ArtGallery.Items.Models
{
    public class ItemOutputModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Author { get; set; }

        public Category Category { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }
    }
}
