namespace ArtGallery.Statistics.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using ArtGallery.Statistics.Data.Models;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class StatisticsConfiguration : IEntityTypeConfiguration<Statistics>
    {
        public void Configure(EntityTypeBuilder<Statistics> builder)
        {
            builder
                .HasKey(s => s.Id);

            builder
                .Property(s => s.TotalItems)
                .IsRequired();
        }
    }
}
