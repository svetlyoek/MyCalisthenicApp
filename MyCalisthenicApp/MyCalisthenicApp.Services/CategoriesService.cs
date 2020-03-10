namespace MyCalisthenicApp.Services
{
    using System.Linq;
    using System.Threading.Tasks;

    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using MyCalisthenicApp.Data;
    using MyCalisthenicApp.Services.Contracts;
    using MyCalisthenicApp.ViewModels.Categories;

    public class CategoriesService : ICategoriesService
    {
        private readonly MyCalisthenicAppDbContext dbContext;
        private readonly IMapper mapper;

        public CategoriesService(MyCalisthenicAppDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<CategoryViewModel> GetCategoryByProgramId(string id)
        {
            var category = await this.dbContext
                .ProgramCategories
                .Include(cm => cm.Comments)
                .Include(ex => ex.Exercises)
                .Where(c => c.Programs.Any(p => p.Id == id))
                .FirstOrDefaultAsync();

            var categoryViewModel = this.mapper.Map<CategoryViewModel>(category);

            return categoryViewModel;
        }
    }
}
