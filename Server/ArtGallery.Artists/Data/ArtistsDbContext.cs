namespace ArtGallery.Artists.Data
{
    using ArtGallery.Artists.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Reflection;


    public class ArtistsDbContext : DbContext
    {
        public ArtistsDbContext(DbContextOptions<ArtistsDbContext> options)
            : base(options)
        {
        }

        public DbSet<Item> Items { get; set; }

        public DbSet<Artist> Artists { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
