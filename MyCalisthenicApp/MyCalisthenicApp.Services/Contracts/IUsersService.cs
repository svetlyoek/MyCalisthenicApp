namespace MyCalisthenicApp.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using MyCalisthenicApp.Models;
    using MyCalisthenicApp.ViewModels.Coupons;

    public interface IUsersService
    {
        Task AddDiscountToUserAsync(CouponViewModel inputModel);

        Task<ApplicationUser> GetLoggedUserByIdAsync(string userId);

        Task<ApplicationUser> GetBannedUserAsync(string email);

        Task GetBannedUserToUnblockAsync(string id);

        Task GetUserToBlockAsync(string id);

        Task<bool> CheckUserMembershipAsync();

        Task<IList<ApplicationUser>> GetAllUsersAsync();

        Task<IList<ApplicationUser>> GetBannedUsersAsync();

        string GetLoggedUserId();
    }
}
