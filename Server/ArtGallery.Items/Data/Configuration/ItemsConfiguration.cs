﻿namespace ArtGallery.Items.Data.Configuration
{
    using ArtGallery.Items.Data.Models;
    using ArtGallery.Items.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System.Linq;

    public class ItemsConfiguration : IEntityTypeConfiguration<Item>
    {   
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder
                .HasKey(c => c.Id);

            builder
                .Property(i => i.Description)
                .IsRequired()
                .HasMaxLength(DataConstants.Item.MaxDescriptionLength);

            builder
              .Property(i => i.ImageUrl)
              .IsRequired();

            builder
             .Property(i => i.CategoryId)
             .IsRequired();

            builder
                .Property(i => i.AuthorName)
                .IsRequired();

            builder
                .Property(i => i.Name)
                .IsRequired()
                .HasMaxLength(DataConstants.Item.MaxNameLength);

            builder
                .Property(i => i.Price)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

        }
    }
}
