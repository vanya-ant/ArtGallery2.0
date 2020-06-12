namespace ArtGallery.Server.Infrastructure.Extensions
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.OpenApi.Models;

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseSwaggerUI(this IApplicationBuilder app)
        {
            app.UseSwagger()
                .UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v2/swagger.json", "Art Gallery API");
                    options.RoutePrefix = string.Empty;
                });
            return null;
        }
    }
}
