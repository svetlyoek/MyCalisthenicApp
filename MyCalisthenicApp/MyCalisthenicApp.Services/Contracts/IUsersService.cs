namespace MyCalisthenicApp.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using MyCalisthenicApp.Models;
    using MyCalisthenicApp.Models.ShopEntities;
    using MyCalisthenicApp.ViewModels.Coupons;

    public interface IUsersService
    {
        Task AddDiscountToUserAsync(CouponViewModel inputModel);

        Task<ApplicationUser> GetLoggedUserByIdAsync(string userId);

        Task<ApplicationUser> GetBannedUserAsync(string email);

        Task<ApplicationUser> GetUserByEmailAsync(string email);

        Task<ApplicationUser> BlockUnblockUserByIdAsync(string id);

        Task<IList<OrderProduct>> GetAllProductsByOrderIdAsync(string id);

        Task<IList<Comment>> GetAllCommentsByUserIdAsync(string id);

        Task<IList<Order>> GetAllOrdersByUserIdAsync(string id);

        Task<IList<Address>> GetAllAddressesByUserIdAsync(string id);

        Task<bool> CheckUserMembershipAsync();

        Task<IList<ApplicationUser>> GetAllUsersAsync();

        Task<IList<ApplicationUser>> GetBannedUsersAsync();

        string GetLoggedUserId();
    }
}
