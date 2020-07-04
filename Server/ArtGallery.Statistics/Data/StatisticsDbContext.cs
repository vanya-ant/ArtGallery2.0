﻿namespace ArtGallery.Statistics.Data
{
    using ArtGallery.Statistics.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Reflection;

    public class StatisticsDbContext : DbContext
    {
        public StatisticsDbContext(DbContextOptions<StatisticsDbContext> options)
       : base(options)
        {
        }

        public DbSet<ItemView> ItemViews { get; set; }

        public DbSet<Statistics> Statistics { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}

