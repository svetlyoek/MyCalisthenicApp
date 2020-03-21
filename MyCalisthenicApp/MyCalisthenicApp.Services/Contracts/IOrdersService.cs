﻿namespace MyCalisthenicApp.Services.Contracts
{
    using System.Threading.Tasks;

    using MyCalisthenicApp.Models.ShopEntities;

    public interface IOrdersService
    {
        Task CreateOrderAsync(Product product);

        Task CreateMembershipToOrder(decimal? price);

        Task<int> ShoppingBagProductsCount();

        Task ChangeQuantity(string id, int quantity);
    }
}
