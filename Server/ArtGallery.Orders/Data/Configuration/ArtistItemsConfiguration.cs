namespace ArtGallery.Orders.Data.Configuration
{
    using ArtGallery.Orders.Data.Models;
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
