namespace MyCalisthenicApp.Services.Contracts
{
    using MyCalisthenicApp.ViewModels.Programs;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IProgramsService
    {
       Task<IEnumerable<HomePopularProgramsViewModel>> GetFivePopularProgramsAsync();
    }
}
