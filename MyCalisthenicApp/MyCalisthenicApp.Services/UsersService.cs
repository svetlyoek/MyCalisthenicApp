namespace MyCalisthenicApp.Services
{
    using System;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;
    using MyCalisthenicApp.Data;
    using MyCalisthenicApp.Models;
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

        public async Task AddDiscountToUserAsync(CouponViewModel inputModel)
        {
            var userId = this.GetLoggedUserId();

            var userFromDb = await this.GetLoggedUserByIdAsync(userId);

            if (inputModel.Coupon == ServicesConstants.AppDiscountCoupon && userFromDb.HasCoupon == false)
            {
                userFromDb.HasCoupon = true;

                this.dbContext.Update(userFromDb);

                await this.dbContext.SaveChangesAsync();
            }
        }

        public string GetLoggedUserId()
        {
            var userId = this.httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            return userId;
        }

        public async Task<ApplicationUser> GetLoggedUserByIdAsync(string userId)
        {
            var userFromDb = await this.dbContext.Users.
                Where(u => u.IsDeleted == false)
                .FirstOrDefaultAsync(u => u.Id == userId);

            return userFromDb;
        }

        public async Task<bool> CheckUserMembershipAsync()
        {
            var currentDate = DateTime.UtcNow;

            var userId = this.GetLoggedUserId();

            var user = await this.GetLoggedUserByIdAsync(userId);

            if (user != null && user.MembershipExpirationDate != null)
            {
                if (currentDate >= user.MembershipExpirationDate)
                {
                    user.HasMembership = false;

                    user.MembershipExpirationDate = null;

                    this.dbContext.Update(user);

                    await this.dbContext.SaveChangesAsync();

                    return true;
                }
            }

            return false;
        }
    }
}
