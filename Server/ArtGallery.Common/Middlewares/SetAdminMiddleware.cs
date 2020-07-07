namespace ArtGallery.Common.Middlewares
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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
            UserManager<IdentityUser> userManager,
            RoleManager<ApplicationRole> roleManager)
        {
            await SeedUserInRoles(userManager);
            await this.next(context);
        }

        private static async Task SeedUserInRoles(UserManager<IdentityUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new IdentityUser
                {
                    UserName = Constants.AdministratorEmail,
                    Email = Constants.AdministratorEmail,
                };

                var result = await userManager.CreateAsync(user, Constants.AdministratorPassword);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, Constants.AdministratorRoleName);
                }
            }
        }
    }
}
