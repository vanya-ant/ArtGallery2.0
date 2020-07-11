using ArtGallery.Common.Servcies;
using ArtGallery.Identity.Data;
using ArtGallery.Identity.Models;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace ArtGallery.Identity
{
    public class IdentityService : IIdentityService
    {
        private const string ErrorMessage = "Invalid credentials";

        private readonly UserManager<User> userManager;

        private readonly IJwtTokenGeneratorService jwtTokenGenerator;

        public IdentityService(UserManager<User> userManager, IJwtTokenGeneratorService jwtTokenGenerator)
        {
            this.jwtTokenGenerator = jwtTokenGenerator;
            this.userManager = userManager;
        }

        public async Task<Result<User>> Register(UserInputModel model)
        {
            var currentUser = new User
            {
                Email = model.Email,
                UserName = model.Email,
            };

            var identityResult = await this.userManager.CreateAsync(currentUser, model.Password);

            var errors = identityResult.Errors.Select(e => e.Description);

            if (identityResult.Succeeded)
            {
                return Result<User>.SuccessWith(currentUser);
            }

            return Result<User>.Failure(errors);
        }

        public async Task<Result<UserOutputModel>> Login(UserInputModel model)
        {
            var currentUser = await this.userManager.FindByEmailAsync(model.Email);

            if (currentUser == null)
            {
                return ErrorMessage;
            }

            var validPassword = await this.userManager.CheckPasswordAsync(currentUser, model.Password);
            
            if (!validPassword)
            {
                return ErrorMessage;
            }

            var roles = await this.userManager.GetRolesAsync(currentUser);

            var token = this.jwtTokenGenerator.GenerateToken(currentUser, roles);

            return new UserOutputModel(token);
        }

        public async Task<Result> ChangePassword(string userId, ChangePasswordInputModel model)
        {
            var currentUser = await this.userManager.FindByIdAsync(userId);
            if (currentUser == null)
            {
                return ErrorMessage;
            }

            var identityResult = await this.userManager.ChangePasswordAsync(currentUser, model.CurrentPassword, model.NewPassword);

            var errors = identityResult.Errors.Select(e => e.Description);

            if (identityResult.Succeeded)
            {
               return Result.Success;
            }

            return Result.Failure(errors);
        }   
    }
}
