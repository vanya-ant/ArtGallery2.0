namespace ArtGallery.Items.Models
{
    using ArtGallery.Items.Data.Models;

    public class ItemInputModel
    {
        public string Name { get; set; }

        public string AuthorName { get; set; }

        public Category Category { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }
    }
}
