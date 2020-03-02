namespace MyCalisthenicApp.Web.Middlewares
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using MyCalisthenicApp.Data;
    using MyCalisthenicApp.Models;
    using MyCalisthenicApp.Models.ShopEntities;
    using MyCalisthenicApp.Services;
    using MyCalisthenicApp.Services.Contracts;
    using MyCalisthenicApp.Web.Common;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

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
            RoleManager<IdentityRole> roleManager,
            MyCalisthenicAppDbContext dbContext,
            IShoppingCartsService shoppingCartsService)

        {
            SeedUserInRoles(userManager, shoppingCartsService)
                 .GetAwaiter()
                 .GetResult();

            SeedRoles(roleManager)
                .GetAwaiter()
                .GetResult();

            await this.next(httpContext);
        }

        private static async Task SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!await roleManager.RoleExistsAsync(GlobalConstants.AdministratorRoleName))
            {
                await roleManager.CreateAsync(new IdentityRole(GlobalConstants.AdministratorRoleName));
            }
        }

        private static async Task SeedUserInRoles(UserManager<ApplicationUser> userManager, IShoppingCartsService shoppingCartsService,
             MyCalisthenicAppDbContext dbContext)
        {
            if (!userManager.Users.Any())
            {
                var user = new ApplicationUser
                {
                    Id=Guid.NewGuid().ToString(),
                    FirstName = GlobalConstants.AdministratorFirstName,
                    LastName = GlobalConstants.AdministratorLastName,
                    UserName = GlobalConstants.AdministratorUsername,
                    Email = GlobalConstants.AdministratorEmail,
                    ShoppingCart = new ShoppingCart
                    {
                        Id = Guid.NewGuid().ToString(),
                        CardNumber = GlobalConstants.AdministratorCardNumber,
                        CVV = GlobalConstants.AdministratorCardCVV
                    },

                };
               
                var result = await userManager.CreateAsync(user, GlobalConstants.AdministratorPassword);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, GlobalConstants.AdministratorRoleName);
                    await shoppingCartsService.AssignShoppingCartToUser(user);
                   
                }

            }
        }
    }
}
