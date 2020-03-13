namespace MyCalisthenicApp.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using MyCalisthenicApp.Data;
    using MyCalisthenicApp.Services.Common;
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

        // TODO Get only rated products
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

        public async Task<IEnumerable<ProductsViewModel>> GetProductsAndSortAsync(string sort)
        {
            var products = await this.dbContext
                .Products.Include(i => i.Images)
                .Include(c => c.Category)
                .ThenInclude(p => p.Products)
                .ToListAsync();

            if (sort == ServicesConstants.ProductsPriceAscendingSortEnum)
            {
                products = products.OrderBy(p => p.Price).Select(p => p).ToList();
            }

            if (sort == ServicesConstants.ProductsPriceDescendingSortEnum)
            {
                products = products.OrderByDescending(p => p.Price).Select(p => p).ToList();
            }

            if (sort == ServicesConstants.ProductsNewestSortEnum)
            {
                products = products.OrderByDescending(p => p.CreatedOn).Select(p => p).ToList();
            }

            if (sort == ServicesConstants.ProductsOldestSortEnum)
            {
                products = products.OrderBy(p => p.CreatedOn).Select(p => p).ToList();
            }

            var productsViewModel = this.mapper.Map<IEnumerable<ProductsViewModel>>(products);

            return productsViewModel;
        }

        public async Task<IEnumerable<ProductsViewModel>> GetProductsByCategoryAsync(string name)
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

        public async Task<ProductDetailsViewModel> GetProductsByIdAsync(string id)
        {
            var product = await this.dbContext
                .Products.Include(i => i.Images)
                .Include(c => c.Category)
                .Include(c => c.Comments)
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();

            if (product == null)
            {
                throw new NullReferenceException(string.Format(ServicesConstants.InvalidProduct, id));
            }

            var productViewModel = this.mapper.Map<ProductDetailsViewModel>(product);

            return productViewModel;
        }
    }
}
