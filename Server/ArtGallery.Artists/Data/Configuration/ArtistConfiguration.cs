namespace ArtGallery.Artists.Data.Configuration
{
    using ArtGallery.Artists.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ArtistConfiguration
    {
        public void Configure(EntityTypeBuilder<Artist> builder)
        {
            builder
                .HasKey(a => a.Id);


            builder
                .Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(10);

            builder
                .HasMany(a => a.Items)
                .WithOne(a => a.Author)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
