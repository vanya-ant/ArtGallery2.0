namespace ArtGallery.Server.Services.Identity
{
    using ArtGallery.Server.Data.Models;

    public interface IJwtTokenGeneratorService
    {
        string GenerateToken(User user);
    }
}
