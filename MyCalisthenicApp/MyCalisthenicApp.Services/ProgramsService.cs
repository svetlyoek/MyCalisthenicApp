namespace MyCalisthenicApp.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using MyCalisthenicApp.Data;
    using MyCalisthenicApp.Models;
    using MyCalisthenicApp.Models.Enums;
    using MyCalisthenicApp.Models.TrainingEntities.Enums;
    using MyCalisthenicApp.Services.Common;
    using MyCalisthenicApp.Services.Contracts;
    using MyCalisthenicApp.ViewModels.Programs;

    public class ProgramsService : IProgramsService
    {
        private readonly MyCalisthenicAppDbContext dbContext;
        private readonly IMapper mapper;
        private readonly IUsersService usersService;
        private readonly ICategoriesService categoriesService;

        public ProgramsService(
            MyCalisthenicAppDbContext dbContext,
            IMapper mapper,
            IUsersService usersService,
            ICategoriesService categoriesService)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.usersService = usersService;
            this.categoriesService = categoriesService;
        }

        public async Task<IEnumerable<ProgramViewModel>> GetAllProgramsAsync()
        {
            var programs = await this.dbContext.Programs
                .Include(i => i.Images)
                 .Where(p => p.IsDeleted == false)
                 .Where(p => p.Category.IsDeleted == false)
                 .ToListAsync();

            var programsViewModel = this.mapper.Map<IEnumerable<ProgramViewModel>>(programs);

            return programsViewModel;
        }

        public async Task<IEnumerable<HomePopularProgramsViewModel>> GetFivePopularProgramsAsync()
        {
            var popularPrograms = await this.dbContext.Programs
                .Include(i => i.Images)
                .Where(p => p.IsDeleted == false)
                .Where(p => p.Category.IsDeleted == false)
                .Take(5)
                .ToListAsync();

            var programsViewModel = this.mapper.Map<IEnumerable<HomePopularProgramsViewModel>>(popularPrograms);

            return programsViewModel;
        }

        public async Task<ProgramDetailsViewModel> GetProgramDetailsByIdAsync(string id)
        {
            var program = await this.dbContext.Programs
               .Include(p => p.Images)
                .Include(c => c.Category)
                .Include(cm => cm.Comments)
                .Where(p => p.IsDeleted == false)
                .Where(p => p.Category.IsDeleted == false)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (program == null)
            {
                throw new ArgumentNullException(string.Format(ServicesConstants.InvalidProgram, id));
            }

            var programViewModel = this.mapper.Map<ProgramDetailsViewModel>(program);

            return programViewModel;
        }

        public async Task<IEnumerable<ProgramViewModel>> GetProgramsByCategoryAsync(string type)
        {
            var programType = (ProgramType)Enum.Parse(typeof(ProgramType), type);

            var programs = await this.dbContext.Programs
                .Include(i => i.Images)
                .Where(p => p.Type == programType)
                .Where(p => p.IsDeleted == false)
                .Where(p => p.Category.IsDeleted == false)
                .Select(p => p).ToListAsync();

            var programsViewModel = this.mapper.Map<IEnumerable<ProgramViewModel>>(programs);

            return programsViewModel;
        }

        public async Task AddRatingAsync(string id)
        {
            var program = await this.dbContext.Programs
                .FirstOrDefaultAsync(p => p.Id == id);

            if (program == null)
            {
                throw new ArgumentNullException(string.Format(ServicesConstants.InvalidProgramId, id));
            }

            var userId = this.usersService.GetLoggedUserId();

            var userFromDb = await this.usersService.GetLoggedUserByIdAsync(userId);

            if (userFromDb == null)
            {
                throw new NullReferenceException(string.Format(ServicesConstants.InvalidUserId, userId));
            }

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
                .Where(p => p.IsDeleted == false)
                .Where(p => p.Category.IsDeleted == false)
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

            if (program == null)
            {
                throw new ArgumentNullException(string.Format(ServicesConstants.InvalidProgramId, id));
            }

            if (program.LikesUsersNames == null)
            {
                program.LikesUsersNames = new List<string>();
            }

            var likes = program.LikesUsersNames;

            return likes;
        }

        public async Task<ProgramAdminEditViewModel> GetProgramByIdAsync(string id)
        {
            var program = await this.dbContext.Programs
                 .Include(p => p.Category)
                 .FirstOrDefaultAsync(p => p.Id == id);

            if (program == null)
            {
                throw new ArgumentNullException(string.Format(ServicesConstants.InvalidProgramId, id));
            }

            var categories = this.categoriesService.GetAllProgramCategories();

            var programViewModel = this.mapper.Map<ProgramAdminEditViewModel>(program);

            programViewModel.Categories = categories;

            return programViewModel;
        }

        public async Task EditProgramAsync(ProgramAdminEditViewModel inputModel)
        {
            if (!this.dbContext.ProgramCategories.Any(u => u.Id == inputModel.CategoryId))
            {
                throw new ArgumentNullException(string.Format(ServicesConstants.InvalidProgramCategoryId, inputModel.CategoryId));
            }

            var program = await this.dbContext.Programs
                 .Include(p => p.Category)
                 .FirstOrDefaultAsync(p => p.Id == inputModel.Id);

            if (program == null)
            {
                throw new ArgumentNullException(string.Format(ServicesConstants.InvalidProgramId, inputModel.Id));
            }

            Enum.TryParse(inputModel.Type, true, out ProgramType programType);

            Enum.TryParse(inputModel.MembershipType, true, out MembershipType membershipType);

            program.IsDeleted = inputModel.IsDeleted;

            program.DeletedOn = inputModel.DeletedOn;

            program.CreatedOn = inputModel.CreatedOn;

            program.ModifiedOn = inputModel.ModifiedOn;

            program.Title = inputModel.Title;

            program.Description = inputModel.Description;

            program.MembershipType = membershipType;

            program.CategoryId = inputModel.CategoryId;

            program.Category.Name = inputModel.CategoryName;

            program.Category.Description = inputModel.CategoryDescription;

            program.Category.IsDeleted = inputModel.CategoryIsDeleted;

            program.Category.Rating = inputModel.CategoryRating;

            program.Rating = inputModel.Rating;

            program.Type = programType;

            this.dbContext.Update(program);

            await this.dbContext.SaveChangesAsync();
        }

        public async Task CreateProgramAsync(ProgramAdminCreateViewModel inputModel)
        {
            if (!this.dbContext.ProgramCategories.Any(u => u.Id == inputModel.CategoryId))
            {
                throw new ArgumentNullException(string.Format(ServicesConstants.InvalidProgramCategoryId, inputModel.CategoryId));
            }

            var program = new Program
            {
                Title = inputModel.Title,
                Type = inputModel.Type,
                Description = inputModel.Description,
                Rating = inputModel.Rating,
                MembershipType = inputModel.MembershipType,
                CategoryId = inputModel.CategoryId,
            };

            await this.dbContext.Programs.AddAsync(program);

            await this.dbContext.SaveChangesAsync();
        }
    }
}
