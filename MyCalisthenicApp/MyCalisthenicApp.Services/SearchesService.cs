namespace MyCalisthenicApp.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using MyCalisthenicApp.Data;
    using MyCalisthenicApp.Services.Contracts;
    using MyCalisthenicApp.ViewModels.Home;
    using MyCalisthenicApp.ViewModels.Posts;
    using MyCalisthenicApp.ViewModels.Products;
    using MyCalisthenicApp.ViewModels.Programs;

    public class SearchesService : ISearchesService
    {
        private readonly MyCalisthenicAppDbContext dbContext;
        private readonly IMapper mapper;

        public SearchesService(MyCalisthenicAppDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<object>> GetElementsBySearchTextAsync(NavbarSearchViewModel inputModel)
        {
            if (inputModel.Text == null || inputModel.Text.Length < 4)
            {
                return null;
            }
            else if (inputModel.Text.Length >= 4)
            {
                var programs = await this.dbContext.Programs
                 .Where(p => p.IsDeleted == false)
                 .Include(i => i.Images)
                 .Where(p => p.Category.Name.ToLower().Contains(inputModel.Text.ToLower()) ||
                 p.Description.ToLower().Contains(inputModel.Text.ToLower()) ||
                 p.Title.ToLower().Contains(inputModel.Text.ToLower()) ||
                 p.Category.Description.ToLower().Contains(inputModel.Text.ToLower()))
                 .ToListAsync();

                if (programs.Any())
                {
                    var programsViewModel = this.mapper.Map<IEnumerable<ProgramViewModel>>(programs);

                    return programsViewModel;
                }

                var products = await this.dbContext.Products
                   .Where(p => p.IsDeleted == false)
                    .Include(i => i.Images)
                    .Include(c => c.Category)
                    .Include(cm => cm.Comments)
                     .Where(p => p.Category.Name.ToLower().Contains(inputModel.Text.ToLower()) ||
                     p.Description.ToLower().Contains(inputModel.Text.ToLower()) ||
                     p.Name.ToLower().Contains(inputModel.Text.ToLower()))
                    .ToListAsync();

                if (products.Any())
                {
                    var productsViewModel = this.mapper.Map<IEnumerable<ProductsViewModel>>(products);

                    return productsViewModel;
                }

                var posts = await this.dbContext.Post
               .Include(i => i.Images)
               .Include(au => au.Author)
               .Include(cm => cm.Comments)
               .Where(p => p.IsPublic == true)
                .Where(c => c.IsDeleted == false)
                .Where(p => p.Title.ToLower().Contains(inputModel.Text.ToLower()) ||
                 p.Category.Name.ToLower().Contains(inputModel.Text.ToLower()) ||
                 p.Description.ToLower().Contains(inputModel.Text.ToLower()) ||
                 p.Author.FirstName.ToLower().Contains(inputModel.Text.ToLower()) ||
                 p.Author.LastName.ToLower().Contains(inputModel.Text.ToLower()))
                .ToListAsync();

                if (posts.Any())
                {
                    var allPosts = this.mapper.Map<IEnumerable<PostDetailsViewModel>>(posts);

                    return allPosts;
                }
            }

            return null;
        }
    }
}
