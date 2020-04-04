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
        private readonly IUsersService usersService;

        public ProgramsService(MyCalisthenicAppDbContext dbContext, IMapper mapper, IUsersService usersService)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.usersService = usersService;
        }

        public async Task<IEnumerable<ProgramViewModel>> GetAllProgramsAsync()
        {
            var programs = await this.dbContext
                .Programs
                  .Where(p => p.IsDeleted == false && p.Category.IsDeleted == false)
                .Include(i => i.Images)
                .ToListAsync();

            var programsViewModel = this.mapper.Map<IEnumerable<ProgramViewModel>>(programs);

            return programsViewModel;
        }

        public async Task<IEnumerable<HomePopularProgramsViewModel>> GetFivePopularProgramsAsync()
        {
            var popularPrograms = await this.dbContext.Programs
                .Include(i => i.Images)
                  .Where(p => p.IsDeleted == false && p.Category.IsDeleted == false)
                .Take(5)
                .ToListAsync();

            var programsViewModel = this.mapper.Map<IEnumerable<HomePopularProgramsViewModel>>(popularPrograms);

            return programsViewModel;
        }

        public async Task<ProgramDetailsViewModel> GetProgramDetailsByIdAsync(string id)
        {
            var program = await this.dbContext
                .Programs.Include(p => p.Images)
                  .Where(p => p.IsDeleted == false && p.Category.IsDeleted == false)
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
            var programType = (ProgramType)Enum.Parse(typeof(ProgramType), type);

            var programs = await this.dbContext
                .Programs.Include(i => i.Images)
                .Where(p => p.Type == programType)
                  .Where(p => p.IsDeleted == false && p.Category.IsDeleted == false)
                .Select(p => p).ToListAsync();

            var programsViewModel = this.mapper.Map<IEnumerable<ProgramViewModel>>(programs);

            return programsViewModel;
        }

        public async Task AddRatingAsync(string id)
        {
            var program = await this.dbContext.Programs
                .FirstOrDefaultAsync(p => p.Id == id);

            var userId = this.usersService.GetLoggedUserId();

            var userFromDb = await this.usersService.GetLoggedUserByIdAsync(userId);

            var userCredentials = userFromDb.FirstName + " " + userFromDb.LastName + ":" + userId;

            if (program.LikesUsersNames == null)
            {
                var likesUsersNames = new List<string>();

                program.LikesUsersNames = likesUsersNames;
            }

            if (!program.LikesUsersNames.Contains(userCredentials))
            {
                if (program.Rating == null)
                {
                    program.Rating = 1;
                }
                else
                {
                    program.Rating += 1;
                }

                program.LikesUsersNames.Add(userCredentials);
            }
            else if (program.LikesUsersNames.Contains(userCredentials))
            {
                if (program.Rating >= 1)
                {
                    program.Rating -= 1;
                }

                program.LikesUsersNames.Remove(userCredentials);
            }

            this.dbContext.Update(program);

            await this.dbContext.SaveChangesAsync();
        }

        public bool GetProgramById(string id)
        {
            return this.dbContext.Programs
                .Where(p => p.IsDeleted == false && p.Category.IsDeleted == false)
                .Any(p => p.Id == id);
        }

        public async Task<IList<ProgramsAdminViewModel>> GetAllProgramsForAdminAsync()
        {
            var programs = await this.dbContext.Programs
                 .Include(p => p.Images)
                 .Include(p => p.Category)
                 .ToListAsync();

            var programsViewModel = this.mapper.Map<IList<ProgramsAdminViewModel>>(programs);

            return programsViewModel;
        }

        public async Task<IList<string>> GetAllLikesByProgramIdAsync(string id)
        {
            var program = await this.dbContext.Programs
                 .Where(c => c.Id == id)
                 .FirstOrDefaultAsync();

            if (program.LikesUsersNames == null)
            {
                program.LikesUsersNames = new List<string>();
            }

            var likes = program.LikesUsersNames;

            return likes;
        }
    }
}
