﻿namespace ArtGallery.Items.Data
{
    using ArtGallery.Items.Data.Models;
    using ArtGallery.Items.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.VisualBasic;
    using System.Reflection;

    public class ItemsDbContext : DbContext
    {
        public ItemsDbContext(DbContextOptions<ItemsDbContext> options)
            : base(options)
        {
        }

        public DbSet<Item> Items { get; set; }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
