namespace ArtGallery.Items.Controllers
{
    using ArtGallery.Common.Controllers;
    using ArtGallery.Common.Services.Identity;
    using ArtGallery.Identity;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class ItemsController : ApiController
    {
        private readonly IIdentityService identity;

        private readonly ICurrentUserService currentUser;

        public ItemsController(IIdentityService identity, ICurrentUserService currentUser)
        {
            this.identity = identity;
            this.currentUser = currentUser;
        }
    }
}
