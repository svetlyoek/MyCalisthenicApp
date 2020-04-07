namespace MyCalisthenicApp.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using MyCalisthenicApp.ViewModels.Home;
    using MyCalisthenicApp.ViewModels.Products;
    using MyCalisthenicApp.ViewModels.Programs;

    public interface ISearchesService
    {
        Task<IEnumerable<ProgramViewModel>> GetProgramsBySearchTextAsync(SearchViewModel inputModel);

        Task<IEnumerable<ProductsViewModel>> GetProductsBySearchTextAsync(SearchViewModel inputModel);
    }
}
