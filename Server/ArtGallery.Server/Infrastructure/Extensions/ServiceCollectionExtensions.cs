namespace ArtGallery.Server.Infrastructure.Extensions
{
    using ArtGallery.Server.Data;
    using ArtGallery.Server.Data.Models;
    using ArtGallery.Server.Features.Article;
    using ArtGallery.Server.Features.Comment;
    using ArtGallery.Server.Features.Identity;
    using ArtGallery.Server.Features.Item;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.IdentityModel.Tokens;
    using Microsoft.OpenApi.Models;
    using System.Text;

    public static class ServiceCollectionExtensions
    {
        public static AppSettings GetApplicationSettings(this IServiceCollection services, IConfiguration configuration)
        {
            var appConfiguration = configuration.GetSection("ApplicationSettings");
            services.Configure<AppSettings>(appConfiguration);
            return appConfiguration.Get<AppSettings>();
        }

        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            return services.AddDbContext<ArtGalleryDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetDefaultConnectionString());
            });
        }

        public static IServiceCollection AddIdentity(this IServiceCollection services)
        {
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

            return services;
        }

        public static IServiceCollection AddJwtAuthentication(
            this IServiceCollection services,
            AppSettings appSettings)
        {
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);

            services
                .AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            return services;
        }

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            return services
                           .AddTransient<IIdentityService, IdentityService>()
                           .AddTransient<IArtistService, ArtistService>()
                           .AddTransient<IItemService, ItemService>()
                           .AddTransient<IArticleService, ArticleService>()
                           .AddTransient<ICommentService, CommentService>();
        }

        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            return services.AddSwaggerGen(c =>
                        {
                            c.SwaggerDoc(
                                "v2",
                                new OpenApiInfo
                                {
                                    Title = "Art Gallery API",
                                    Version = "v2"
                                });
                        });
        }

        public static void AddApiControllers(this IServiceCollection services)
        {
            services
                           .AddControllers(options => options
                               .Filters
                               .Add<ModelOrNotFoundActionFilter>());
        }
    }
}
