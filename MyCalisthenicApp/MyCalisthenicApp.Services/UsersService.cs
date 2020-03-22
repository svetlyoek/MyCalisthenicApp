namespace MyCalisthenicApp.Services
{
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;
    using MyCalisthenicApp.Data;
    using MyCalisthenicApp.Services.Common;
    using MyCalisthenicApp.Services.Contracts;
    using MyCalisthenicApp.ViewModels.Coupons;

    public class UsersService : IUsersService
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly MyCalisthenicAppDbContext dbContext;

        public UsersService(IHttpContextAccessor httpContextAccessor, MyCalisthenicAppDbContext dbContext)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.dbContext = dbContext;
        }

        public async Task AddDiscountToUser(CouponViewModel inputModel)
        {
            var userId = this.GetLoggedUserId();

            var user = await this.dbContext.Users
                .Where(u => u.IsDeleted == false)
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (inputModel.Coupon == ServicesConstants.AppDiscountCoupon && user.HasCoupon == false)
            {
                user.HasCoupon = true;

                this.dbContext.Update(user);

                await this.dbContext.SaveChangesAsync();
            }
        }

        private string GetLoggedUserId()
        {
            var userId = this.httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            return userId;
        }
    }
}
