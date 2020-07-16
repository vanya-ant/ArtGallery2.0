namespace ArtGallery.Items.Services.Items
{
    using ArtGallery.Common.Messages.Items;
    using ArtGallery.Common.Servcies;
    using ArtGallery.Items.Data;
    using ArtGallery.Items.Data.Models;
    using ArtGallery.Items.Models;
    using ArtGallery.Items.Services.Artists;
    using MassTransit;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ItemService : DataService<Item>, IItemService
    {
        private readonly ItemsDbContext context;

        private readonly IBus publisher;

        private readonly IArtistService artistService;

        public ItemService(ItemsDbContext context, IBus publisher, IArtistService artistService) : base(context)
        {
            this.context = context;
            this.publisher = publisher;
            this.artistService = artistService;
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

        public Task<IEnumerable<ItemOutputModel>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<ItemDetailsModel> ItemDetails(string itemId)
        {
            throw new System.NotImplementedException();
        }
    }
}
