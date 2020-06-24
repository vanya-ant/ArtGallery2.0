namespace ArtGallery.Identity.Controllers
{
    using ArtGallery.Common.Controllers;
    using ArtGallery.Common.Services.Identity;
    using ArtGallery.Identity.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class IdentityController : ApiController
    {
        private readonly IIdentityService identity;

        private readonly ICurrentUserService currentUser;

        public IdentityController(IIdentityService identity, ICurrentUserService currentUser)
        {
            this.identity = identity;
            this.currentUser = currentUser;
        }

        [HttpPost]
        [Route(nameof(Register))]
        public async Task<ActionResult<UserOutputModel>> Register(UserInputModel model)
        {
            var result = await this.identity.Register(model);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return await Login(model);
        }

        [HttpPost]
        [Route(nameof(Login))]
        public async Task<ActionResult<UserOutputModel>> Login(UserInputModel model)
        {
            var result = await this.identity.Login(model);

            if (!result)
            {
                return BadRequest(result.Errors);
            }

            return new UserOutputModel(result.Data.Token);
        }


        [HttpPut]
        [Authorize]
        [Route(nameof(ChangePassword))]
        public async Task<ActionResult> ChangePassword(ChangePasswordInputModel model)
        {
            var result = await this.identity.ChangePassword(this.currentUser.UserId, new ChangePasswordInputModel
            {
                CurrentPassword = model.CurrentPassword,
                NewPassword = model.NewPassword,
            });

            return result;
        }
    }
}
