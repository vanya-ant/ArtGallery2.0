namespace ArtGallery.Server
{
    using ArtGallery.Server.Data;
    using ArtGallery.Server.Data.Models;
    using ArtGallery.Server.Features.Article;
    using ArtGallery.Server.Features.Identity;
    using ArtGallery.Server.Features.Item;
    using ArtGallery.Server.Features.Order;
    using ArtGallery.Server.Infrastructure;
    using ArtGallery.Server.Services.Identity;
    using AutoMapper;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.IdentityModel.Tokens;
    using System.Reflection;
    using System.Text;

    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration) {
            this.Configuration = configuration;
        }
   
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddDbContext<ArtGalleryDbContext>(options => options
                    .UseSqlServer(this.Configuration.GetConnectionString("DefaultConnection")));

            services
                .AddIdentity<User, IdentityRole>(options =>
                {
                    options.Password.RequiredLength = 6;
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                })
                .AddEntityFrameworkStores<ArtGalleryDbContext>();

            services
              .Configure<ApplicationSettings>(this.Configuration
                  .GetSection(nameof(ApplicationSettings)));

            string secret = this.Configuration
                .GetSection(nameof(ApplicationSettings))
                .GetValue<string>(nameof(ApplicationSettings.Secret));

            var key = Encoding.ASCII.GetBytes(secret);

            services
                .AddAuthentication(authentication =>
                {
                    authentication.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    authentication.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(bearer =>
                {
                    bearer.RequireHttpsMetadata = false;
                    bearer.SaveToken = true;
                    bearer.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<ICurrentUserService, CurrentUserService>();

            services.AddTransient<IIdentityService, IdentityService>();
            services.AddTransient<IJwtTokenGeneratorService, JwtTokenGeneratorService>();
            services.AddTransient<IArticleService, ArticleService>();
            services.AddTransient<IArticleService, ArticleService>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IItemService, ItemService>();

            services.AddControllers();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            };

            app
                .UseHttpsRedirection()
                .UseRouting()
                .UseCors(options => options
                    .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod())
                .UseAuthentication()
                .UseAuthorization()
                .UseEndpoints(endpoints => endpoints
                    .MapControllers())
                .Initialize();
        }          
    }
}
