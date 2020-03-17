namespace MyCalisthenicApp.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using MyCalisthenicApp.Data;
    using MyCalisthenicApp.Models.Enums;
    using MyCalisthenicApp.Services.Common;
    using MyCalisthenicApp.Services.Contracts;
    using MyCalisthenicApp.ViewModels.Programs;

    public class ProgramsService : IProgramsService
    {
        private readonly MyCalisthenicAppDbContext dbContext;
        private readonly IMapper mapper;

        public ProgramsService(MyCalisthenicAppDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<ProgramViewModel>> GetAllProgramsAsync()
        {
            var programs = await this.dbContext
                .Programs
                  .Where(p => p.IsDeleted == false)
                .Include(i => i.Images)
                .ToListAsync();

            var programsViewModel = this.mapper.Map<IEnumerable<ProgramViewModel>>(programs);

            return programsViewModel;
        }

        public async Task<IEnumerable<HomePopularProgramsViewModel>> GetFivePopularProgramsAsync()
        {
            var popularPrograms = await this.dbContext.Programs
                .Include(i => i.Images)
                  .Where(p => p.IsDeleted == false)
                .Take(5)
                .ToListAsync();

            var programsViewModel = this.mapper.Map<IEnumerable<HomePopularProgramsViewModel>>(popularPrograms);

            return programsViewModel;
        }

        public async Task<ProgramDetailsViewModel> GetProgramDetailsByIdAsync(string id)
        {
            var program = await this.dbContext
                .Programs.Include(p => p.Images)
                  .Where(p => p.IsDeleted == false)
                .Include(c => c.Category)
                .Include(cm => cm.Comments)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (program == null)
            {
                throw new NullReferenceException(string.Format(ServicesConstants.InvalidProgram, id));
            }

            var programViewModel = this.mapper.Map<ProgramDetailsViewModel>(program);

            return programViewModel;
        }

        public async Task<IEnumerable<ProgramViewModel>> GetProgramsByCategoryAsync(string type)
        {
            var myEnum = (ProgramType)Enum.Parse(typeof(ProgramType), type);

            var programs = await this.dbContext
                .Programs.Include(i => i.Images)
                .Where(p => p.Type == myEnum)
                  .Where(p => p.IsDeleted == false)
                .Select(p => p).ToListAsync();

            var programsViewModel = this.mapper.Map<IEnumerable<ProgramViewModel>>(programs);

            return programsViewModel;
        }

        public async Task AddRatingAsync(string id)
        {
            var program = await this.dbContext.Programs.
                FirstOrDefaultAsync(p => p.Id == id);

            if (program.Rating == null)
            {
                program.Rating = 1;
            }
            else
            {
                program.Rating += 1;
            }

            this.dbContext.Update(program);

            await this.dbContext.SaveChangesAsync();
        }

        public bool GetProgramById(string id)
        {
            return this.dbContext.Programs
                .Where(p => p.IsDeleted == false)
                .Any(p => p.Id == id);
        }
    }
}
