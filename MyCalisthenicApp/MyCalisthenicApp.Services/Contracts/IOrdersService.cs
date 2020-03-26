namespace MyCalisthenicApp.Services.Contracts
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using MyCalisthenicApp.Models.ShopEntities;
    using MyCalisthenicApp.ViewModels.Orders;
    using MyCalisthenicApp.ViewModels.Suppliers;

    public interface IOrdersService
    {
        Task CreateOrderAsync(Product product);

        Task CreateMembershipToOrder(decimal? price);

        Task<int> ShoppingBagProductsCount();

        Task ChangeQuantity(string id, int quantity);

        Task CreateAddressToOrder(AddressInputViewModel inputModel);

        Task SetDeliveryPriceToOrderAsync(decimal deliveryPrice);

        Task<IEnumerable<SupplierViewModel>> GetAllSuppliersAsync();
    }
}
