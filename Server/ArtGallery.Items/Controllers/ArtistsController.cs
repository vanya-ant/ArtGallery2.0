namespace ArtGallery.Items.Controllers
{
    using ArtGallery.Common.Services.Identity;
    using ArtGallery.Items.Models;
    using ArtGallery.Items.Models.Artist;
    using ArtGallery.Items.Services.Artists;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ArtistsController
    {
        private readonly ICurrentUserService currentUser;

        private readonly IArtistService artistService;

        public ArtistsController(IArtistService artistService, ICurrentUserService currentUser)
        {
            this.currentUser = currentUser;
            this.artistService = artistService;
        }

        [HttpGet]
        [Route("Artists")]
        public async Task<IEnumerable<ArtistOutputModel>> All()
        {
            return await this.artistService.GetAll();
        }

        [HttpGet]
        [Route("Id")]
        public async Task<ActionResult<ArtistDetailsModel>> Details(string id)
            => await this.artistService.ArtistDetails(id);

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<CreateArtistOutputModel>> Create(ArtistInputModel model)
        {
            return await this.artistService.Create(model);
        }
    }
}
