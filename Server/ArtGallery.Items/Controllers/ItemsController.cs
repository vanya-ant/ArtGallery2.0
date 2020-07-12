namespace ArtGallery.Items.Controllers
{
    using ArtGallery.Common.Controllers;
    using ArtGallery.Common.Services.Identity;
    using ArtGallery.Identity;
    using ArtGallery.Items.Data;
    using ArtGallery.Items.Models;
    using ArtGallery.Items.Models.Items;
    using ArtGallery.Items.Services.Items;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class ItemsController : ApiController
    {
        private readonly IIdentityService identity;

        private readonly ICurrentUserService currentUser;

        private readonly IItemService itemService;

        public ItemsController(IItemService itemService, IIdentityService identity, ICurrentUserService currentUser)
        {
            this.itemService = itemService;
            this.identity = identity;
            this.currentUser = currentUser;
        }

        [HttpGet]
        [Route(nameof(Items))]
        public async Task<IEnumerable<ItemOutputModel>> All()
        {
            return await this.itemService.GetAll();
        }

        [HttpGet]
        [Route(Id)]
        public async Task<ActionResult<ItemDetailsModel>> Details(string id)
            => await this.itemService.ItemDetails(id);

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<CreateItemOutputModel>> Create(ItemInputModel model)
        {
           var itemId =  await this.itemService.CreateItem(model);

            return new CreateItemOutputModel(itemId);
        }

    }
}
