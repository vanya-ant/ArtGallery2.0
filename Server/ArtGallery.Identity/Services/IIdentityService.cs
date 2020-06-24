using ArtGallery.Common.Servcies;
using ArtGallery.Identity.Data;
using ArtGallery.Identity.Models;
using Microsoft.EntityFrameworkCore.Update;
using System.Threading.Tasks;

namespace ArtGallery.Identity
{
    public interface IIdentityService
    {
        Task<Result<User>> Register(UserInputModel model);

        Task<Result<UserOutputModel>> Login(UserInputModel model);

        Task<Result> ChangePassword(string userId, ChangePasswordInputModel model);
    }
}
