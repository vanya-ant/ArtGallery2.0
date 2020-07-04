namespace ArtGallery.Orders.Data.Configuration
{
    using ArtGallery.Orders.Data.Models;
    using Microsoft.Data.SqlClient;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder
                .HasKey(oi => oi.Id);

            builder
                .Property(oi => oi.Name)
                .IsRequired()
                .HasMaxLength(DataConstants.OrderItem.MaxNameLength);

            builder
                .Property(oi => oi.ImageUrl)
                .IsRequired();

            builder
                .Property(oi => oi.Price)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder
                .Property(oi => oi.Quantity)
                .IsRequired();
        }
    }
}
