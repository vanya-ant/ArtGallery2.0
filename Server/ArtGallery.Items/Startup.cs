namespace ArtGallery.Items
{
    using ArtGallery.Common.Infrastructure;
    using ArtGallery.Items.Data;
    using ArtGallery.Items.Services.Artists;
    using ArtGallery.Items.Services.Categories;
    using ArtGallery.Items.Services.Items;
    using MassTransit;
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
                .AddTransient<ICategoryService, CategoryService>()
                .AddTransient<IArtistService, ArtistService>()
                .AddMassTransit(mst =>
                {
                    mst.AddBus(bus => Bus.Factory.CreateUsingRabbitMq(rbmq =>
                    {
                        rbmq.Host("localhost");
                    }));
                });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseWebService(env)
                .Initialize();
        }
    }
}
