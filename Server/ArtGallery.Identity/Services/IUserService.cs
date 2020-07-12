namespace ArtGallery.Identity.Services
{
    using ArtGallery.Identity.Data;
    using ArtGallery.Identity.Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IUserService
    {
        Task<IEnumerable<UserOutputModel>> GetAll();

        public Task<User> FindByUser(string userId);

        public Task<User> FindById(string id);
    }
}
