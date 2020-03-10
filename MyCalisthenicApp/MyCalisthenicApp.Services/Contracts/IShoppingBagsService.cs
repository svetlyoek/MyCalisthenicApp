namespace MyCalisthenicApp.Services.Contracts
{
    using System.Threading.Tasks;

    using MyCalisthenicApp.ViewModels.ShoppingBags;

    public interface IShoppingBagsService
    {
        Task<ShoppingBagIndexProductsCountViewModel> ShoppingBagProducts();
    }
}
