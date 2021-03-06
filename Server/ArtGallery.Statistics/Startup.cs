﻿namespace ArtGallery.Statistics
{
    using ArtGallery.Common.Infrastructure;
    using ArtGallery.Statistics.Data;
    using ArtGallery.Statistics.Messages;
    using ArtGallery.Statistics.Services.ItemsViews;
    using ArtGallery.Statistics.Services.Statistics;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
    
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddWebService<StatisticsDbContext>(this.Configuration)
                .AddTransient<IItemsViewsService, ItemsViewsService>()
                .AddTransient<IStatisticsService, StatisticsService>()
                .AddMessaging(typeof(ItemCreatedConsumer));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app
                .UseWebService(env)
                .Initialize();
        }
    }
}
