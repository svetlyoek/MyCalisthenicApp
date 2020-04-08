namespace MyCalisthenicApp.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using MyCalisthenicApp.Data;
    using MyCalisthenicApp.Models.ShopEntities;
    using MyCalisthenicApp.Models.ShopEntities.Enums;
    using MyCalisthenicApp.Services.Common;
    using MyCalisthenicApp.Services.Contracts;
    using MyCalisthenicApp.ViewModels.OrderProducts;
    using MyCalisthenicApp.ViewModels.Products;

    public class ProductsService : IProductsService
    {
        private readonly MyCalisthenicAppDbContext dbContext;
        private readonly IMapper mapper;
        private readonly IUsersService usersService;
        private readonly ICategoriesService categoriesService;

        public ProductsService(
            MyCalisthenicAppDbContext dbContext,
            IMapper mapper,
            IUsersService usersService,
            ICategoriesService categoriesService)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.usersService = usersService;
            this.categoriesService = categoriesService;
        }

        public async Task<IEnumerable<ProductsViewModel>> GetAllProductsAsync()
        {
            var products = await this.dbContext.Products
                .Include(i => i.Images)
                 .Include(c => c.Category)
                .ThenInclude(p => p.Products)
                 .Where(p => p.IsDeleted == false)
                 .Where(p => p.Category.IsDeleted == false)
                .OrderByDescending(p => p.Rating)
                .ToListAsync();

            var productsViewModel = this.mapper.Map<IEnumerable<ProductsViewModel>>(products);

            return productsViewModel;
        }

        public async Task<IEnumerable<ProductsHomePopularViewModel>> GetPopularProductsAsync()
        {
            var products = await this.dbContext
                .Products.Include(i => i.Images)
                 .Where(p => p.IsDeleted == false)
                 .Where(p => p.Category.IsDeleted == false)
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
                 .Where(p => p.Category.IsDeleted == false)
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
            var products = await this.dbContext.Products
                .Include(i => i.Images)
                 .Include(c => c.Category)
                 .ThenInclude(p => p.Products)
                 .Where(p => p.Category.Name == name)
                  .Where(p => p.IsDeleted == false)
                  .Where(p => p.Category.IsDeleted == false)
                 .ToListAsync();

            var productsViewModel = this.mapper.Map<IEnumerable<ProductsViewModel>>(products);

            return productsViewModel;
        }

        public async Task<ProductDetailsViewModel> GetProductsByIdAsync(string id)
        {
            var product = await this.dbContext.Products
                .Include(i => i.Images)
                .Include(c => c.Category)
                .Include(c => c.Comments)
                .Where(p => p.Id == id)
                .Where(p => p.IsDeleted == false)
                .Where(p => p.Category.IsDeleted == false)
                .FirstOrDefaultAsync();

            if (product == null)
            {
                throw new ArgumentNullException(string.Format(ServicesConstants.InvalidProductId, id));
            }

            var productViewModel = this.mapper.Map<ProductDetailsViewModel>(product);

            return productViewModel;
        }

        public async Task AddRatingAsync(string id)
        {
            var product = await this.dbContext.Products
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                throw new ArgumentNullException(string.Format(ServicesConstants.InvalidProductId, id));
            }

            var userId = this.usersService.GetLoggedUserId();

            var userFromDb = await this.usersService.GetLoggedUserByIdAsync(userId);

            if (userFromDb == null)
            {
                throw new ArgumentNullException(string.Format(ServicesConstants.InvalidUserId, userId));
            }

            var userCredentials = userFromDb.FirstName + " " + userFromDb.LastName + ":" + userId;

            if (product.LikesUsersNames == null)
            {
                var likesUsersNames = new List<string>();

                product.LikesUsersNames = likesUsersNames;
            }

            if (!product.LikesUsersNames.Contains(userCredentials))
            {
                if (product.Rating == null)
                {
                    product.Rating = 1;
                }
                else
                {
                    product.Rating += 1;
                }

                product.LikesUsersNames.Add(userCredentials);
            }
            else if (product.LikesUsersNames.Contains(userCredentials))
            {
                if (product.Rating >= 1)
                {
                    product.Rating -= 1;
                }

                product.LikesUsersNames.Remove(userCredentials);
            }

            this.dbContext.Update(product);

            await this.dbContext.SaveChangesAsync();
        }

        public bool ProductsExistsById(string id)
        {
            return this.dbContext.Products
                .Where(p => p.IsDeleted == false)
                .Where(p => p.Category.IsDeleted == false)
                .Any(p => p.Id == id);
        }

        public async Task<Product> GetProductAsync(string id)
        {
            var userId = this.usersService.GetLoggedUserId();

            var product = await this.dbContext.Products
               .Where(p => p.IsDeleted == false)
               .Where(p => p.Category.IsDeleted == false)
               .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                throw new ArgumentNullException(string.Format(ServicesConstants.InvalidProductId, id));
            }

            return product;
        }

        public async Task<IList<ProductsShoppingBagViewModel>> GetShoppingBagProductsAsync()
        {
            var userId = this.usersService.GetLoggedUserId();

            var userFromDb = await this.usersService.GetLoggedUserByIdAsync(userId);

            var products = new List<ProductsShoppingBagViewModel>();

            var order = await this.dbContext.Orders
                .Where(o => o.IsDeleted == false)
                .Where(o => o.UserId == userId)
                .Where(o => o.Status != OrderStatus.Sent)
                .FirstOrDefaultAsync();

            if (order == null || order.Status == OrderStatus.Sent)
            {
                return products;
            }

            var productsView = await this.dbContext.Products
               .Include(p => p.Images)
               .Include(p => p.Orders)
              .Where(p => p.IsDeleted == false)
              .Where(p => p.Category.IsDeleted == false)
              .Where(p => p.IsSoldOut == false)
              .Where(p => p.Orders.Any(o => o.OrderId == order.Id))

              .ToListAsync();

            foreach (var product in productsView)
            {
                foreach (var orderProduct in product.Orders)
                {
                    if (orderProduct.OrderId != order.Id)
                    {
                        product.Orders.Remove(orderProduct);

                        break;
                    }
                }
            }

            var productsViewModel = this.mapper.Map<IList<ProductsShoppingBagViewModel>>(productsView);

            return productsViewModel;
        }

        public async Task RemoveProductFromShoppingBagAsync(string id)
        {
            var userId = this.usersService.GetLoggedUserId();

            var order = await this.dbContext.Orders
                .Where(o => o.Status != OrderStatus.Sent)
                .FirstOrDefaultAsync(o => o.UserId == userId);

            if (order == null)
            {
                throw new ArgumentNullException(string.Format(ServicesConstants.InvalidOrder));
            }

            var product = await this.dbContext.OrderProducts
                 .Where(op => op.ProductId == id)
                  .Where(op => op.OrderId == order.Id)
                 .FirstOrDefaultAsync();

            if (product == null)
            {
                throw new ArgumentNullException(string.Format(ServicesConstants.InvalidProduct));
            }

            this.dbContext.OrderProducts.Remove(product);

            order.TotalPrice -= product.Price;

            await this.dbContext.SaveChangesAsync();
        }

        public async Task<IList<string>> GetAllLikesByProductIdAsync(string id)
        {
            var product = await this.dbContext.Products
                 .Where(c => c.Id == id)
                 .FirstOrDefaultAsync();

            if (product == null)
            {
                throw new ArgumentNullException(string.Format(ServicesConstants.InvalidProductId, id));
            }

            if (product.LikesUsersNames == null)
            {
                product.LikesUsersNames = new List<string>();
            }

            var likes = product.LikesUsersNames;

            return likes;
        }

        public async Task<IList<ProductsAdminViewModel>> GetProductsForAdminAsync()
        {
            var products = await this.dbContext.Products
                .Include(p => p.Category)
                .Include(p => p.Images)
                .ToListAsync();

            var productsViewModel = this.mapper.Map<IList<ProductsAdminViewModel>>(products);

            return productsViewModel;
        }

        public async Task<OrderProductAdminEditViewModel> GetOrderProductByIdAsync(string id)
        {
            var orderProduct = await this.dbContext.OrderProducts
                 .FirstOrDefaultAsync(o => o.ProductId == id);

            if (orderProduct == null)
            {
                throw new ArgumentNullException(string.Format(ServicesConstants.InvalidOrderProductId, id));
            }

            var orderViewModel = this.mapper.Map<OrderProductAdminEditViewModel>(orderProduct);

            return orderViewModel;
        }

        public async Task EditOrderProductAsync(OrderProductAdminEditViewModel inputModel)
        {
            var orderProduct = await this.dbContext.OrderProducts
                .Where(c => c.ProductId == inputModel.ProductId)
                .FirstOrDefaultAsync();

            if (orderProduct == null)
            {
                throw new ArgumentNullException(string.Format(ServicesConstants.InvalidOrderProductId, inputModel.ProductId));
            }

            orderProduct.OrderId = inputModel.OrderId;

            orderProduct.ProductId = inputModel.ProductId;

            orderProduct.Price = inputModel.Price;

            orderProduct.Quantity = inputModel.Quantity;

            this.dbContext.Update(orderProduct);

            await this.dbContext.SaveChangesAsync();
        }

        public async Task<ProductAdminEditViewModel> GetProductByIdAsync(string id)
        {
            var product = await this.dbContext.Products
                .Include(p => p.Category)
                .Where(a => a.Id == id)
                .FirstOrDefaultAsync();

            if (product == null)
            {
                throw new ArgumentNullException(string.Format(ServicesConstants.InvalidProductId, id));
            }

            var categories = this.categoriesService.GetAllProductCategories();

            var productViewModel = this.mapper.Map<ProductAdminEditViewModel>(product);

            productViewModel.Categories = categories;

            return productViewModel;
        }

        public async Task EditProductAsync(ProductAdminEditViewModel inputModel)
        {
            var product = await this.dbContext.Products
                .Include(p => p.Category)
                .Include(p => p.Images)
                .FirstOrDefaultAsync(a => a.Id == inputModel.Id);

            if (product == null)
            {
                throw new ArgumentNullException(string.Format(ServicesConstants.InvalidProductId, inputModel.Id));
            }

            Enum.TryParse(inputModel.Size, true, out ProductSize productSize);

            Enum.TryParse(inputModel.Color, true, out ProductColor productColor);

            Enum.TryParse(inputModel.Sort, true, out ProductSort productSort);

            Enum.TryParse(inputModel.Type, true, out ProductCategoryType productType);

            product.IsDeleted = inputModel.IsDeleted;

            product.DeletedOn = inputModel.DeletedOn;

            product.CreatedOn = inputModel.CreatedOn;

            product.ModifiedOn = inputModel.ModifiedOn;

            product.Name = inputModel.Name;

            product.Price = inputModel.Price;

            product.Description = inputModel.Description;

            product.Rating = inputModel.Rating;

            product.IsSoldOut = inputModel.IsSoldOut;

            product.CategoryId = inputModel.CategoryId;

            product.Category.Name = inputModel.CategoryName;

            product.Category.IsDeleted = inputModel.CategoryIsDeleted;

            product.Size = productSize;

            product.Color = productColor;

            product.Sort = productSort;

            product.Type = productType;

            this.dbContext.Update(product);

            await this.dbContext.SaveChangesAsync();
        }

        public async Task CreateProductAsync(ProductAdminCreateViewModel inputModel)
        {
            var product = new Product
            {
                Name = inputModel.Name,
                Price = inputModel.Price,
                Size = inputModel.Size,
                Color = inputModel.Color,
                Type = inputModel.Type,
                Rating = inputModel.Rating,
                Description = inputModel.Description,
                CategoryId = inputModel.CategoryId,
            };

            await this.dbContext.Products.AddAsync(product);

            await this.dbContext.SaveChangesAsync();
        }
    }
}