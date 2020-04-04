namespace MyCalisthenicApp.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using MyCalisthenicApp.Models.ShopEntities;
    using MyCalisthenicApp.ViewModels.Addresses;
    using MyCalisthenicApp.ViewModels.Orders;
    using MyCalisthenicApp.ViewModels.Suppliers;

    public interface IOrdersService
    {
        Task<bool> CreateOrderAsync(Product product);

        Task CreateMembershipToOrderAsync(decimal? price);

        Task<int> ShoppingBagProductsCountAsync();

        Task ChangeQuantityAsync(string id, int quantity);

        Task CreateAddressToOrderAsync(AddressInputViewModel inputModel);

        Task SetDeliveryPriceToOrderAsync(decimal deliveryPrice);

        Task<IEnumerable<SupplierViewModel>> GetAllSuppliersAsync();

        Task<IList<SupplierAdminViewModel>> GetAllSuppliersForAdminAsync();

        Task<SupplierAdminEditViewModel> GetSupplierByIdAsync(string id);

        Task EditSupplierAsync(SupplierAdminEditViewModel inputModel);

        Task<bool> SendOrderAsync(string id);

        Task<OrderCheckoutViewModel> GetOrderToSendAsync();

        Task<OrderAdminEditViewModel> GetOrderByIdAsync(string id);

        Task EditOrderAsync(OrderAdminEditViewModel inputModel);
    }
}
