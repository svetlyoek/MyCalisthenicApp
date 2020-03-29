namespace MyCalisthenicApp.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using AutoMapper;
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;
    using MyCalisthenicApp.Data;
    using MyCalisthenicApp.Models;
    using MyCalisthenicApp.Models.Enums;
    using MyCalisthenicApp.Services.Common;
    using MyCalisthenicApp.Services.Contracts;
    using MyCalisthenicApp.ViewModels.Programs;

    public class ProgramsService : IProgramsService
    {
        private readonly MyCalisthenicAppDbContext dbContext;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;

        public ProgramsService(MyCalisthenicAppDbContext dbContext, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
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
            var program = await this.dbContext.Programs
                .FirstOrDefaultAsync(p => p.Id == id);

            var userId = this.GetLoggedUserId();

            var userFromDb = await this.GetLoggedUserByIdAsync(userId);

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

            this.dbContext.Update(program);

            await this.dbContext.SaveChangesAsync();
        }

        public bool GetProgramById(string id)
        {
            return this.dbContext.Programs
                .Where(p => p.IsDeleted == false)
                .Any(p => p.Id == id);
        }

        private string GetLoggedUserId()
        {
            var userId = this.httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            return userId;
        }

        private async Task<ApplicationUser> GetLoggedUserByIdAsync(string userId)
        {
            var userFromDb = await this.dbContext.Users.
                Where(u => u.IsDeleted == false)
                .FirstOrDefaultAsync(u => u.Id == userId);

            return userFromDb;
        }
    }
}
