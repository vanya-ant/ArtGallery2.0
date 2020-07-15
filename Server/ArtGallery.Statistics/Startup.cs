namespace ArtGallery.Statistics
{
    using ArtGallery.Common.Infrastructure;
    using ArtGallery.Statistics.Data;
    using ArtGallery.Statistics.Models;
    using ArtGallery.Statistics.Services.ItemsViews;
    using ArtGallery.Statistics.Services.Statistics;
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
                .AddWebService<StatisticsDbContext>(this.Configuration)
                .AddTransient<IItemsViewsService, ItemsViewsService>()
                .AddTransient<IStatisticsService, StatisticsService>()
                .AddMassTransit(mst =>
                {
                      mst.AddConsumer<ItemCreatedConsumer>();

                      mst.AddBus(bus => Bus.Factory.CreateUsingRabbitMq(rbmq =>
                      {
                          rbmq.Host("localhost");

                          rbmq.ReceiveEndpoint(nameof(ItemCreatedConsumer), endpoint =>
                          {
                              endpoint.ConfigureConsumer<ItemCreatedConsumer>(bus);
                          });
                      }));
                });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app
                .UseWebService(env)
                .Initialize();
        }
    }
}
