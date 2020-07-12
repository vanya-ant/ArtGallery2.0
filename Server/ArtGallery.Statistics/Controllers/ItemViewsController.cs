namespace ArtGallery.Statistics.Controllers
{
    using ArtGallery.Common.Controllers;
    using ArtGallery.Statistics.Models.ItemViews;
    using ArtGallery.Statistics.Services.ItemsViews;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ItemViewsController : ApiController
    {
        private readonly IItemsViewsService itemViews;

        public ItemViewsController(IItemsViewsService itemViews)
            => this.itemViews = itemViews;

        [HttpGet]
        [Route(Id)]
        public async Task<string> TotalViews(string id)
            => await this.itemViews.GetTotalViews(id);

        [HttpGet]
        [Authorize]
        public async Task<IEnumerable<ItemViewsOutputModel>> TotalViews(
            [FromQuery] IEnumerable<string> ids)
            => await this.itemViews.GetTotalViews(ids);
    }
}
