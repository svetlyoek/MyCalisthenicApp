namespace MyCalisthenicApp.Services
{
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
    using MyCalisthenicApp.Models.TrainingEntities.Enums;
    using MyCalisthenicApp.Services.Contracts;
    using MyCalisthenicApp.ViewModels.Exercises;

    public class ExercisesService : IExercisesService
    {
        private readonly MyCalisthenicAppDbContext dbContext;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;

        public ExercisesService(MyCalisthenicAppDbContext dbContext, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task<IEnumerable<ExercisesViewModel>> GetExercisesByCategoryIdAsync(string id)
        {
            var userId = this.GetLoggedUserId();

            var userFromDb = await this.GetLoggedUserByIdAsync(userId);

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
