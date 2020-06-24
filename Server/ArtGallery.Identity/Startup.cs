namespace ArtGallery.Identity
{
    using ArtGallery.Common.Infrastructure;
    using ArtGallery.Identity.Infrastructure;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public class Startup
    {
        public IConfiguration Configuration { get;  }
        public Startup(IConfiguration configuration) => this.Configuration = configuration;
    
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddWebService<IdentityDbContext>(this.Configuration)
                .AddUserStorage()
                .AddTransient<IIdentityService, IdentityService>()
                .AddTransient<IJwtTokenGeneratorService, JwtTokenGeneratorService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app
                .UseWebService(env)
                .Initialize();
        }
    }
}
