namespace MyCalisthenicApp.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using MyCalisthenicApp.Data;
    using MyCalisthenicApp.Models.Enums;
    using MyCalisthenicApp.Models.TrainingEntities.Enums;
    using MyCalisthenicApp.Services.Contracts;
    using MyCalisthenicApp.ViewModels.Exercises;

    public class ExercisesService : IExercisesService
    {
        private readonly MyCalisthenicAppDbContext dbContext;
        private readonly IMapper mapper;
        private readonly IUsersService usersService;

        public ExercisesService(MyCalisthenicAppDbContext dbContext, IMapper mapper, IUsersService usersService)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.usersService = usersService;
        }

        public async Task<IEnumerable<ExercisesViewModel>> GetExercisesByCategoryIdAsync(string id)
        {
            var userId = this.usersService.GetLoggedUserId();

            var userFromDb = await this.usersService.GetLoggedUserByIdAsync(userId);

            var exercises = await this.dbContext.Exercises
                 .Include(i => i.Images)
                 .Where(e => e.ProgramCategoryId == id)
                  .Where(e => e.IsDeleted == false)
                 .Select(e => e)
                 .ToListAsync();

            var program = await this.dbContext.Programs
                .Where(p => p.IsDeleted == false)
                .Where(p => p.CategoryId == id)
                .FirstOrDefaultAsync();

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
    }
}
