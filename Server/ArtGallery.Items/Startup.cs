﻿namespace ArtGallery.Items
{
    using ArtGallery.Common.Infrastructure;
    using ArtGallery.Items.Data;
    using ArtGallery.Items.Services.Items;
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
                .AddWebService<ItemsDbContext>(this.Configuration)
                .AddTransient<IItemService, ItemService>()
                .AddMessaging();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseWebService(env)
                .Initialize();
        }
    }
}
