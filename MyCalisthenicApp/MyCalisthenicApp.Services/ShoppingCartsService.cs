namespace MyCalisthenicApp.Services
{
    using Microsoft.EntityFrameworkCore;
    using MyCalisthenicApp.Data;
    using MyCalisthenicApp.Models;
    using MyCalisthenicApp.Services.Common;
    using MyCalisthenicApp.Services.Contracts;
    using System;
    using System.Threading.Tasks;

    public class ShoppingCartsService : IShoppingCartsService
    {
        private readonly MyCalisthenicAppDbContext dbContext;

        public ShoppingCartsService(MyCalisthenicAppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AssignShoppingCartToUser(ApplicationUser user)
        {
            var shoppingCart = await this.dbContext.ShoppingCarts
                 .FirstOrDefaultAsync(sc => sc.User.Id == user.Id);

            if (shoppingCart == null)
            {
                throw new NullReferenceException(string.Format(ServicesConstants.InvalidShoppingCartForUser, user.UserName));
            }

            shoppingCart.User.Id = user.Id;

            this.dbContext.Update(shoppingCart);
            await this.dbContext.SaveChangesAsync();
        }
    }
}
