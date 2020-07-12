namespace ArtGallery.Identity.Controllers
{
    using ArtGallery.Common.Controllers;
    using ArtGallery.Common.Services.Identity;
    using ArtGallery.Identity.Services;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class UsersController : ApiController
    {
        private readonly IUserService userService;

        private readonly ICurrentUserService currentUser;

        public UsersController(IUserService userService, ICurrentUserService currentUser)
        {
            this.userService = userService;
            this.currentUser = currentUser;
        }

        [HttpGet]
        [Authorize]
        [Route(Id)]
        public async Task<ActionResult<string>> GetUserId()
        {
            var userId = this.currentUser.UserId;

            var user = await this.userService.FindById(userId);

            return user.Id;
        }
    }
}
