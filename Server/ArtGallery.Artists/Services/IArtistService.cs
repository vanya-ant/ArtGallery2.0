namespace ArtGallery.Artists.Services
{
    using ArtGallery.Artists.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IArtistService
    {
        public Task<IEnumerable<ArtistOutputModel>> GetAll();

        public Task<ArtistDetailsModel> ArtistDetails(string id);

        public Task<ArtistOutputModel> FindByUser(string userId);

        public Task<CreateArtistOutputModel> Create(ArtistInputModel model);
    }
}
