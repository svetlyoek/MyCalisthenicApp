namespace MyCalisthenicApp.Services.Contracts
{
    using System.Threading.Tasks;

    using MyCalisthenicApp.Models.ShopEntities;
    using MyCalisthenicApp.ViewModels.Orders;

    public interface IOrdersService
    {
        Task CreateOrderAsync(Product product);

        Task CreateMembershipToOrder(decimal? price);

        Task<int> ShoppingBagProductsCount();

        Task ChangeQuantity(string id, int quantity);

        Task CreateAddressToOrder(AddressInputViewModel inputModel);
    }
}
