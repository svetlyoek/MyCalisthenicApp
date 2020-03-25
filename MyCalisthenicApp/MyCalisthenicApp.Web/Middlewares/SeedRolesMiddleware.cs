namespace MyCalisthenicApp.Web.Middlewares
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using MyCalisthenicApp.Models;
    using MyCalisthenicApp.Models.ShopEntities;
    using MyCalisthenicApp.Web.Common;

    public class SeedRolesMiddleware
    {
        private readonly RequestDelegate next;

        public SeedRolesMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(
            HttpContext httpContext,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            SeedUserInRoles(userManager, roleManager)
                 .GetAwaiter()
                 .GetResult();

            await this.next(httpContext);
        }

        private static async Task SeedUserInRoles(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new ApplicationUser
                {
                    FirstName = GlobalConstants.AdministratorFirstName,
                    LastName = GlobalConstants.AdministratorLastName,
                    UserName = GlobalConstants.AdministratorReceiveEmail,
                    Email = GlobalConstants.AdministratorReceiveEmail,
                    ShoppingCart = new ShoppingCart
                    {
                        CardNumber = GlobalConstants.AdministratorCardNumber,
                        CVV = GlobalConstants.AdministratorCardCVV,
                        ExpirationDate = new DateTime(
                        GlobalConstants.AdministratorCardExpirationYear,
                        GlobalConstants.AdministratorCardExpirationMonth,
                        GlobalConstants.AdministratorCardExpirationDay),
                    },

                };

                var role = await roleManager.CreateAsync(new IdentityRole
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = GlobalConstants.AdministratorRoleName,
                });

                var result = await userManager.CreateAsync(user, GlobalConstants.AdministratorPassword);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, GlobalConstants.AdministratorRoleName);
                }
            }
        }
    }
}
