namespace MyCalisthenicApp.Services.Contracts
{
    using System.Threading.Tasks;

    using MyCalisthenicApp.ViewModels.Coupons;

    public interface IUsersService
    {
        Task AddDiscountToUser(CouponViewModel inputModel);
    }
}
