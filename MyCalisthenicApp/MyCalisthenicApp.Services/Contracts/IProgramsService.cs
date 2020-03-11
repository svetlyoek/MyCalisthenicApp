namespace MyCalisthenicApp.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using MyCalisthenicApp.ViewModels.Programs;

    public interface IProgramsService
    {
        Task<IEnumerable<HomePopularProgramsViewModel>> GetFivePopularProgramsAsync();

        Task<ProgramDetailsViewModel> GetProgramDetailsByIdAsync(string id);

        Task<IEnumerable<ProgramViewModel>> GetAllProgramsAsync();
    }
}
