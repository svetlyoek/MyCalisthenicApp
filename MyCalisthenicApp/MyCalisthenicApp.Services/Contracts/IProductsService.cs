namespace MyCalisthenicApp.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using MyCalisthenicApp.Models.ShopEntities;
    using MyCalisthenicApp.ViewModels.Coupons;
    using MyCalisthenicApp.ViewModels.Products;

    public interface IProductsService
    {
        Task<IEnumerable<ProductsHomePopularViewModel>> GetPopularProductsAsync();

        Task<IEnumerable<ProductsViewModel>> GetAllProductsAsync();

        Task<IEnumerable<ProductsViewModel>> GetProductsByCategoryAsync(string name);

        Task<IEnumerable<ProductsViewModel>> GetProductsAndSortAsync(string sort);

        Task<ProductDetailsViewModel> GetProductsByIdAsync(string id);

        Task AddRatingAsync(string id);

        bool ProductsExistsById(string id);

        Task<Product> GetProductAsync(string id);

        Task<IList<ProductsShoppingBagViewModel>> GetShoppingBagProductsAsync();

        Task RemoveProductFromShoppingBagAsync(string id);
    }
}
