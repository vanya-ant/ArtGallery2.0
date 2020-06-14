namespace ArtGallery.Server.Data
{
    using ArtGallery.Server.Data.Models;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class ArtGalleryDbContext : IdentityDbContext<User>
    {
        public ArtGalleryDbContext(DbContextOptions<ArtGalleryDbContext> options) : base(options)
        { }

        public DbSet<Item> Items { get; set; }

        public DbSet<Artist> Attists { get; set; }

        public DbSet<Article> Articles { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<ArtistItems> ArtistItems {get; set;}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Artist>()
                .HasKey(a => a.Id);

            builder.Entity<Artist>()
                .HasMany(a => a.Items)
                .WithOne(a => a.Artist);

            builder.Entity<ArtistItems>()
                .HasKey(ai => new { ai.ArtistId, ai.ItemId });

            builder.Entity<ArtistItems>()
                .HasOne(a => a.Artist)
                .WithMany(a => a.Items)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Article>()
                .HasKey(a => a.Id);

            builder.Entity<Order>()
                .HasKey(o => o.Id);

            builder.Entity<Order>()
                .HasOne(o => o.Buyer);
            builder.Entity<Order>()
                .HasMany(o => o.Items);

            builder.Entity<User>()
                .HasKey(u => u.Id);

            builder.Entity<UserOrders>()
                .HasKey(uo => new { uo.UserId, uo.OrderId });

            builder.Entity<UserOrders>()
                .HasOne(uo => uo.User)
                .WithMany(u => u.Orders);

            builder.Entity<Item>()
                .HasKey(i => i.Id);

            builder.Entity<Item>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,4)");

            base.OnModelCreating(builder);
        }
    }
}
