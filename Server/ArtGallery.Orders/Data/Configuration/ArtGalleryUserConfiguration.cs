namespace ArtGallery.Orders.Data.Configuration
{
    using ArtGallery.Orders.Data.Models;
    using Microsoft.Data.SqlClient;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ArtGalleryUserConfiguration : IEntityTypeConfiguration<ArtGalleryUser>
    {
        public void Configure(EntityTypeBuilder<ArtGalleryUser> builder)
        {
            builder
                .HasKey(u => u.Id);

            builder
                .HasMany(u => u.Orders);
        }
    }
}
