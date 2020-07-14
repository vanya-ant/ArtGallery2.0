namespace ArtGallery.Items.Services.Items
{
    using ArtGallery.Common.Messages.Items;
    using ArtGallery.Common.Servcies;
    using ArtGallery.Items.Data;
    using ArtGallery.Items.Data.Models;
    using ArtGallery.Items.Models;
    using MassTransit;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ItemService : DataService<Item>, IItemService
    {
        private readonly ItemsDbContext context;

        private readonly IBus publisher;

        public ItemService(ItemsDbContext context, IBus publisher) : base(context)
        {
            this.context = context;
            this.publisher = publisher;
        }

        public async Task<string> CreateItem(ItemInputModel model)
        {
            /*var artist = this.artistService.FindByUser(model.Author.Id);*/

            var item = new Item
            {
                Name = model.Name,
                AuthorId = model.Author.Id,
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
