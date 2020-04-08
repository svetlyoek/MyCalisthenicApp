namespace MyCalisthenicApp.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using AutoMapper;
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;
    using MyCalisthenicApp.Data;
    using MyCalisthenicApp.Models;
    using MyCalisthenicApp.Services.Common;
    using MyCalisthenicApp.Services.Contracts;
    using MyCalisthenicApp.ViewModels.Addresses;
    using MyCalisthenicApp.ViewModels.Comments;
    using MyCalisthenicApp.ViewModels.Coupons;
    using MyCalisthenicApp.ViewModels.OrderProducts;
    using MyCalisthenicApp.ViewModels.Orders;
    using MyCalisthenicApp.ViewModels.Requests;
    using MyCalisthenicApp.ViewModels.Users;

    public class UsersService : IUsersService
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly MyCalisthenicAppDbContext dbContext;
        private readonly IMapper mapper;

        public UsersService(
            IHttpContextAccessor httpContextAccessor,
            MyCalisthenicAppDbContext dbContext,
            IMapper mapper)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task AddDiscountToUserAsync(CouponViewModel inputModel)
        {
            var userId = this.GetLoggedUserId();

            var userFromDb = await this.GetLoggedUserByIdAsync(userId);

            if (userFromDb == null)
            {
                throw new ArgumentNullException(string.Format(ServicesConstants.InvalidUserId, userId));
            }

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
            var userFromDb = await this.dbContext.Users
                .Where(u => u.IsDeleted == false)
                .FirstOrDefaultAsync(u => u.Id == userId);

            return userFromDb;
        }

        public async Task<bool> CheckUserMembershipAsync()
        {
            var currentDate = DateTime.UtcNow;

            var userId = this.GetLoggedUserId();

            var userFromDb = await this.GetLoggedUserByIdAsync(userId);

            if (userFromDb != null && userFromDb.MembershipExpirationDate != null)
            {
                if (currentDate >= userFromDb.MembershipExpirationDate)
                {
                    userFromDb.HasMembership = false;

                    userFromDb.MembershipExpirationDate = null;

                    this.dbContext.Update(userFromDb);

                    await this.dbContext.SaveChangesAsync();

                    return true;
                }
            }

            return false;
        }

        public async Task<IList<UsersAdminViewModel>> GetAllUsersAsync()
        {
            var allUsers = await this.dbContext.Users
                .Include(u => u.ShoppingCart)
                .Where(u => u.IsDeleted == false)
                .OrderByDescending(u => u.CreatedOn)
                .ToListAsync();

            var allUsersViewModel = this.mapper.Map<IList<UsersAdminViewModel>>(allUsers);

            return allUsersViewModel;
        }

        public async Task<IList<UsersAdminViewModel>> GetBannedUsersAsync()
        {
            var bannedUsers = await this.dbContext.Users
                .Include(u => u.ShoppingCart)
                .Where(u => u.IsDeleted == true)
                 .ToListAsync();

            var bannedUsersViewModel = this.mapper.Map<IList<UsersAdminViewModel>>(bannedUsers);

            return bannedUsersViewModel;
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
            var userFromDb = await this.dbContext.Users
                .Where(u => u.Id == id)
                .FirstOrDefaultAsync();

            if (userFromDb == null)
            {
                throw new ArgumentNullException(string.Format(ServicesConstants.InvalidUserId, id));
            }

            if (userFromDb.IsDeleted == false)
            {
                userFromDb.IsDeleted = true;
            }
            else
            {
                userFromDb.IsDeleted = false;
            }

            this.dbContext.Update(userFromDb);

            await this.dbContext.SaveChangesAsync();

            return userFromDb;
        }

        public async Task GetUserToBlockAsync(string id)
        {
            var userToBlock = await this.dbContext.Users
                .Where(u => u.Id == id)
                .Where(u => u.IsDeleted == false)
                .FirstOrDefaultAsync();

            if (userToBlock == null)
            {
                throw new ArgumentNullException(string.Format(ServicesConstants.InvalidUserId, id));
            }

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

        public async Task<IList<CommentAdminViewModel>> GetAllCommentsByUserIdAsync(string id)
        {
            var comments = await this.dbContext.Comments
                .Include(c => c.Post)
                .Include(c => c.Product)
                .Include(c => c.Program)
                .Include(c => c.Author)
                .Where(c => c.AuthorId == id)
                .ToListAsync();

            if (comments == null)
            {
                throw new ArgumentNullException(string.Format(ServicesConstants.InvalidUserId, id));
            }

            var commentsViewModel = this.mapper.Map<IList<CommentAdminViewModel>>(comments);

            return commentsViewModel;
        }

        public async Task<IList<OrdersAdminViewModel>> GetAllOrdersByUserIdAsync(string id)
        {
            var orders = await this.dbContext.Orders
                 .Include(o => o.Products)
                 .Where(c => c.UserId == id)
                 .ToListAsync();

            if (orders == null)
            {
                throw new ArgumentNullException(string.Format(ServicesConstants.InvalidUserId, id));
            }

            var ordersViewModel = this.mapper.Map<IList<OrdersAdminViewModel>>(orders);

            return ordersViewModel;
        }

        public async Task<IList<AddressesAdminViewModel>> GetAllAddressesByUserIdAsync(string id)
        {
            var addresses = await this.dbContext.Addresses
                .Include(a => a.City)
                .Where(c => c.UserId == id)
                .ToListAsync();

            if (addresses == null)
            {
                throw new ArgumentNullException(string.Format(ServicesConstants.InvalidUserId, id));
            }

            var addressesViewModel = this.mapper.Map<IList<AddressesAdminViewModel>>(addresses);

            return addressesViewModel;
        }

        public async Task<IList<OrderProductsAdminViewModel>> GetAllProductsByOrderIdAsync(string id)
        {
            var products = await this.dbContext.OrderProducts
                .Include(op => op.Product)
                .Where(o => o.OrderId == id)
                .ToListAsync();

            if (products == null)
            {
                throw new ArgumentNullException(string.Format(ServicesConstants.InvalidUserId, id));
            }

            var productsViewModel = this.mapper.Map<IList<OrderProductsAdminViewModel>>(products);

            return productsViewModel;
        }

        public async Task UserSubscribeAsync(ApplicationUser user)
        {
            user.HasSubscribe = true;

            this.dbContext.Update(user);

            await this.dbContext.SaveChangesAsync();
        }

        public async Task<IList<RequestsAdminViewModel>> GetAllRequestsAsync()
        {
            var requests = await this.dbContext.UserRequests
                 .ToListAsync();

            var requestsViewModel = this.mapper.Map<IList<RequestsAdminViewModel>>(requests);

            return requestsViewModel;
        }

        public async Task<UserAdminEditViewModel> GetUserToEditAsync(string id)
        {
            var userFromDb = await this.dbContext.Users
                 .FirstOrDefaultAsync(u => u.Id == id);

            if (userFromDb == null)
            {
                throw new ArgumentNullException(string.Format(ServicesConstants.InvalidUserId, id));
            }

            var userViewModel = this.mapper.Map<UserAdminEditViewModel>(userFromDb);

            return userViewModel;
        }

        public async Task EditUserAsync(UserAdminEditViewModel inputModel)
        {
            var userFromDb = await this.dbContext.Users
                 .FirstOrDefaultAsync(u => u.Id == inputModel.Id);

            if (userFromDb == null)
            {
                throw new ArgumentNullException(string.Format(ServicesConstants.InvalidUserId, inputModel.Id));
            }

            userFromDb.HasCoupon = inputModel.HasCoupon;

            userFromDb.HasMembership = inputModel.HasMembership;

            userFromDb.MembershipExpirationDate = inputModel.MembershipExpirationDate;

            userFromDb.HasSubscribe = inputModel.HasSubscribe;

            this.dbContext.Update(userFromDb);

            await this.dbContext.SaveChangesAsync();
        }

        public async Task<string> GetAdminIdAsync()
        {
            var adminId = await this.dbContext.Users
                 .Where(u => u.FirstName == ServicesConstants.AdministratorFirstName)
                 .Where(u => u.LastName == ServicesConstants.AdministratorLastName)
                 .Where(u => u.Email == ServicesConstants.AdministratorEmail)
                 .Select(u => u.Id)
                 .FirstOrDefaultAsync();

            return adminId;
        }
    }
}
