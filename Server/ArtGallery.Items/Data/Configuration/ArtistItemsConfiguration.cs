namespace ArtGallery.Items.Data.Configuration
{
    using ArtGallery.Items.Models;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ArtistItemsConfiguration
    {
        public void Configure(EntityTypeBuilder<ArtistItems> builder)
        {
            builder
                .HasKey(ai => new { ai.ArtistId, ai.ItemId });
        }
    }
}
