namespace MyCalisthenicApp.Services.Contracts
{
    using System.Threading.Tasks;

    using MyCalisthenicApp.Models;
    using MyCalisthenicApp.ViewModels.Coupons;

    public interface IUsersService
    {
        Task AddDiscountToUser(CouponViewModel inputModel);

        Task<ApplicationUser> GetLoggedUserById(string userId);

        Task<bool> CheckUserMembershipAsync();

        string GetLoggedUserId();
    }
}
