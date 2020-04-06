namespace MyCalisthenicApp.Services
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using MyCalisthenicApp.Data;
    using MyCalisthenicApp.Models;
    using MyCalisthenicApp.Models.BlogEntities;
    using MyCalisthenicApp.Models.ShopEntities;
    using MyCalisthenicApp.Services.Common;
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

        public async Task CreateBlogCategoryAsync(BlogCategoryAdminCreateViewModel inputModel)
        {
            var blogCategory = new BlogCategory
            {
                Name = inputModel.Name,
            };

            await this.dbContext.BlogCategories.AddAsync(blogCategory);

            await this.dbContext.SaveChangesAsync();
        }

        public async Task CreateProductCategoryAsync(ProductCategoryAdminCreateViewModel inputModel)
        {
            var productCategory = new ProductCategory
            {
                Name = inputModel.Name,
            };

            await this.dbContext.ProductCategories.AddAsync(productCategory);

            await this.dbContext.SaveChangesAsync();
        }

        public async Task CreateProgramCategoryAsync(ProgramCategoryAdminCreateViewModel inputModel)
        {
            var programCategory = new ProgramCategory
            {
                Name = inputModel.Name,
                Description = inputModel.Description,
            };

            await this.dbContext.ProgramCategories.AddAsync(programCategory);

            await this.dbContext.SaveChangesAsync();
        }

        public async Task<CategoryViewModel> GetCategoryByProgramIdAsync(string id)
        {
            var category = await this.dbContext
                .ProgramCategories
                .Include(ex => ex.Exercises)
                .Where(c => c.Programs.Any(p => p.Id == id))
                .Where(c => c.IsDeleted == false)
                .FirstOrDefaultAsync();

            if (category == null)
            {
                throw new ArgumentNullException(string.Format(ServicesConstants.InvalidProgramCategoryId, id));
            }

            var categoryViewModel = this.mapper.Map<CategoryViewModel>(category);

            return categoryViewModel;
        }
    }
}
