namespace ArtGallery.Items.Services.Items
{
    using ArtGallery.Common.Messages.Items;
    using ArtGallery.Common.Servcies;
    using ArtGallery.Items.Data;
    using ArtGallery.Items.Data.Models;
    using ArtGallery.Items.Models;
    using ArtGallery.Items.Services.Artists;
    using AutoMapper;
    using MassTransit;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class ItemService : DataService<Item>, IItemService
    {
        private readonly ItemsDbContext context;

        private readonly IBus publisher;

        private readonly IMapper mapper;

        private readonly IArtistService artistService;

        public ItemService(ItemsDbContext context, IBus publisher, IArtistService artistService, IMapper mapper) : base(context)
        {
            this.context = context;
            this.publisher = publisher;
            this.artistService = artistService;
            this.mapper = mapper;
        }

        public async Task<string> CreateItem(ItemInputModel model)
        {
            var author = await this.artistService.FindByUser(model.AuthorName);

            var item = new Item
            {
                Name = model.Name,
                AuthorId = author.Id,
                CategoryId = model.Category.Id,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                Price = model.Price
            };

            await this.context.AddAsync(item);
            await this.context.SaveChangesAsync();

            await this.publisher.Publish(new ItemCreatedMessage
            {
                ItemId = item.Id
            });

            return item.Id;
        }

        public async Task<IEnumerable<ItemOutputModel>> GetAll()
        {
            return await mapper.ProjectTo<ItemOutputModel>(this.All()).ToListAsync();
        }

        public async Task<ItemDetailsModel> ItemDetails(string itemId)
        {
            return await this.mapper.ProjectTo<ItemDetailsModel>(this.All().Where(i => i.Id == itemId)).FirstOrDefaultAsync();
        }

        public async Task<bool> DeleteItem(string itemId)
        {
            var item = await this.Data.FindAsync<Item>(itemId);

            if (item == null)
            {
                return false;
            }

            this.Data.Remove(item);

            await this.Data.SaveChangesAsync();

            return true;
        }
    }
}
