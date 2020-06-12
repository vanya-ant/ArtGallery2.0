namespace ArtGallery.Server.Data
{
    using ArtGallery.Server.Data.Models;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class ArtGalleryDbContext : IdentityDbContext<User>
    {
        public ArtGalleryDbContext(DbContextOptions<ArtGalleryDbContext> options) : base(options)
        {}

        public DbSet<Item> Items { get; set; }

        public DbSet<Artist> Attists { get; set; }

        public DbSet<Article> Articles { get; set; }

        public DbSet<Comment> Comments { get; set; }
       
    }
}
