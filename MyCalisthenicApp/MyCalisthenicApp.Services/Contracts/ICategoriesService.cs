namespace MyCalisthenicApp.Services.Contracts
{
    using System.Threading.Tasks;

    using MyCalisthenicApp.ViewModels.Categories;

    public interface ICategoriesService
    {
        Task<CategoryViewModel> GetCategoryByProgramIdAsync(string id);

        Task CreateBlogCategoryAsync(BlogCategoryAdminCreateViewModel inputModel);

        Task CreateProgramCategoryAsync(ProgramCategoryAdminCreateViewModel inputModel);

        Task CreateProductCategoryAsync(ProductCategoryAdminCreateViewModel inputModel);
    }
}
