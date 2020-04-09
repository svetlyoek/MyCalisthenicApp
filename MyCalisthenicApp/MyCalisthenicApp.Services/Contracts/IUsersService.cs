namespace MyCalisthenicApp.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using MyCalisthenicApp.Models;
    using MyCalisthenicApp.ViewModels.Addresses;
    using MyCalisthenicApp.ViewModels.Comments;
    using MyCalisthenicApp.ViewModels.Coupons;
    using MyCalisthenicApp.ViewModels.OrderProducts;
    using MyCalisthenicApp.ViewModels.Orders;
    using MyCalisthenicApp.ViewModels.Requests;
    using MyCalisthenicApp.ViewModels.Users;

    public interface IUsersService
    {
        Task<bool> AddDiscountToUserAsync(CouponViewModel inputModel);

        Task<ApplicationUser> GetLoggedUserByIdAsync(string userId);

        Task<ApplicationUser> GetBannedUserAsync(string email);

        Task<ApplicationUser> GetUserByEmailAsync(string email);

        Task<ApplicationUser> BlockUnblockUserByIdAsync(string id);

        Task<UserAdminEditViewModel> GetUserToEditAsync(string id);

        Task EditUserAsync(UserAdminEditViewModel inputModel);

        Task<IList<OrderProductsAdminViewModel>> GetAllProductsByOrderIdAsync(string id);

        Task<IList<CommentAdminViewModel>> GetAllCommentsByUserIdAsync(string id);

        Task<IList<OrdersAdminViewModel>> GetAllOrdersByUserIdAsync(string id);

        Task<IList<OrdersAdminViewModel>> GetAllOrdersAsync();

        Task<IList<AddressesAdminViewModel>> GetAllAddressesByUserIdAsync(string id);

        Task<IList<RequestsAdminViewModel>> GetAllRequestsAsync();

        Task<string> GetAdminIdAsync();

        Task<bool> CheckUserMembershipAsync();

        Task<IList<UsersAdminViewModel>> GetAllUsersAsync();

        Task<IList<UsersAdminViewModel>> GetBannedUsersAsync();

        Task UserSubscribeAsync(ApplicationUser user);

        string GetLoggedUserId();
    }
}
