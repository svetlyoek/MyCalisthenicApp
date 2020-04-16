namespace MyCalisthenicApp.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using MyCalisthenicApp.Models.ShopEntities;
    using MyCalisthenicApp.ViewModels.OrderProducts;
    using MyCalisthenicApp.ViewModels.Products;

    public interface IProductsService
    {
        Task<IEnumerable<ProductsHomePopularViewModel>> GetPopularProductsAsync();

        Task<IEnumerable<ProductsViewModel>> GetAllProductsAsync();

        Task<IList<ProductsAdminViewModel>> GetProductsForAdminAsync();

        Task<IEnumerable<ProductsViewModel>> GetProductsByCategoryAsync(string name);

        Task<IEnumerable<ProductsViewModel>> GetProductsAndSortAsync(string sort);

        Task<ProductDetailsViewModel> GetProductByIdAsync(string id);

        Task<ProductAdminEditViewModel> GetAdminProductByIdAsync(string id);

        Task EditProductAsync(ProductAdminEditViewModel inputModel);

        Task CreateProductAsync(ProductAdminCreateViewModel inputModel);

        Task<OrderProductAdminEditViewModel> GetOrderProductByIdAsync(string id);

        Task EditOrderProductAsync(OrderProductAdminEditViewModel inputModel);

        Task<IList<string>> GetAllLikesByProductIdAsync(string id);

        Task AddRatingAsync(string id);

        bool ProductsExistsById(string id);

        Task<Product> GetProductAsync(string id);

        Task<IList<ProductsShoppingBagViewModel>> GetShoppingBagProductsAsync();

        Task RemoveProductFromShoppingBagAsync(string id);
    }
}
