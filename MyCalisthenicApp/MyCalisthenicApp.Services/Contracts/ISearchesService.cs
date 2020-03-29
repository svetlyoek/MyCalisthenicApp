namespace MyCalisthenicApp.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using MyCalisthenicApp.ViewModels.Home;

    public interface ISearchesService
    {
        Task<IEnumerable<object>> GetElementsBySearchTextAsync(NavbarSearchViewModel inputModel);
    }
}
