namespace MyCalisthenicApp.Services.Tests
{
    using AutoMapper;
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;
    using MyCalisthenicApp.Data;
    using MyCalisthenicApp.Mapping.MappingConfiguration;
    using MyCalisthenicApp.Models;
    using MyCalisthenicApp.Models.ShopEntities;
    using MyCalisthenicApp.ViewModels.OrderProducts;
    using MyCalisthenicApp.ViewModels.Products;
    using System;
    using System.Threading.Tasks;
    using Xunit;

    public class ProductsServiceTests
    {
        private const string CategoryName = "Category name";
        private const string ProductId = "8686";
        private const string ProductName = "Product name";
        public string ProductLike = "Ivan Ivanov:21374";
        private const string ProductDescription = "Product description";
        private int? ProductRating = 10;
        private decimal FirstProductPrice = 13.50M;
        private decimal SecondProductPrice = 22.00M;
        private decimal ThirdProductPrice = 34.70M;
        private const string FirstProductId = "845875";
        private const string SecondProductId = "3848";
        private const string ThirdProductId = "3674584";
        private const string ImageUrl = "https://image45.bg";
        private const string ProductsNewestSortEnum = "Newest";
        private const string ProductsOldestSortEnum = "Oldest";
        private const string ProductsPriceDescendingSortEnum = "PriceDescending";
        private const string ProductsPriceAscendingSortEnum = "PriceAscending";
        private const string CommentText = "Comment text";
        private const string UserFirstName = "Ivan";
        private const string UserLastName = "Ivanov";
        private const string OrderProductProductId = "896876";
        private const string OrderProductOrderId = "6897";
        private decimal OrderProductPrice = 12.59M;

        [Fact]
        public async Task GetAllProductsAsyncShouldReturnProductsSuccessfully()
        {
            var options = new DbContextOptionsBuilder<MyCalisthenicAppDbContext>()
               .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
               .Options;

            var dbContext = new MyCalisthenicAppDbContext(options);

            IHttpContextAccessor httpContextAccessor = new HttpContextAccessor();

            var usersService = new UsersService(httpContextAccessor, dbContext, null);

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MyCalisthenicAppProfile());
            });

            var mapper = mockMapper.CreateMapper();

            var categoriesService = new CategoriesService(dbContext, mapper);

            var productsService = new ProductsService(dbContext, mapper, usersService, categoriesService);

            var category = new ProductCategory
            {
                Name = CategoryName,
            };

            await dbContext.ProductCategories.AddAsync(category);

            await dbContext.SaveChangesAsync();

            for (int i = 0; i < 3; i++)
            {
                var product = new Product
                {
                    Name = ProductName,
                    Description = ProductDescription,
                    Rating = ProductRating,
                    CategoryId = category.Id,
                };

                product.Images.Add(new Image
                {
                    Url = ImageUrl,
                });

                await dbContext.Products.AddAsync(product);

                await dbContext.SaveChangesAsync();
            }

            var expected = await productsService.GetAllProductsAsync();

            var counter = 0;

            foreach (var pr in expected)
            {
                counter++;
            }

            Assert.Equal(3, counter);
        }

        [Fact]
        public async Task GetPopularProductsAsyncShouldReturnProductsSuccessfully()
        {
            var options = new DbContextOptionsBuilder<MyCalisthenicAppDbContext>()
               .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
               .Options;

            var dbContext = new MyCalisthenicAppDbContext(options);

            IHttpContextAccessor httpContextAccessor = new HttpContextAccessor();

            var usersService = new UsersService(httpContextAccessor, dbContext, null);

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MyCalisthenicAppProfile());
            });

            var mapper = mockMapper.CreateMapper();

            var categoriesService = new CategoriesService(dbContext, mapper);

            var productsService = new ProductsService(dbContext, mapper, usersService, categoriesService);

            var category = new ProductCategory
            {
                Name = CategoryName,
            };

            await dbContext.ProductCategories.AddAsync(category);

            await dbContext.SaveChangesAsync();

            for (int i = 0; i < 10; i++)
            {
                var product = new Product
                {
                    Name = ProductName,
                    Description = ProductDescription,
                    Rating = ProductRating,
                    CategoryId = category.Id,
                };

                product.Images.Add(new Image
                {
                    Url = ImageUrl,
                });

                await dbContext.Products.AddAsync(product);

                await dbContext.SaveChangesAsync();
            }

            var expected = await productsService.GetPopularProductsAsync();

            var counter = 0;

            foreach (var pr in expected)
            {
                counter++;
            }

            Assert.Equal(8, counter);
        }

        [Fact]
        public async Task GetProductsAndSortAsyncShouldReturnProductsSortedByPriceAscending()
        {
            var options = new DbContextOptionsBuilder<MyCalisthenicAppDbContext>()
               .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
               .Options;

            var dbContext = new MyCalisthenicAppDbContext(options);

            IHttpContextAccessor httpContextAccessor = new HttpContextAccessor();

            var usersService = new UsersService(httpContextAccessor, dbContext, null);

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MyCalisthenicAppProfile());
            });

            var mapper = mockMapper.CreateMapper();

            var categoriesService = new CategoriesService(dbContext, mapper);

            var productsService = new ProductsService(dbContext, mapper, usersService, categoriesService);

            var category = new ProductCategory
            {
                Name = CategoryName,
            };

            await dbContext.ProductCategories.AddAsync(category);

            await dbContext.SaveChangesAsync();

            var product = new Product
            {
                Name = ProductName,
                Description = ProductDescription,
                Rating = ProductRating,
                CategoryId = category.Id,
                Price = FirstProductPrice,
            };

            product.Images.Add(new Image
            {
                Url = ImageUrl,
            });

            await dbContext.Products.AddAsync(product);

            await dbContext.SaveChangesAsync();

            var secondProduct = new Product
            {
                Name = ProductName,
                Description = ProductDescription,
                Rating = ProductRating,
                CategoryId = category.Id,
                Price = ThirdProductPrice,
            };

            product.Images.Add(new Image
            {
                Url = ImageUrl,
            });

            await dbContext.Products.AddAsync(secondProduct);

            await dbContext.SaveChangesAsync();

            var thirdProduct = new Product
            {
                Name = ProductName,
                Description = ProductDescription,
                Rating = ProductRating,
                CategoryId = category.Id,
                Price = SecondProductPrice,
            };

            product.Images.Add(new Image
            {
                Url = ImageUrl,
            });

            await dbContext.Products.AddAsync(thirdProduct);

            await dbContext.SaveChangesAsync();

            var expected = await productsService.GetProductsAndSortAsync(ProductsPriceAscendingSortEnum);

            var counter = 0;

            foreach (var pr in expected)
            {
                counter++;

                if (counter == 1)
                {
                    Assert.Equal(pr.Price, FirstProductPrice);
                }

                if (counter == 2)
                {
                    Assert.Equal(pr.Price, SecondProductPrice);
                }

                if (counter == 3)
                {
                    Assert.Equal(pr.Price, ThirdProductPrice);
                }
            }
        }

        [Fact]
        public async Task GetProductsAndSortAsyncShouldReturnProductsSortedByPriceDescending()
        {
            var options = new DbContextOptionsBuilder<MyCalisthenicAppDbContext>()
               .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
               .Options;

            var dbContext = new MyCalisthenicAppDbContext(options);

            IHttpContextAccessor httpContextAccessor = new HttpContextAccessor();

            var usersService = new UsersService(httpContextAccessor, dbContext, null);

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MyCalisthenicAppProfile());
            });

            var mapper = mockMapper.CreateMapper();

            var categoriesService = new CategoriesService(dbContext, mapper);

            var productsService = new ProductsService(dbContext, mapper, usersService, categoriesService);

            var category = new ProductCategory
            {
                Name = CategoryName,
            };

            await dbContext.ProductCategories.AddAsync(category);

            await dbContext.SaveChangesAsync();

            var product = new Product
            {
                Name = ProductName,
                Description = ProductDescription,
                Rating = ProductRating,
                CategoryId = category.Id,
                Price = FirstProductPrice,
            };

            product.Images.Add(new Image
            {
                Url = ImageUrl,
            });

            await dbContext.Products.AddAsync(product);

            await dbContext.SaveChangesAsync();

            var secondProduct = new Product
            {
                Name = ProductName,
                Description = ProductDescription,
                Rating = ProductRating,
                CategoryId = category.Id,
                Price = ThirdProductPrice,
            };

            product.Images.Add(new Image
            {
                Url = ImageUrl,
            });

            await dbContext.Products.AddAsync(secondProduct);

            await dbContext.SaveChangesAsync();

            var thirdProduct = new Product
            {
                Name = ProductName,
                Description = ProductDescription,
                Rating = ProductRating,
                CategoryId = category.Id,
                Price = SecondProductPrice,
            };

            product.Images.Add(new Image
            {
                Url = ImageUrl,
            });

            await dbContext.Products.AddAsync(thirdProduct);

            await dbContext.SaveChangesAsync();

            var expected = await productsService.GetProductsAndSortAsync(ProductsPriceDescendingSortEnum);

            var counter = 0;

            foreach (var pr in expected)
            {
                counter++;

                if (counter == 1)
                {
                    Assert.Equal(pr.Price, ThirdProductPrice);
                }

                if (counter == 2)
                {
                    Assert.Equal(pr.Price, SecondProductPrice);
                }

                if (counter == 3)
                {
                    Assert.Equal(pr.Price, FirstProductPrice);
                }
            }
        }

        [Fact]
        public async Task GetProductsAndSortAsyncShouldReturnProductsSortedByCreatedDateDescending()
        {
            var options = new DbContextOptionsBuilder<MyCalisthenicAppDbContext>()
               .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
               .Options;

            var dbContext = new MyCalisthenicAppDbContext(options);

            IHttpContextAccessor httpContextAccessor = new HttpContextAccessor();

            var usersService = new UsersService(httpContextAccessor, dbContext, null);

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MyCalisthenicAppProfile());
            });

            var mapper = mockMapper.CreateMapper();

            var categoriesService = new CategoriesService(dbContext, mapper);

            var productsService = new ProductsService(dbContext, mapper, usersService, categoriesService);

            var category = new ProductCategory
            {
                Name = CategoryName,
            };

            await dbContext.ProductCategories.AddAsync(category);

            await dbContext.SaveChangesAsync();

            var product = new Product
            {
                Id = FirstProductId,
                Name = ProductName,
                Description = ProductDescription,
                Rating = ProductRating,
                CategoryId = category.Id,
                Price = FirstProductPrice,
            };

            product.Images.Add(new Image
            {
                Url = ImageUrl,
            });

            await dbContext.Products.AddAsync(product);

            await dbContext.SaveChangesAsync();

            var secondProduct = new Product
            {
                Id = SecondProductId,
                Name = ProductName,
                Description = ProductDescription,
                Rating = ProductRating,
                CategoryId = category.Id,
                Price = ThirdProductPrice,
            };

            product.Images.Add(new Image
            {
                Url = ImageUrl,
            });

            await dbContext.Products.AddAsync(secondProduct);

            await dbContext.SaveChangesAsync();

            var thirdProduct = new Product
            {
                Id = ThirdProductId,
                Name = ProductName,
                Description = ProductDescription,
                Rating = ProductRating,
                CategoryId = category.Id,
                Price = SecondProductPrice,
            };

            product.Images.Add(new Image
            {
                Url = ImageUrl,
            });

            await dbContext.Products.AddAsync(thirdProduct);

            await dbContext.SaveChangesAsync();

            var expected = await productsService.GetProductsAndSortAsync(ProductsNewestSortEnum);

            var counter = 0;

            foreach (var pr in expected)
            {
                counter++;

                if (counter == 1)
                {
                    Assert.Equal(pr.Id, ThirdProductId);
                }

                if (counter == 2)
                {
                    Assert.Equal(pr.Id, SecondProductId);
                }

                if (counter == 3)
                {
                    Assert.Equal(pr.Id, FirstProductId);
                }
            }
        }

        [Fact]
        public async Task GetProductsAndSortAsyncShouldReturnProductsSortedByCreatedDateAscending()
        {
            var options = new DbContextOptionsBuilder<MyCalisthenicAppDbContext>()
               .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
               .Options;

            var dbContext = new MyCalisthenicAppDbContext(options);

            IHttpContextAccessor httpContextAccessor = new HttpContextAccessor();

            var usersService = new UsersService(httpContextAccessor, dbContext, null);

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MyCalisthenicAppProfile());
            });

            var mapper = mockMapper.CreateMapper();

            var categoriesService = new CategoriesService(dbContext, mapper);

            var productsService = new ProductsService(dbContext, mapper, usersService, categoriesService);

            var category = new ProductCategory
            {
                Name = CategoryName,
            };

            await dbContext.ProductCategories.AddAsync(category);

            await dbContext.SaveChangesAsync();

            var product = new Product
            {
                Id = FirstProductId,
                Name = ProductName,
                Description = ProductDescription,
                Rating = ProductRating,
                CategoryId = category.Id,
                Price = FirstProductPrice,
            };

            product.Images.Add(new Image
            {
                Url = ImageUrl,
            });

            await dbContext.Products.AddAsync(product);

            await dbContext.SaveChangesAsync();

            var secondProduct = new Product
            {
                Id = SecondProductId,
                Name = ProductName,
                Description = ProductDescription,
                Rating = ProductRating,
                CategoryId = category.Id,
                Price = ThirdProductPrice,
            };

            product.Images.Add(new Image
            {
                Url = ImageUrl,
            });

            await dbContext.Products.AddAsync(secondProduct);

            await dbContext.SaveChangesAsync();

            var thirdProduct = new Product
            {
                Id = ThirdProductId,
                Name = ProductName,
                Description = ProductDescription,
                Rating = ProductRating,
                CategoryId = category.Id,
                Price = SecondProductPrice,
            };

            product.Images.Add(new Image
            {
                Url = ImageUrl,
            });

            await dbContext.Products.AddAsync(thirdProduct);

            await dbContext.SaveChangesAsync();

            var expected = await productsService.GetProductsAndSortAsync(ProductsOldestSortEnum);

            var counter = 0;

            foreach (var pr in expected)
            {
                counter++;

                if (counter == 1)
                {
                    Assert.Equal(pr.Id, FirstProductId);
                }

                if (counter == 2)
                {
                    Assert.Equal(pr.Id, SecondProductId);
                }

                if (counter == 3)
                {
                    Assert.Equal(pr.Id, ThirdProductId);
                }
            }
        }

        [Fact]
        public async Task GetProductsByCategoryAsyncShouldReturnProductsSuccessfully()
        {
            var options = new DbContextOptionsBuilder<MyCalisthenicAppDbContext>()
               .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
               .Options;

            var dbContext = new MyCalisthenicAppDbContext(options);

            IHttpContextAccessor httpContextAccessor = new HttpContextAccessor();

            var usersService = new UsersService(httpContextAccessor, dbContext, null);

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MyCalisthenicAppProfile());
            });

            var mapper = mockMapper.CreateMapper();

            var categoriesService = new CategoriesService(dbContext, mapper);

            var productsService = new ProductsService(dbContext, mapper, usersService, categoriesService);

            var category = new ProductCategory
            {
                Name = CategoryName,
            };

            await dbContext.ProductCategories.AddAsync(category);

            await dbContext.SaveChangesAsync();

            for (int i = 0; i < 3; i++)
            {
                var product = new Product
                {
                    Name = ProductName,
                    Description = ProductDescription,
                    Rating = ProductRating,
                    CategoryId = category.Id,
                    Price = FirstProductPrice,
                };

                product.Images.Add(new Image
                {
                    Url = ImageUrl,
                });

                await dbContext.Products.AddAsync(product);

                await dbContext.SaveChangesAsync();
            }

            var expected = await productsService.GetProductsByCategoryAsync(CategoryName);

            var counter = 0;

            foreach (var pr in expected)
            {
                counter++;
            }

            Assert.Equal(3, counter);
        }

        [Fact]
        public async Task GetProductByIdAsyncShouldThrowExceptionIfProductIsNull()
        {
            var options = new DbContextOptionsBuilder<MyCalisthenicAppDbContext>()
               .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
               .Options;

            var dbContext = new MyCalisthenicAppDbContext(options);

            IHttpContextAccessor httpContextAccessor = new HttpContextAccessor();

            var usersService = new UsersService(httpContextAccessor, dbContext, null);

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MyCalisthenicAppProfile());
            });

            var mapper = mockMapper.CreateMapper();

            var categoriesService = new CategoriesService(dbContext, mapper);

            var productsService = new ProductsService(dbContext, mapper, usersService, categoriesService);

            var exception = await Assert.ThrowsAsync<ArgumentNullException>(async () => await productsService.GetProductByIdAsync(ProductId));

            Assert.IsType<ArgumentNullException>(exception);
        }

        [Fact]
        public async Task GetProductByIdAsyncShouldReturnProductSuccessfully()
        {
            var options = new DbContextOptionsBuilder<MyCalisthenicAppDbContext>()
               .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
               .Options;

            var dbContext = new MyCalisthenicAppDbContext(options);

            IHttpContextAccessor httpContextAccessor = new HttpContextAccessor();

            var usersService = new UsersService(httpContextAccessor, dbContext, null);

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MyCalisthenicAppProfile());
            });

            var mapper = mockMapper.CreateMapper();

            var categoriesService = new CategoriesService(dbContext, mapper);

            var productsService = new ProductsService(dbContext, mapper, usersService, categoriesService);

            var category = new ProductCategory
            {
                Name = CategoryName,
            };

            await dbContext.ProductCategories.AddAsync(category);

            await dbContext.SaveChangesAsync();

            var product = new Product
            {
                Name = ProductName,
                Description = ProductDescription,
                Rating = ProductRating,
                CategoryId = category.Id,
                Price = FirstProductPrice,
            };

            product.Images.Add(new Image
            {
                Url = ImageUrl,
            });

            product.Comments.Add(new Comment
            {
                Text = CommentText,
            });

            await dbContext.Products.AddAsync(product);

            await dbContext.SaveChangesAsync();

            var expected = await productsService.GetProductByIdAsync(product.Id);

            Assert.Equal(product.Id, expected.Id);
        }

        [Fact]
        public async Task AddRatingAsyncShouldThrowExceptionIfProductIsNull()
        {
            var options = new DbContextOptionsBuilder<MyCalisthenicAppDbContext>()
               .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
               .Options;

            var dbContext = new MyCalisthenicAppDbContext(options);

            IHttpContextAccessor httpContextAccessor = new HttpContextAccessor();

            var usersService = new UsersService(httpContextAccessor, dbContext, null);

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MyCalisthenicAppProfile());
            });

            var mapper = mockMapper.CreateMapper();

            var categoriesService = new CategoriesService(dbContext, mapper);

            var productsService = new ProductsService(dbContext, mapper, usersService, categoriesService);

            var exception = await Assert.ThrowsAsync<ArgumentNullException>(async () => await productsService.AddRatingAsync(ProductId));

            Assert.IsType<ArgumentNullException>(exception);
        }

        [Fact]
        public async Task AddRatingAsyncShouldThrowExceptionIfUserIsNull()
        {
            var options = new DbContextOptionsBuilder<MyCalisthenicAppDbContext>()
               .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
               .Options;

            var dbContext = new MyCalisthenicAppDbContext(options);

            IHttpContextAccessor httpContextAccessor = new HttpContextAccessor();

            var usersService = new UsersService(httpContextAccessor, dbContext, null);

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MyCalisthenicAppProfile());
            });

            var mapper = mockMapper.CreateMapper();

            var categoriesService = new CategoriesService(dbContext, mapper);

            var productsService = new ProductsService(dbContext, mapper, usersService, categoriesService);

            var category = new ProductCategory
            {
                Name = CategoryName,
            };

            await dbContext.ProductCategories.AddAsync(category);

            await dbContext.SaveChangesAsync();

            var product = new Product
            {
                Name = ProductName,
                Description = ProductDescription,
                Rating = ProductRating,
                CategoryId = category.Id,
                Price = FirstProductPrice,
            };

            await dbContext.Products.AddAsync(product);

            await dbContext.SaveChangesAsync();

            var exception = await Assert.ThrowsAsync<NullReferenceException>(async () => await productsService.AddRatingAsync(product.Id));

            Assert.IsType<NullReferenceException>(exception);
        }

        [Fact]
        public async Task ProductsExistsByIdShouldReturnTrueIfProductExists()
        {
            var options = new DbContextOptionsBuilder<MyCalisthenicAppDbContext>()
               .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
               .Options;

            var dbContext = new MyCalisthenicAppDbContext(options);

            IHttpContextAccessor httpContextAccessor = new HttpContextAccessor();

            var usersService = new UsersService(httpContextAccessor, dbContext, null);

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MyCalisthenicAppProfile());
            });

            var mapper = mockMapper.CreateMapper();

            var categoriesService = new CategoriesService(dbContext, mapper);

            var productsService = new ProductsService(dbContext, mapper, usersService, categoriesService);

            var category = new ProductCategory
            {
                Name = CategoryName,
            };

            await dbContext.ProductCategories.AddAsync(category);

            await dbContext.SaveChangesAsync();

            var product = new Product
            {
                Name = ProductName,
                Description = ProductDescription,
                Rating = ProductRating,
                CategoryId = category.Id,
                Price = FirstProductPrice,
            };

            await dbContext.Products.AddAsync(product);

            await dbContext.SaveChangesAsync();

            var expected = productsService.ProductsExistsById(product.Id);

            Assert.True(expected);
        }

        [Fact]
        public async Task ProductsExistsByIdShouldReturnFalseIfProductDoesNotExists()
        {
            var options = new DbContextOptionsBuilder<MyCalisthenicAppDbContext>()
               .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
               .Options;

            var dbContext = new MyCalisthenicAppDbContext(options);

            IHttpContextAccessor httpContextAccessor = new HttpContextAccessor();

            var usersService = new UsersService(httpContextAccessor, dbContext, null);

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MyCalisthenicAppProfile());
            });

            var mapper = mockMapper.CreateMapper();

            var categoriesService = new CategoriesService(dbContext, mapper);

            var productsService = new ProductsService(dbContext, mapper, usersService, categoriesService);

            var category = new ProductCategory
            {
                Name = CategoryName,
            };

            await dbContext.ProductCategories.AddAsync(category);

            await dbContext.SaveChangesAsync();

            var product = new Product
            {
                Name = ProductName,
                Description = ProductDescription,
                Rating = ProductRating,
                CategoryId = category.Id,
                Price = FirstProductPrice,
            };

            await dbContext.Products.AddAsync(product);

            await dbContext.SaveChangesAsync();

            var expected = productsService.ProductsExistsById(ProductId);

            Assert.False(expected);
        }

        [Fact]
        public async Task GetProductAsyncShouldShouldThrowExceptionIfProductIsNull()
        {
            var options = new DbContextOptionsBuilder<MyCalisthenicAppDbContext>()
               .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
               .Options;

            var dbContext = new MyCalisthenicAppDbContext(options);

            IHttpContextAccessor httpContextAccessor = new HttpContextAccessor();

            var usersService = new UsersService(httpContextAccessor, dbContext, null);

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MyCalisthenicAppProfile());
            });

            var mapper = mockMapper.CreateMapper();

            var categoriesService = new CategoriesService(dbContext, mapper);

            var productsService = new ProductsService(dbContext, mapper, usersService, categoriesService);

            var exception = await Assert.ThrowsAsync<ArgumentNullException>(async () => await productsService.GetProductAsync(ProductId));

            Assert.IsType<ArgumentNullException>(exception);
        }

        [Fact]
        public async Task GetProductAsyncShouldReturnProductSuccessfully()
        {
            var options = new DbContextOptionsBuilder<MyCalisthenicAppDbContext>()
               .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
               .Options;

            var dbContext = new MyCalisthenicAppDbContext(options);

            IHttpContextAccessor httpContextAccessor = new HttpContextAccessor();

            var usersService = new UsersService(httpContextAccessor, dbContext, null);

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MyCalisthenicAppProfile());
            });

            var mapper = mockMapper.CreateMapper();

            var categoriesService = new CategoriesService(dbContext, mapper);

            var productsService = new ProductsService(dbContext, mapper, usersService, categoriesService);

            var category = new ProductCategory
            {
                Name = CategoryName,
            };

            await dbContext.ProductCategories.AddAsync(category);

            await dbContext.SaveChangesAsync();

            var product = new Product
            {
                Name = ProductName,
                Description = ProductDescription,
                Rating = ProductRating,
                CategoryId = category.Id,
                Price = FirstProductPrice,
            };

            await dbContext.Products.AddAsync(product);

            await dbContext.SaveChangesAsync();

            var expected = await productsService.GetProductAsync(product.Id);

            Assert.Equal(product.Id, expected.Id);
        }

        [Fact]
        public async Task RemoveProductFromShoppingBagAsyncShouldThrowExceptionIfUserIsNull()
        {
            var options = new DbContextOptionsBuilder<MyCalisthenicAppDbContext>()
               .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
               .Options;

            var dbContext = new MyCalisthenicAppDbContext(options);

            IHttpContextAccessor httpContextAccessor = new HttpContextAccessor();

            var usersService = new UsersService(httpContextAccessor, dbContext, null);

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MyCalisthenicAppProfile());
            });

            var mapper = mockMapper.CreateMapper();

            var categoriesService = new CategoriesService(dbContext, mapper);

            var productsService = new ProductsService(dbContext, mapper, usersService, categoriesService);

            var exception = await Assert.ThrowsAsync<NullReferenceException>(async () => await productsService.RemoveProductFromShoppingBagAsync(ProductId));

            Assert.IsType<NullReferenceException>(exception);
        }

        [Fact]
        public async Task GetAllLikesByProductIdAsyncShouldThrowExceptionIfProductIsNull()
        {
            var options = new DbContextOptionsBuilder<MyCalisthenicAppDbContext>()
               .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
               .Options;

            var dbContext = new MyCalisthenicAppDbContext(options);

            IHttpContextAccessor httpContextAccessor = new HttpContextAccessor();

            var usersService = new UsersService(httpContextAccessor, dbContext, null);

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MyCalisthenicAppProfile());
            });

            var mapper = mockMapper.CreateMapper();

            var categoriesService = new CategoriesService(dbContext, mapper);

            var productsService = new ProductsService(dbContext, mapper, usersService, categoriesService);

            var exception = await Assert.ThrowsAsync<ArgumentNullException>(async () => await productsService.GetAllLikesByProductIdAsync(ProductId));

            Assert.IsType<ArgumentNullException>(exception);
        }

        [Fact]
        public async Task GetAllLikesByProductIdAsyncShouldReturnLikesSuccessfully()
        {
            var options = new DbContextOptionsBuilder<MyCalisthenicAppDbContext>()
               .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
               .Options;

            var dbContext = new MyCalisthenicAppDbContext(options);

            IHttpContextAccessor httpContextAccessor = new HttpContextAccessor();

            var usersService = new UsersService(httpContextAccessor, dbContext, null);

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MyCalisthenicAppProfile());
            });

            var mapper = mockMapper.CreateMapper();

            var categoriesService = new CategoriesService(dbContext, mapper);

            var productsService = new ProductsService(dbContext, mapper, usersService, categoriesService);

            var category = new ProductCategory
            {
                Name = CategoryName,
            };

            await dbContext.ProductCategories.AddAsync(category);

            await dbContext.SaveChangesAsync();

            var product = new Product
            {
                Name = ProductName,
                Description = ProductDescription,
                Rating = ProductRating,
                CategoryId = category.Id,
                Price = FirstProductPrice,
            };

            product.LikesUsersNames.Add(ProductLike);

            await dbContext.Products.AddAsync(product);

            await dbContext.SaveChangesAsync();

            var expected = await productsService.GetAllLikesByProductIdAsync(product.Id);

            Assert.Equal(1, expected.Count);
        }

        [Fact]
        public async Task GetProductsForAdminAsyncShouldReturnProductsSuccessfully()
        {
            var options = new DbContextOptionsBuilder<MyCalisthenicAppDbContext>()
               .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
               .Options;

            var dbContext = new MyCalisthenicAppDbContext(options);

            IHttpContextAccessor httpContextAccessor = new HttpContextAccessor();

            var usersService = new UsersService(httpContextAccessor, dbContext, null);

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MyCalisthenicAppProfile());
            });

            var mapper = mockMapper.CreateMapper();

            var categoriesService = new CategoriesService(dbContext, mapper);

            var productsService = new ProductsService(dbContext, mapper, usersService, categoriesService);

            var category = new ProductCategory
            {
                Name = CategoryName,
            };

            await dbContext.ProductCategories.AddAsync(category);

            await dbContext.SaveChangesAsync();

            for (int i = 0; i < 3; i++)
            {
                var product = new Product
                {
                    Name = ProductName,
                    Description = ProductDescription,
                    Rating = ProductRating,
                    CategoryId = category.Id,
                    Price = FirstProductPrice,
                };

                product.Images.Add(new Image
                {
                    Url = ImageUrl,
                });

                await dbContext.Products.AddAsync(product);

                await dbContext.SaveChangesAsync();
            }

            var expected = await productsService.GetProductsForAdminAsync();

            Assert.Equal(3, expected.Count);
        }

        [Fact]
        public async Task GetOrderProductByIdAsyncShouldThrowExceptionIfOrderProductIsNull()
        {
            var options = new DbContextOptionsBuilder<MyCalisthenicAppDbContext>()
               .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
               .Options;

            var dbContext = new MyCalisthenicAppDbContext(options);

            IHttpContextAccessor httpContextAccessor = new HttpContextAccessor();

            var usersService = new UsersService(httpContextAccessor, dbContext, null);

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MyCalisthenicAppProfile());
            });

            var mapper = mockMapper.CreateMapper();

            var categoriesService = new CategoriesService(dbContext, mapper);

            var productsService = new ProductsService(dbContext, mapper, usersService, categoriesService);

            var exception = await Assert.ThrowsAsync<ArgumentNullException>(async () => await productsService.GetOrderProductByIdAsync(ProductId));

            Assert.IsType<ArgumentNullException>(exception);
        }

        [Fact]
        public async Task GetOrderProductByIdAsyncShouldReturnOrderProductSuccessfully()
        {
            var options = new DbContextOptionsBuilder<MyCalisthenicAppDbContext>()
               .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
               .Options;

            var dbContext = new MyCalisthenicAppDbContext(options);

            IHttpContextAccessor httpContextAccessor = new HttpContextAccessor();

            var usersService = new UsersService(httpContextAccessor, dbContext, null);

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MyCalisthenicAppProfile());
            });

            var mapper = mockMapper.CreateMapper();

            var categoriesService = new CategoriesService(dbContext, mapper);

            var productsService = new ProductsService(dbContext, mapper, usersService, categoriesService);

            var category = new ProductCategory
            {
                Name = CategoryName,
            };

            await dbContext.ProductCategories.AddAsync(category);

            await dbContext.SaveChangesAsync();

            var product = new Product
            {
                Name = ProductName,
                Description = ProductDescription,
                Rating = ProductRating,
                CategoryId = category.Id,
                Price = FirstProductPrice,
            };

            await dbContext.Products.AddAsync(product);

            await dbContext.SaveChangesAsync();

            var user = new ApplicationUser
            {
                FirstName = UserFirstName,
                LastName = UserLastName,
            };

            await dbContext.Users.AddAsync(user);

            await dbContext.SaveChangesAsync();

            var order = new Order
            {
                UserId = user.Id,
            };

            await dbContext.Orders.AddAsync(order);

            await dbContext.SaveChangesAsync();

            var orderProduct = new OrderProduct
            {
                ProductId = product.Id,
                OrderId = order.Id,
            };

            await dbContext.OrderProducts.AddAsync(orderProduct);

            await dbContext.SaveChangesAsync();

            var expected = await productsService.GetOrderProductByIdAsync(orderProduct.ProductId);

            Assert.Equal(orderProduct.ProductId, expected.ProductId);
        }

        [Fact]
        public async Task EditOrderProductAsyncShouldThrowExceptionIfOrderProductIsNull()
        {
            var options = new DbContextOptionsBuilder<MyCalisthenicAppDbContext>()
               .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
               .Options;

            var dbContext = new MyCalisthenicAppDbContext(options);

            IHttpContextAccessor httpContextAccessor = new HttpContextAccessor();

            var usersService = new UsersService(httpContextAccessor, dbContext, null);

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MyCalisthenicAppProfile());
            });

            var mapper = mockMapper.CreateMapper();

            var categoriesService = new CategoriesService(dbContext, mapper);

            var productsService = new ProductsService(dbContext, mapper, usersService, categoriesService);

            var orderProductModel = new OrderProductAdminEditViewModel
            {
                OrderId = OrderProductOrderId,
                ProductId = OrderProductProductId,
            };

            var exception = await Assert.ThrowsAsync<ArgumentNullException>(async () => await productsService.EditOrderProductAsync(orderProductModel));

            Assert.IsType<ArgumentNullException>(exception);
        }

        [Fact]
        public async Task EditOrderProductAsyncShouldEditOrderProductSuccessfully()
        {
            var options = new DbContextOptionsBuilder<MyCalisthenicAppDbContext>()
               .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
               .Options;

            var dbContext = new MyCalisthenicAppDbContext(options);

            IHttpContextAccessor httpContextAccessor = new HttpContextAccessor();

            var usersService = new UsersService(httpContextAccessor, dbContext, null);

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MyCalisthenicAppProfile());
            });

            var mapper = mockMapper.CreateMapper();

            var categoriesService = new CategoriesService(dbContext, mapper);

            var productsService = new ProductsService(dbContext, mapper, usersService, categoriesService);

            var orderProduct = new OrderProduct
            {
                OrderId = OrderProductOrderId,
                ProductId = OrderProductProductId,
            };

            await dbContext.OrderProducts.AddAsync(orderProduct);

            await dbContext.SaveChangesAsync();

            var orderProductModel = new OrderProductAdminEditViewModel
            {
                OrderId = OrderProductOrderId,
                ProductId = orderProduct.ProductId,
                Price = OrderProductPrice,
            };

            await productsService.EditOrderProductAsync(orderProductModel);

            var actual = await dbContext.OrderProducts.FirstOrDefaultAsync(op => op.ProductId == orderProductModel.ProductId);

            Assert.Equal(orderProductModel.Price, actual.Price);
        }

        [Fact]
        public async Task GetAdminProductByIdAsyncShouldThrowExceptionIfProductIsNull()
        {
            var options = new DbContextOptionsBuilder<MyCalisthenicAppDbContext>()
               .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
               .Options;

            var dbContext = new MyCalisthenicAppDbContext(options);

            IHttpContextAccessor httpContextAccessor = new HttpContextAccessor();

            var usersService = new UsersService(httpContextAccessor, dbContext, null);

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MyCalisthenicAppProfile());
            });

            var mapper = mockMapper.CreateMapper();

            var categoriesService = new CategoriesService(dbContext, mapper);

            var productsService = new ProductsService(dbContext, mapper, usersService, categoriesService);

            var exception = await Assert.ThrowsAsync<ArgumentNullException>(async () => await productsService.GetAdminProductByIdAsync(ProductId));

            Assert.IsType<ArgumentNullException>(exception);
        }

        [Fact]
        public async Task GetAdminProductByIdAsyncShouldReturnProductSuccessfully()
        {
            var options = new DbContextOptionsBuilder<MyCalisthenicAppDbContext>()
               .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
               .Options;

            var dbContext = new MyCalisthenicAppDbContext(options);

            IHttpContextAccessor httpContextAccessor = new HttpContextAccessor();

            var usersService = new UsersService(httpContextAccessor, dbContext, null);

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MyCalisthenicAppProfile());
            });

            var mapper = mockMapper.CreateMapper();

            var categoriesService = new CategoriesService(dbContext, mapper);

            var productsService = new ProductsService(dbContext, mapper, usersService, categoriesService);

            var category = new ProductCategory
            {
                Name = CategoryName,
            };

            await dbContext.ProductCategories.AddAsync(category);

            await dbContext.SaveChangesAsync();

            var product = new Product
            {
                Name = ProductName,
                Description = ProductDescription,
                Rating = ProductRating,
                CategoryId = category.Id,
                Price = FirstProductPrice,
            };

            await dbContext.Products.AddAsync(product);

            await dbContext.SaveChangesAsync();

            var expected = await productsService.GetAdminProductByIdAsync(product.Id);

            Assert.Equal(expected.Id, product.Id);
        }

        [Fact]
        public async Task EditProductAsyncShouldThrowExceptionIfCategoryIsIncorrect()
        {
            var options = new DbContextOptionsBuilder<MyCalisthenicAppDbContext>()
               .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
               .Options;

            var dbContext = new MyCalisthenicAppDbContext(options);

            IHttpContextAccessor httpContextAccessor = new HttpContextAccessor();

            var usersService = new UsersService(httpContextAccessor, dbContext, null);

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MyCalisthenicAppProfile());
            });

            var mapper = mockMapper.CreateMapper();

            var categoriesService = new CategoriesService(dbContext, mapper);

            var productsService = new ProductsService(dbContext, mapper, usersService, categoriesService);

            var productModel = new ProductAdminEditViewModel
            {
                Name = ProductName,
                Description = ProductDescription,
                CategoryId = null,
            };

            var exception = await Assert.ThrowsAsync<ArgumentNullException>(async () => await productsService.EditProductAsync(productModel));

            Assert.IsType<ArgumentNullException>(exception);
        }

        [Fact]
        public async Task EditProductAsyncShouldThrowExceptionIfProductIsNull()
        {
            var options = new DbContextOptionsBuilder<MyCalisthenicAppDbContext>()
               .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
               .Options;

            var dbContext = new MyCalisthenicAppDbContext(options);

            IHttpContextAccessor httpContextAccessor = new HttpContextAccessor();

            var usersService = new UsersService(httpContextAccessor, dbContext, null);

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MyCalisthenicAppProfile());
            });

            var mapper = mockMapper.CreateMapper();

            var categoriesService = new CategoriesService(dbContext, mapper);

            var productsService = new ProductsService(dbContext, mapper, usersService, categoriesService);

            var category = new ProductCategory
            {
                Name = CategoryName,
            };

            await dbContext.ProductCategories.AddAsync(category);

            await dbContext.SaveChangesAsync();

            var productModel = new ProductAdminEditViewModel
            {
                Name = ProductName,
                Description = ProductDescription,
                CategoryId = category.Id,
            };

            var exception = await Assert.ThrowsAsync<ArgumentNullException>(async () => await productsService.EditProductAsync(productModel));

            Assert.IsType<ArgumentNullException>(exception);
        }

        [Fact]
        public async Task EditProductAsyncShouldEditProductSuccessfully()
        {
            var options = new DbContextOptionsBuilder<MyCalisthenicAppDbContext>()
               .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
               .Options;

            var dbContext = new MyCalisthenicAppDbContext(options);

            IHttpContextAccessor httpContextAccessor = new HttpContextAccessor();

            var usersService = new UsersService(httpContextAccessor, dbContext, null);

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MyCalisthenicAppProfile());
            });

            var mapper = mockMapper.CreateMapper();

            var categoriesService = new CategoriesService(dbContext, mapper);

            var productsService = new ProductsService(dbContext, mapper, usersService, categoriesService);

            var category = new ProductCategory
            {
                Name = CategoryName,
            };

            await dbContext.ProductCategories.AddAsync(category);

            await dbContext.SaveChangesAsync();

            var product = new Product
            {
                Name = ProductName,
                Description = ProductDescription,
                Rating = ProductRating,
                CategoryId = category.Id,
                Price = FirstProductPrice,
            };

            await dbContext.Products.AddAsync(product);

            await dbContext.SaveChangesAsync();

            var productModel = new ProductAdminEditViewModel
            {
                Id = product.Id,
                Name = ProductName,
                Description = ProductDescription,
                CategoryId = category.Id,
                Price = SecondProductPrice,
            };

            await productsService.EditProductAsync(productModel);

            var actual = await dbContext.Products.FirstOrDefaultAsync(p => p.Id == product.Id);

            Assert.Equal(product.Price, actual.Price);
        }

        [Fact]
        public async Task CreateProductAsyncShouldThrowExceptionIfCategoryIsIncorrect()
        {
            var options = new DbContextOptionsBuilder<MyCalisthenicAppDbContext>()
               .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
               .Options;

            var dbContext = new MyCalisthenicAppDbContext(options);

            IHttpContextAccessor httpContextAccessor = new HttpContextAccessor();

            var usersService = new UsersService(httpContextAccessor, dbContext, null);

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MyCalisthenicAppProfile());
            });

            var mapper = mockMapper.CreateMapper();

            var categoriesService = new CategoriesService(dbContext, mapper);

            var productsService = new ProductsService(dbContext, mapper, usersService, categoriesService);

            var productModel = new ProductAdminCreateViewModel
            {
                Name = ProductName,
                Description = ProductDescription,
                CategoryId = null,
            };

            var exception = await Assert.ThrowsAsync<ArgumentNullException>(async () => await productsService.CreateProductAsync(productModel));

            Assert.IsType<ArgumentNullException>(exception);
        }

        [Fact]
        public async Task CreateProductAsyncShouldCreateProductSuccessfully()
        {
            var options = new DbContextOptionsBuilder<MyCalisthenicAppDbContext>()
               .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
               .Options;

            var dbContext = new MyCalisthenicAppDbContext(options);

            IHttpContextAccessor httpContextAccessor = new HttpContextAccessor();

            var usersService = new UsersService(httpContextAccessor, dbContext, null);

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MyCalisthenicAppProfile());
            });

            var mapper = mockMapper.CreateMapper();

            var categoriesService = new CategoriesService(dbContext, mapper);

            var productsService = new ProductsService(dbContext, mapper, usersService, categoriesService);

            var category = new ProductCategory
            {
                Name = CategoryName,
            };

            await dbContext.ProductCategories.AddAsync(category);

            await dbContext.SaveChangesAsync();

            var productModel = new ProductAdminCreateViewModel
            {
                Name = ProductName,
                Description = ProductDescription,
                CategoryId = category.Id,
            };

            await productsService.CreateProductAsync(productModel);

            var expected = await dbContext.Products.FirstOrDefaultAsync();

            Assert.Equal(expected.Description, productModel.Description);
        }
    }
}

