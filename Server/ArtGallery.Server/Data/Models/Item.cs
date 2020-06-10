namespace ArtGallery.Server.Data.Models
{
    public class Item
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public Artist Author { get; set; }
   
        public string AutorId { get; set; }
    
        public string Category { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }
    }
}
