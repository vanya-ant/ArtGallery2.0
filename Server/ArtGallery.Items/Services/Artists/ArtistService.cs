namespace ArtGallery.Items.Services.Artists
{
    using ArtGallery.Common.Servcies;
    using ArtGallery.Items.Data;
    using ArtGallery.Items.Data.Models;
    using ArtGallery.Items.Models;
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ArtistService : DataService<Artist>, IArtistService 
    {
        private readonly IMapper mapper;

        public ArtistService(ItemsDbContext db, IMapper mapper) : base(db)
        {
            this.mapper = mapper;
        }

        public Task<Artist> FindByUser(string userId)
        {
            return this.FindByUser(userId);
        }

        public async Task<Artist> FindById(string id)
            => await this.Data.FindAsync<Artist>(id);

        public async Task<IEnumerable<ArtistOutputModel>> GetAll()
        {
            return await this.mapper
                .ProjectTo<ArtistOutputModel>(this.All())
                .ToListAsync();
        }
    }
}
