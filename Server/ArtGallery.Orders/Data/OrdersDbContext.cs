﻿namespace ArtGallery.Orders.Data
{
    using ArtGallery.Items.Data.Models;
    using ArtGallery.Orders.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Reflection;

    public class OrdersDbContext : DbContext
    {
        public OrdersDbContext(DbContextOptions<OrdersDbContext> options)
    : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<UserShoppingCart> ShoppingCarts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
