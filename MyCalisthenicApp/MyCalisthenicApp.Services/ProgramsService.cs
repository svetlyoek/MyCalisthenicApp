namespace MyCalisthenicApp.Services
{
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using MyCalisthenicApp.Data;
    using MyCalisthenicApp.Services.Contracts;
    using MyCalisthenicApp.ViewModels.Programs;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class ProgramsService : IProgramsService
    {
        private readonly MyCalisthenicAppDbContext dbContext;
        private readonly IMapper mapper;

        public ProgramsService(MyCalisthenicAppDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<HomePopularProgramsViewModel>> GetFivePopularProgramsAsync()
        {
            var popularPrograms = await this.dbContext.Programs
                .Include(i => i.Images)
                .Take(5)
                .ToListAsync();

            var programsViewModel = mapper.Map<IEnumerable<HomePopularProgramsViewModel>>(popularPrograms);

            return programsViewModel;
        }
    }
}
