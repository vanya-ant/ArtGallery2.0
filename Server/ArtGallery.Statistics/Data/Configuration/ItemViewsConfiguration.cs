namespace ArtGallery.Statistics.Data.Configuration
{
    using ArtGallery.Statistics.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ItemViewsConfiguration : IEntityTypeConfiguration<ItemView>
    {
        public void Configure(EntityTypeBuilder<ItemView> builder)
        {
            builder
                .HasKey(s => s.Id);


            builder
                .HasIndex(v => v.ItemId);

            builder
                .Property(s => s.ArtGallleryUserId)
                .IsRequired();
        }
    }
}
