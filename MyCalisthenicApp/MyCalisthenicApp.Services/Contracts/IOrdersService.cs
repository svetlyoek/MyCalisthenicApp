namespace MyCalisthenicApp.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using MyCalisthenicApp.Models.ShopEntities;
    using MyCalisthenicApp.ViewModels.Addresses;
    using MyCalisthenicApp.ViewModels.Orders;

    public interface IOrdersService
    {
        Task<bool> CreateOrderAsync(Product product);

        Task CreateMembershipToOrderAsync(decimal? price);

        Task<int> ShoppingBagProductsCountAsync();

        Task ChangeQuantityAsync(string id, int quantity);

        Task CreateAddressToOrderAsync(AddressInputViewModel inputModel);

        Task<bool> SetDeliveryPriceToOrderAsync(decimal deliveryPrice);

        Task<bool> SendOrderAsync(string id);

        Task<OrderCheckoutViewModel> GetOrderToSendAsync();

        Task<OrderAdminEditViewModel> GetOrderByIdAsync(string id);

        Task<IEnumerable<OrdersViewModel>> GetAllOrdersAsync();

        Task EditOrderAsync(OrderAdminEditViewModel inputModel);
    }
}
