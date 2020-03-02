namespace MyCalisthenicApp.Services.Contracts
{
    using MyCalisthenicApp.Models;
    using System.Threading.Tasks;

    public interface IShoppingCartsService
    {
        Task AssignShoppingCartToUser(ApplicationUser user);
    }
}
