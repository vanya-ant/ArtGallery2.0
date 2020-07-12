using ArtGallery.Items.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtGallery.Items.Services.Items
{
    public interface IItemService
    {
        public Task<IEnumerable<ItemOutputModel>> GetAll();

        public Task<ItemDetailsModel> ItemDetails(string itemId);

        public Task<string> CreateItem(ItemInputModel input);
    }
}
