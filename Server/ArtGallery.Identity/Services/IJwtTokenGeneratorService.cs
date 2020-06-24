namespace ArtGallery.Identity
{
    using ArtGallery.Identity.Data;

    public interface IJwtTokenGeneratorService
    {
        string GenerateToken(User user);
    }
}
