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
    using MyCalisthenicApp.Models.TrainingEntities;
    using MyCalisthenicApp.Models.TrainingEntities.Enums;
    using MyCalisthenicApp.Services.Common;
    using MyCalisthenicApp.Services.Contracts;
    using MyCalisthenicApp.ViewModels.Exercises;

    public class ExercisesService : IExercisesService
    {
        private readonly MyCalisthenicAppDbContext dbContext;
        private readonly IMapper mapper;
        private readonly IUsersService usersService;
        private readonly ICategoriesService categoriesService;

        public ExercisesService(
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

        public async Task<IEnumerable<ExercisesViewModel>> GetExercisesByCategoryIdAsync(string id)
        {
            var userId = this.usersService.GetLoggedUserId();

            var userFromDb = await this.usersService.GetLoggedUserByIdAsync(userId);

            if (userFromDb == null)
            {
                throw new NullReferenceException(string.Format(ServicesConstants.InvalidUserId, userId));
            }

            var exercises = await this.dbContext.Exercises
                 .Include(i => i.Images)
                 .Where(e => e.ProgramCategoryId == id)
                  .Where(e => e.IsDeleted == false)
                 .Select(e => e)
                 .ToListAsync();

            if (exercises == null)
            {
                throw new ArgumentNullException(string.Format(ServicesConstants.InvalidProgramCategoryId, id));
            }

            var program = await this.dbContext.Programs
                .Where(p => p.IsDeleted == false)
                .Where(p => p.CategoryId == id)
                .FirstOrDefaultAsync();

            if (program == null)
            {
                throw new ArgumentNullException(string.Format(ServicesConstants.InvalidProgram));
            }

            if (userFromDb.HasMembership && program.MembershipType == MembershipType.Premium)
            {
                var exercisesViewModel = this.mapper.Map<IEnumerable<ExercisesViewModel>>(exercises);

                return exercisesViewModel;
            }

            if (program.MembershipType == MembershipType.Free && program.Type == ProgramType.Beginner)
            {
                var exercisesViewModel = this.mapper.Map<IEnumerable<ExercisesViewModel>>(exercises);

                return exercisesViewModel;
            }
            else
            {
                return Enumerable.Empty<ExercisesViewModel>();
            }
        }

        public async Task<IList<ExercisesAdminViewModel>> GetAllExercisesForAdminAsync()
        {
            var exercises = await this.dbContext.Exercises
                .Include(e => e.Images)
                .Include(e => e.ProgramCategory)
                .ToListAsync();

            var exercisesViewModel = this.mapper.Map<IList<ExercisesAdminViewModel>>(exercises);

            return exercisesViewModel;
        }

        public async Task<ExerciseAdminEditViewModel> GetExerciseByIdAsync(string id)
        {
            var exercise = await this.dbContext.Exercises
                 .Include(p => p.ProgramCategory)
                 .FirstOrDefaultAsync(e => e.Id == id);

            if (exercise == null)
            {
                throw new ArgumentNullException(string.Format(ServicesConstants.InvalidExerciseId, id));
            }

            var categories = this.categoriesService.GetAllProgramCategories();

            var exerciseViewModel = this.mapper.Map<ExerciseAdminEditViewModel>(exercise);

            exerciseViewModel.Categories = categories;

            return exerciseViewModel;
        }

        public async Task EditExerciseAsync(ExerciseAdminEditViewModel inputModel)
        {
            if (!this.dbContext.ProgramCategories.Any(pc => pc.Id == inputModel.ProgramCategoryId))
            {
                throw new ArgumentNullException(string.Format(ServicesConstants.InvalidProgramCategoryId, inputModel.ProgramCategoryId));
            }

            var exercise = await this.dbContext.Exercises
                  .Include(p => p.ProgramCategory)
                  .FirstOrDefaultAsync(p => p.Id == inputModel.Id);

            if (exercise == null)
            {
                throw new ArgumentNullException(string.Format(ServicesConstants.InvalidExerciseId, inputModel.Id));
            }

            exercise.IsDeleted = inputModel.IsDeleted;

            exercise.DeletedOn = inputModel.DeletedOn;

            exercise.CreatedOn = inputModel.CreatedOn;

            exercise.ModifiedOn = inputModel.ModifiedOn;

            exercise.Name = inputModel.Name;

            exercise.Description = inputModel.Description;

            exercise.VideoUrl = inputModel.VideoUrl;

            exercise.ProgramCategoryId = inputModel.ProgramCategoryId;

            exercise.ProgramCategory.Name = inputModel.ProgramCategoryName;

            exercise.ProgramCategory.Description = inputModel.ProgramCategoryDescription;

            exercise.ProgramCategory.IsDeleted = inputModel.ProgramCategoryIsDeleted;

            exercise.ProgramCategory.Rating = inputModel.ProgramCategoryRating;

            this.dbContext.Update(exercise);

            await this.dbContext.SaveChangesAsync();
        }

        public async Task CreateExerciseAsync(ExerciseAdminCreateViewModel inputModel)
        {
            if (!this.dbContext.ProgramCategories.Any(pc => pc.Id == inputModel.ProgramCategoryId))
            {
                throw new ArgumentNullException(string.Format(ServicesConstants.InvalidProgramCategoryId, inputModel.ProgramCategoryId));
            }

            var exercise = new Exercise
            {
                Name = inputModel.Name,
                Description = inputModel.Description,
                VideoUrl = inputModel.VideoUrl,
                ProgramCategoryId = inputModel.ProgramCategoryId,
            };

            await this.dbContext.Exercises.AddAsync(exercise);

            await this.dbContext.SaveChangesAsync();
        }
    }
}
