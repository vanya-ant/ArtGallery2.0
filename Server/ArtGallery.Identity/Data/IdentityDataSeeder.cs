namespace ArtGallery.Identity.Data
{
    using ArtGallery.Common;
    using ArtGallery.Common.Servcies;
    using Microsoft.AspNetCore.Identity;
    using System.Linq;
    using System.Threading.Tasks;

    public class IdentityDataSeeder : IDataSeeder
    {
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public IdentityDataSeeder(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        public void SeedData()
        {
            if (this.roleManager.Roles.Any())
            {
                return;
            }

            Task.Run(async () =>
                {
                    IdentityRole adminRole = new IdentityRole(Constants.AdministratorRoleName);

                    await this.roleManager.CreateAsync(adminRole);

                    User adminUser = new User
                    {
                        UserName = Constants.AdministratorEmail,
                        Email = Constants.AdministratorEmail,
                        SecurityStamp = "RandomSecurityStamp",
                    };

                    await userManager.CreateAsync(adminUser, "123456");

                    await userManager.AddToRoleAsync(adminUser, Constants.AdministratorRoleName);
                })
                .GetAwaiter()
                .GetResult();
        }
    }
}
