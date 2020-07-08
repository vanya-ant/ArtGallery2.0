namespace ArtGallery.Identity.Middlewares
{
    using ArtGallery.Common;
    using ArtGallery.Identity.Data;
    using ArtGallery.Identity.Data.Models;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using System.Linq;
    using System.Threading.Tasks;

    public class SetAdminMiddleware
    {
        private readonly RequestDelegate next;

        public SetAdminMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(
            HttpContext context,
            UserManager<User> userManager,
            RoleManager<Role> roleManager)
        {
            await SeedUserInRoles(userManager, roleManager);
            await this.next(context);
        }

        private static async Task SeedUserInRoles(UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new User
                {
                    UserName = Constants.AdministratorEmail,
                    Email = Constants.AdministratorEmail,
                };

                var role = new Role
                {
                    Name = Constants.AdministratorRoleName
                };

                await roleManager.CreateAsync(role);

                var result = await userManager.CreateAsync(user, Constants.AdministratorPassword);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, Constants.AdministratorRoleName);
                }
            }
        }
    }
}
