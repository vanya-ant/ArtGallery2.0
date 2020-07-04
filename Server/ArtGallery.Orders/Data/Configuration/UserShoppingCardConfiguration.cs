namespace ArtGallery.Orders.Data.Configuration
{
    using ArtGallery.Items.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class UserShoppingCardConfiguration : IEntityTypeConfiguration<UserShoppingCart>
    {
        public void Configure(EntityTypeBuilder<UserShoppingCart> builder)
        {
            builder
                .HasKey(usc => usc.UserId);

            builder
                .Property(usc => usc.UserId)
                .IsRequired();

            builder
                .HasMany(usc => usc.Items);
        }
    }
}
