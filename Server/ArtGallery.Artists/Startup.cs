namespace ArtGallery.Artists
{
    using ArtGallery.Artists.Data;
    using ArtGallery.Artists.Services;
    using ArtGallery.Common.Infrastructure;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration) => this.Configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddWebService<ArtistsDbContext>(this.Configuration)
                .AddTransient<IArtistService, ArtistService>()
                .AddMessaging();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseWebService(env)
                .Initialize();
        }      
    }
}
