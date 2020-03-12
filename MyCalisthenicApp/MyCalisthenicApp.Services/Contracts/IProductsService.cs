namespace MyCalisthenicApp.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using MyCalisthenicApp.ViewModels.Products;

    public interface IProductsService
    {
        Task<IEnumerable<ProductsHomePopularViewModel>> GetPopularProductsAsync();

        Task<IEnumerable<ProductsViewModel>> GetAllProductsAsync();

        Task<IEnumerable<ProductsViewModel>> GetProductsByCategory(string name);
    }
}
