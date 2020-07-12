namespace ArtGallery.Items.Services.Items
{
    using ArtGallery.Items.Data;
    using ArtGallery.Items.Data.Models;
    using ArtGallery.Items.Models;
    using ArtGallery.Items.Services.Artists;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ItemService : IItemService
    {
        private readonly ItemsDbContext context;

        public ItemService(ItemsDbContext context)
        {
            this.context = context;
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
