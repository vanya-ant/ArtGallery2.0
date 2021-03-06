﻿namespace ArtGallery.Artists.Services
{
    using ArtGallery.Artists.Data;
    using ArtGallery.Artists.Data.Models;
    using ArtGallery.Artists.Models;
    using ArtGallery.Common.Messages.Artists;
    using ArtGallery.Common.Servcies;
    using AutoMapper;
    using MassTransit;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class ArtistService : DataService<Artist>, IArtistService
    {
        private readonly ArtistsDbContext context;

        private readonly IBus publisher;

        private readonly IMapper mapper;

        public ArtistService(ArtistsDbContext context, IBus publisher, IMapper mapper) : base(context)
        {
            this.context = context;
            this.publisher = publisher;
            this.mapper = mapper;
        }

        public Task<ArtistOutputModel> FindByUser(string userId)
        {
            return this.FindByUser(userId);
        }

        public async Task<ArtistOutputModel> FindById(string id)
            => await this.Data.FindAsync<ArtistOutputModel>(id);

        public async Task<IEnumerable<ArtistOutputModel>> GetAll()
        {
            return await this.mapper
                .ProjectTo<ArtistOutputModel>(this.All())
                .ToListAsync();
        }

        public async Task<ArtistDetailsModel> ArtistDetails(string id)
        {
            return await this.mapper.ProjectTo<ArtistDetailsModel>(this.All().Where(i => i.Id == id)).FirstOrDefaultAsync();
        }

        public async Task<CreateArtistOutputModel> Create(ArtistInputModel model)
        {
            var artist = new Artist
            {
                Name = model.Name,
                ImageUrl = model.ImageUrl,
                Category = model.Category.ToString(),
                Email = model.Email,
            };

            await this.context.AddAsync(artist);
            await this.context.SaveChangesAsync();

            await this.publisher.Publish(new ArtistCreatedMessage
            {
                ArtistId = artist.Id
            });

            return new CreateArtistOutputModel(artist.Id);
        }
    }
}
