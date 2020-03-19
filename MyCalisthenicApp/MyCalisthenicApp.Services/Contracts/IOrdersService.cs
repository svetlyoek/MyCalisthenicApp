namespace MyCalisthenicApp.Services.Contracts
{
    using System.Threading.Tasks;

    using MyCalisthenicApp.Models.ShopEntities;

    public interface IOrdersService
    {
        Task CreateOrderAsync(Product product);

        Task<int> ShoppingBagProductsCount();
    }
}
