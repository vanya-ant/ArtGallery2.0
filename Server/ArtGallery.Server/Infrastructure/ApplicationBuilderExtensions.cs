namespace ArtGallery.Server.Infrastructure
{
    using ArtGallery.Server.Data;
    using ArtGallery.Server.Data.Models;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using System.Collections.Generic;
    using System.Linq;

    public static class ApplicationBuilderExtensions
    {
        private static IEnumerable<Category> GetData()
               => new List<Category>
               {
                new Category{ Name = "Paintings" },
                new Category{ Name = "Photography" },
                new Category{ Name = "Illustration" },
                new Category{ Name = "Sculpture" },
                new Category{ Name = "Prints" },
                new Category{ Name = "Textile" }
               };

        public static IApplicationBuilder Initialize(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            var serviceProvider = serviceScope.ServiceProvider;

            var db = serviceProvider.GetRequiredService<ArtGalleryDbContext>();

            db.Database.Migrate();

            if (db.Categories.Any())
            {
                return app;
            }

            foreach (var category in GetData())
            {
                db.Categories.Add(category);
            }

            db.SaveChanges();

            return app;
        }
    }
}
