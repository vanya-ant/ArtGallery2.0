namespace ArtGallery.Items.Services.Artists
{
    using ArtGallery.Items.Data.Models;
    using ArtGallery.Items.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IArtistService
    {
        public Task<IEnumerable<ArtistOutputModel>> GetAll();

        public Task<Artist> FindByUser(string userId);
    }
}
