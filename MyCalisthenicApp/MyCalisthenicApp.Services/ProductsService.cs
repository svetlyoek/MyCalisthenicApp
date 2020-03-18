﻿namespace MyCalisthenicApp.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using AutoMapper;
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;
    using MyCalisthenicApp.Data;
    using MyCalisthenicApp.Models.ShopEntities;
    using MyCalisthenicApp.Services.Common;
    using MyCalisthenicApp.Services.Contracts;
    using MyCalisthenicApp.ViewModels.Products;

    public class ProductsService : IProductsService
    {
        private readonly MyCalisthenicAppDbContext dbContext;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;

        public ProductsService(MyCalisthenicAppDbContext dbContext, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task<IEnumerable<ProductsViewModel>> GetAllProductsAsync()
        {
            var products = await this.dbContext
                .Products.Include(i => i.Images)
                 .Where(p => p.IsDeleted == false)
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
                  .Where(p => p.IsDeleted == false)
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
                  .Where(p => p.IsDeleted == false)
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
                   .Where(p => p.IsDeleted == false)
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
                  .Where(p => p.IsDeleted == false)
                .FirstOrDefaultAsync();

            if (product == null)
            {
                throw new NullReferenceException(string.Format(ServicesConstants.InvalidProduct, id));
            }

            var productViewModel = this.mapper.Map<ProductDetailsViewModel>(product);

            return productViewModel;
        }

        public async Task AddRatingAsync(string id)
        {
            var product = await this.dbContext.Products.
                FirstOrDefaultAsync(p => p.Id == id);

            if (product.Rating == null)
            {
                product.Rating = 1;
            }
            else
            {
                product.Rating += 1;
            }

            this.dbContext.Update(product);

            await this.dbContext.SaveChangesAsync();
        }

        public bool ProductsExistsById(string id)
        {
            return this.dbContext.Products
                .Where(p => p.IsDeleted == false)
                .Any(p => p.Id == id);
        }

        public async Task<Product> GetProduct(string id)
        {
            var product = await this.dbContext.Products
                .Where(p => p.IsDeleted == false)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                throw new NullReferenceException(string.Format(ServicesConstants.InvalidProduct, id));
            }

            return product;
        }

        public async Task<IList<ProductsShoppingBagViewModel>> GetShoppingBagProductsAsync()
        {
            var userId = this.httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var products = await this.dbContext.Products
              .Where(p => p.IsDeleted == false)
              .Where(p => p.Orders.Any(o => o.ProductId == p.Id))
              .Include(p => p.Orders)
              .Include(p => p.Images)
              .ToListAsync();

            var productsViewModel = this.mapper.Map<IList<ProductsShoppingBagViewModel>>(products);

            return productsViewModel;

        }

        public async Task RemoveProductFromShoppingBagAsync(string id)
        {
            var userId = this.httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var order = await this.dbContext.Orders.FirstOrDefaultAsync(o => o.UserId == userId);

            var product = await this.dbContext.OrderProducts
                 .Where(op => op.ProductId == id)
                 .FirstOrDefaultAsync();

            order.TotalPrice -= product.Price;

            this.dbContext.OrderProducts.Remove(product);

            await this.dbContext.SaveChangesAsync();
        }
    }
}