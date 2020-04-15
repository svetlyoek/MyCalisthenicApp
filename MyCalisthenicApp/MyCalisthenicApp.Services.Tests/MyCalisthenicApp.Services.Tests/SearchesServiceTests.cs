namespace MyCalisthenicApp.Services.Tests
{
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using MyCalisthenicApp.Data;
    using MyCalisthenicApp.Mapping.MappingConfiguration;
    using MyCalisthenicApp.Models;
    using MyCalisthenicApp.Models.ShopEntities;
    using MyCalisthenicApp.ViewModels.Home;
    using System;
    using System.Threading.Tasks;
    using Xunit;

    public class SearchesServiceTests
    {
        private const string SearchText = "Search text";
        private const string InvalidSearchText = "aaa";
        private const string ProgramTitle = "Program title";
        private const string ProgramDescription = "Program description";
        private const string ProgramSearchDescription = "Search text description";
        private const string CategoryName = "Category name";
        private const string CategoryDescription = "Category description";
        private const string ImageUrl = "https://image45.bg";
        private const string ProductName = "Product name";
        private decimal ProductPrice = 18.90M;
        private const string ProductDescription = "Product description";
        private const string ProductSearchDescription = "Search text description";
        private const string UserId = "3747";
        private const string UserFirstName = "Ivan";
        private const string UserLastName = "Ivanov";
        private const string CommentText = "Comment text";


        [Fact]
        public async Task GetProgramsBySearchTextAsyncShouldReturnNullIfTextIsNull()
        {
            var options = new DbContextOptionsBuilder<MyCalisthenicAppDbContext>()
                   .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                   .Options;

            var dbContext = new MyCalisthenicAppDbContext(options);

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MyCalisthenicAppProfile());
            });

            var mapper = mockMapper.CreateMapper();

            var searchesService = new SearchesService(dbContext, mapper);

            var searchModel = new SearchViewModel
            {
                Text = null,
            };

            var expected = await searchesService.GetProgramsBySearchTextAsync(searchModel);

            Assert.Null(expected);
        }

        [Fact]
        public async Task GetProgramsBySearchTextAsyncShouldReturnNullIfTextIsLessThanFourSymbols()
        {
            var options = new DbContextOptionsBuilder<MyCalisthenicAppDbContext>()
                   .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                   .Options;

            var dbContext = new MyCalisthenicAppDbContext(options);

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MyCalisthenicAppProfile());
            });

            var mapper = mockMapper.CreateMapper();

            var searchesService = new SearchesService(dbContext, mapper);

            var searchModel = new SearchViewModel
            {
                Text = InvalidSearchText,
            };

            var expected = await searchesService.GetProgramsBySearchTextAsync(searchModel);

            Assert.Null(expected);
        }

        [Fact]
        public async Task GetProgramsBySearchTextAsyncShouldReturnProgramsSuccessfully()
        {
            var options = new DbContextOptionsBuilder<MyCalisthenicAppDbContext>()
                   .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                   .Options;

            var dbContext = new MyCalisthenicAppDbContext(options);

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MyCalisthenicAppProfile());
            });

            var mapper = mockMapper.CreateMapper();

            var searchesService = new SearchesService(dbContext, mapper);

            var category = new ProgramCategory
            {
                Name = CategoryName,
                Description = CategoryDescription,
            };

            await dbContext.ProgramCategories.AddAsync(category);

            await dbContext.SaveChangesAsync();

            for (int i = 0; i < 3; i++)
            {
                var program = new Program
                {
                    Title = ProgramTitle,
                    Description = ProgramDescription,
                    CategoryId = category.Id,
                };

                program.Images.Add(new Image
                {
                    Url = ImageUrl,
                });

                await dbContext.Programs.AddAsync(program);

                await dbContext.SaveChangesAsync();
            }

            var searchProgram = new Program
            {
                Title = ProgramTitle,
                Description = ProgramSearchDescription,
                CategoryId = category.Id,
            };

            searchProgram.Images.Add(new Image
            {
                Url = ImageUrl,
            });

            await dbContext.Programs.AddAsync(searchProgram);

            await dbContext.SaveChangesAsync();

            var searchModel = new SearchViewModel
            {
                Text = SearchText,
            };

            var expected = await searchesService.GetProgramsBySearchTextAsync(searchModel);

            var counter = 0;

            foreach (var post in expected)
            {
                counter++;
            }

            Assert.Equal(1, counter);
        }

        [Fact]
        public async Task GetProgramsBySearchTextAsyncShouldReturnNullIfNoSuchPrograms()
        {
            var options = new DbContextOptionsBuilder<MyCalisthenicAppDbContext>()
                   .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                   .Options;

            var dbContext = new MyCalisthenicAppDbContext(options);

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MyCalisthenicAppProfile());
            });

            var mapper = mockMapper.CreateMapper();

            var searchesService = new SearchesService(dbContext, mapper);

            var category = new ProgramCategory
            {
                Name = CategoryName,
                Description = CategoryDescription,
            };

            await dbContext.ProgramCategories.AddAsync(category);

            await dbContext.SaveChangesAsync();

            for (int i = 0; i < 3; i++)
            {
                var program = new Program
                {
                    Title = ProgramTitle,
                    Description = ProgramDescription,
                    CategoryId = category.Id,
                };

                program.Images.Add(new Image
                {
                    Url = ImageUrl,
                });

                await dbContext.Programs.AddAsync(program);

                await dbContext.SaveChangesAsync();
            }

            var searchModel = new SearchViewModel
            {
                Text = SearchText,
            };

            var expected = await searchesService.GetProgramsBySearchTextAsync(searchModel);

            Assert.Null(expected);
        }

        [Fact]
        public async Task GetProductsBySearchTextAsyncShouldReturnNullIfTextIsNull()
        {
            var options = new DbContextOptionsBuilder<MyCalisthenicAppDbContext>()
                   .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                   .Options;

            var dbContext = new MyCalisthenicAppDbContext(options);

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MyCalisthenicAppProfile());
            });

            var mapper = mockMapper.CreateMapper();

            var searchesService = new SearchesService(dbContext, mapper);

            var searchModel = new SearchViewModel
            {
                Text = null,
            };

            var expected = await searchesService.GetProductsBySearchTextAsync(searchModel);

            Assert.Null(expected);
        }

        [Fact]
        public async Task GetProductsBySearchTextAsyncShouldReturnNullIfTextIsLessThanFourSymbols()
        {
            var options = new DbContextOptionsBuilder<MyCalisthenicAppDbContext>()
                   .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                   .Options;

            var dbContext = new MyCalisthenicAppDbContext(options);

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MyCalisthenicAppProfile());
            });

            var mapper = mockMapper.CreateMapper();

            var searchesService = new SearchesService(dbContext, mapper);

            var searchModel = new SearchViewModel
            {
                Text = InvalidSearchText,
            };

            var expected = await searchesService.GetProductsBySearchTextAsync(searchModel);

            Assert.Null(expected);
        }

        [Fact]
        public async Task GetProductsBySearchTextAsyncShouldReturnProductsSuccessfully()
        {
            var options = new DbContextOptionsBuilder<MyCalisthenicAppDbContext>()
                   .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                   .Options;

            var dbContext = new MyCalisthenicAppDbContext(options);

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MyCalisthenicAppProfile());
            });

            var mapper = mockMapper.CreateMapper();

            var searchesService = new SearchesService(dbContext, mapper);

            var user = new ApplicationUser
            {
                FirstName = UserFirstName,
                LastName = UserLastName,
            };

            await dbContext.Users.AddAsync(user);

            await dbContext.SaveChangesAsync();

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
                    Price = ProductPrice,
                    CategoryId = category.Id,
                };

                product.Images.Add(new Image
                {
                    Url = ImageUrl,
                });

                product.Comments.Add(new Comment
                {
                    Text = CommentText,
                    ProductId = product.Id,
                    AuthorId = user.Id,
                });

                await dbContext.Products.AddAsync(product);

                await dbContext.SaveChangesAsync();
            }

            var searchProduct = new Product
            {
                Name = ProductName,
                Description = ProductSearchDescription,
                Price = ProductPrice,
                CategoryId = category.Id,
            };

            searchProduct.Images.Add(new Image
            {
                Url = ImageUrl,
            });

            searchProduct.Comments.Add(new Comment
            {
                Text = CommentText,
            });

            await dbContext.Products.AddAsync(searchProduct);

            await dbContext.SaveChangesAsync();

            var searchModel = new SearchViewModel
            {
                Text = SearchText,
            };

            var expected = await searchesService.GetProductsBySearchTextAsync(searchModel);

            var counter = 0;

            foreach (var post in expected)
            {
                counter++;
            }

            Assert.Equal(1, counter);
        }

        [Fact]
        public async Task GetProductsBySearchTextAsyncShouldReturnNullIfNoSuchProducts()
        {
            var options = new DbContextOptionsBuilder<MyCalisthenicAppDbContext>()
                   .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                   .Options;

            var dbContext = new MyCalisthenicAppDbContext(options);

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MyCalisthenicAppProfile());
            });

            var mapper = mockMapper.CreateMapper();

            var searchesService = new SearchesService(dbContext, mapper);

            var user = new ApplicationUser
            {
                FirstName = UserFirstName,
                LastName = UserLastName,
            };

            await dbContext.Users.AddAsync(user);

            await dbContext.SaveChangesAsync();

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
                    Price = ProductPrice,
                    CategoryId = category.Id,
                };

                product.Images.Add(new Image
                {
                    Url = ImageUrl,
                });

                product.Comments.Add(new Comment
                {
                    Text = CommentText,
                    ProductId = product.Id,
                    AuthorId = user.Id,
                });

                await dbContext.Products.AddAsync(product);

                await dbContext.SaveChangesAsync();
            }

            var searchModel = new SearchViewModel
            {
                Text = SearchText,
            };

            var expected = await searchesService.GetProductsBySearchTextAsync(searchModel);

            Assert.Null(expected);
        }
    }
}
