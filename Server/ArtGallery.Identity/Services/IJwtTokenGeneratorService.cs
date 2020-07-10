namespace ArtGallery.Identity
{
    using ArtGallery.Identity.Data;
    using System.Collections.Generic;

    public interface IJwtTokenGeneratorService
    {
        string GenerateToken(User user, IEnumerable<string> roles = null);
    }
}
