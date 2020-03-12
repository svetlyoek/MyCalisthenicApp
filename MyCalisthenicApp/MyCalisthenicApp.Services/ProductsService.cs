namespace MyCalisthenicApp.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using MyCalisthenicApp.Data;
    using MyCalisthenicApp.Services.Contracts;
    using MyCalisthenicApp.ViewModels.Products;

    public class ProductsService : IProductsService
    {
        private readonly MyCalisthenicAppDbContext dbContext;
        private readonly IMapper mapper;

        public ProductsService(MyCalisthenicAppDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<ProductsViewModel>> GetAllProductsAsync()
        {
            var products = await this.dbContext
                .Products.Include(i => i.Images)
                .Include(c => c.Category)
                .ThenInclude(p => p.Products)
                .ToListAsync();

            var productsViewModel = this.mapper.Map<IEnumerable<ProductsViewModel>>(products);

            return productsViewModel;
        }

        public async Task<IEnumerable<ProductsHomePopularViewModel>> GetPopularProductsAsync()
        {
            var products = await this.dbContext
                .Products.Include(i => i.Images)
                .Include(c => c.Category)
                .Take(8)
                .ToListAsync();

            var productsViewModel = this.mapper.Map<IEnumerable<ProductsHomePopularViewModel>>(products);

            return productsViewModel;
        }

        public async Task<IEnumerable<ProductsViewModel>> GetProductsByCategory(string name)
        {
            var products = await this.dbContext.
                 Products.Include(i => i.Images)
                 .Include(c => c.Category)
                 .ThenInclude(p => p.Products)
                 .Where(p => p.Category.Name == name)
                 .ToListAsync();

            var productsViewModel = this.mapper.Map<IEnumerable<ProductsViewModel>>(products);

            return productsViewModel;
        }
    }
}
