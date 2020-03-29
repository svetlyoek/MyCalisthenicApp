namespace MyCalisthenicApp.Services.Contracts
{
    using System.Threading.Tasks;

    using MyCalisthenicApp.Models;
    using MyCalisthenicApp.ViewModels.Coupons;

    public interface IUsersService
    {
        Task AddDiscountToUserAsync(CouponViewModel inputModel);

        Task<ApplicationUser> GetLoggedUserByIdAsync(string userId);

        Task<bool> CheckUserMembershipAsync();

        string GetLoggedUserId();
    }
}
