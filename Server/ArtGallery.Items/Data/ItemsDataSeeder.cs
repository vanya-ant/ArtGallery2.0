namespace ArtGallery.Items.Data
{
    using ArtGallery.Common.Servcies;
    using ArtGallery.Items.Models;
    using System.Collections.Generic;
    using System.Linq;

    class ItemsDataSeeder : IDataSeeder
    {
        private static IEnumerable<Category> GetData()
           => new List<Category>
           {
                new Category{ Name = "Paintings" },
                new Category{ Name = "Photography"},
                new Category{ Name = "Illustration"},
                new Category{ Name = "Sculpture"},
                 new Category{ Name = "Prints" },
                new Category{ Name = "Textile"},
                new Category{ Name = "Design"},
                new Category{ Name = "Jewelery"},
           };

        private readonly ItemsDbContext db;

        public ItemsDataSeeder(ItemsDbContext db) => this.db = db;

        public void SeedData()
        {
            if (this.db.Categories.Any())
            {
                return;
            }

            foreach (var category in GetData())
            {
                this.db.Categories.Add(category);
            }

            this.db.SaveChanges();
        }
    }
}
