namespace MyCalisthenicApp.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;
    using MyCalisthenicApp.Data;
    using MyCalisthenicApp.Models;
    using MyCalisthenicApp.Models.ShopEntities;
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

        public async Task<IList<ApplicationUser>> GetAllUsersAsync()
        {
            var allUsers = await this.dbContext.Users
                .Where(u => u.IsDeleted == false)
                .OrderByDescending(u => u.CreatedOn)
                .ToListAsync();

            return allUsers;
        }

        public async Task<IList<ApplicationUser>> GetBannedUsersAsync()
        {
            var bannedUsers = await this.dbContext.Users
                .Where(u => u.IsDeleted == true)
                 .ToListAsync();

            return bannedUsers;
        }

        public async Task<ApplicationUser> GetBannedUserAsync(string email)
        {
            var bannedUser = await this.dbContext.Users
                .Where(u => u.IsDeleted == true)
                .Where(u => u.Email == email)
                .FirstOrDefaultAsync();

            return bannedUser;
        }

        public async Task<ApplicationUser> BlockUnblockUserByIdAsync(string id)
        {
            var user = await this.dbContext.Users
                .Where(u => u.Id == id)
                .FirstOrDefaultAsync();

            if (user.IsDeleted == false)
            {
                user.IsDeleted = true;
            }
            else
            {
                user.IsDeleted = false;
            }

            this.dbContext.Update(user);

            await this.dbContext.SaveChangesAsync();

            return user;
        }

        public async Task GetUserToBlockAsync(string id)
        {
            var userToBlock = await this.dbContext.Users
                .Where(u => u.Id == id)
                .Where(u => u.IsDeleted == false)
                .FirstOrDefaultAsync();

            userToBlock.IsDeleted = true;

            this.dbContext.Update(userToBlock);

            await this.dbContext.SaveChangesAsync();
        }

        public async Task<ApplicationUser> GetUserByEmailAsync(string email)
        {
            var user = await this.dbContext.Users
                 .Where(u => u.Email == email)
                  .FirstOrDefaultAsync();

            return user;
        }

        public async Task<IList<Comment>> GetAllCommentsByUserIdAsync(string id)
        {
            var comments = await this.dbContext.Comments
                .Where(c => c.AuthorId == id)
                .ToListAsync();

            return comments;
        }

        public async Task<IList<Order>> GetAllOrdersByUserIdAsync(string id)
        {
            var orders = await this.dbContext.Orders
                .Include(o => o.Products)
                 .Where(c => c.UserId == id)
                 .ToListAsync();

            return orders;
        }

        public async Task<IList<Address>> GetAllAddressesByUserIdAsync(string id)
        {
            var addresses = await this.dbContext.Addresses
                .Include(a => a.City)
                .Where(c => c.UserId == id)
                .ToListAsync();

            return addresses;
        }

        public async Task<IList<OrderProduct>> GetAllProductsByOrderIdAsync(string id)
        {
            var products = await this.dbContext
                .OrderProducts.Where(o => o.OrderId == id)
                .ToListAsync();

            return products;
        }
    }
}
