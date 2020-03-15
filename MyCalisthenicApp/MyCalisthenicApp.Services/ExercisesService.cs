namespace MyCalisthenicApp.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using MyCalisthenicApp.Data;
    using MyCalisthenicApp.Services.Contracts;
    using MyCalisthenicApp.ViewModels.Exercises;

    public class ExercisesService : IExercisesService
    {
        private readonly MyCalisthenicAppDbContext dbContext;
        private readonly IMapper mapper;

        public ExercisesService(MyCalisthenicAppDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<ExercisesViewModel>> GetExercisesByCategoryIdAsync(string id)
        {
            var exercises = await this.dbContext.Exercises
                 .Include(i => i.Images)
                 .Where(e => e.ProgramCategoryId == id)
                  .Where(c => c.IsDeleted == false)
                 .Select(e => e)
                 .ToListAsync();

            var exercisesViewModel = this.mapper.Map<IEnumerable<ExercisesViewModel>>(exercises);

            return exercisesViewModel;
        }
    }
}
