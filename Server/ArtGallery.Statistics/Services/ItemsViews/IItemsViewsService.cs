namespace ArtGallery.Statistics.Services.ItemsViews
{
    using ArtGallery.Statistics.Models.ItemViews;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IItemsViewsService
    {
        Task<string> GetTotalViews(string itemId);

        Task<IEnumerable<ItemViewsOutputModel>> GetTotalViews(IEnumerable<string> ids);
    }
}
