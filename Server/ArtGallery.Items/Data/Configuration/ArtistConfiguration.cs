﻿namespace ArtGallery.Items.Data.Configuration
{
    using ArtGallery.Items.Data.Models;
    using ArtGallery.Items.Models;
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
