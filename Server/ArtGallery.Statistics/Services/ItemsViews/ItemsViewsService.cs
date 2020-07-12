using ArtGallery.Common.Servcies;
using ArtGallery.Statistics.Data;
using ArtGallery.Statistics.Data.Models;
using ArtGallery.Statistics.Models.ItemViews;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArtGallery.Statistics.Services.ItemsViews
{
    public class ItemsViewsService : DataService<ItemView>, IItemsViewsService
    {
        public ItemsViewsService(StatisticsDbContext db)
             : base(db)
        {
        }

        public async Task<string> GetTotalViews(string itemId)
        {
            var i = this.All().CountAsync(c => c.ItemId == itemId);
            return null;
        }

        public async Task<IEnumerable<ItemViewsOutputModel>> GetTotalViews(IEnumerable<string> ids)
        {
            throw new NotImplementedException();
        }
    }
}
