namespace MyCalisthenicApp.Services.Tests
{
    using AutoMapper;
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;
    using MyCalisthenicApp.Data;
    using MyCalisthenicApp.Mapping.MappingConfiguration;
    using MyCalisthenicApp.Models.ShopEntities;
    using MyCalisthenicApp.ViewModels.Images;
    using System;
    using System.Threading.Tasks;
    using Xunit;

    public class ImagesServiceTests
    {
        private const string ImageId = "123456";
        private const string PostId = "123456";
        private const string ProgramId = "12345";
        private const string ProductId = "123";
        private const string ExerciseId = "12365";
        private const string ImageUrl = "https://image23.bg";
        private const string ImageEditUrl = "https://img-10.bg";


        [Fact]
        public async Task GetImageByIdAsyncShouldThrowExceptionIfImageIsNull()
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

            var postsService = new PostsService(dbContext, mapper, usersService, categoriesService);

            var productsService = new ProductsService(dbContext, mapper, usersService, categoriesService);

            var programsService = new ProgramsService(dbContext, mapper, usersService, categoriesService);

            var exercisesService = new ExercisesService(dbContext, mapper, usersService, categoriesService);

            var imagesService = new ImagesService(dbContext, mapper, postsService, exercisesService, productsService, programsService);

            var exception = await Assert.ThrowsAsync<ArgumentNullException>(async () => await imagesService.GetImageByIdAsync(ImageId));

            Assert.IsType<ArgumentNullException>(exception);
        }

        [Fact]
        public async Task GetImageByIdAsyncShouldReturnImageSuccessfully()
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

            var postsService = new PostsService(dbContext, mapper, usersService, categoriesService);

            var productsService = new ProductsService(dbContext, mapper, usersService, categoriesService);

            var programsService = new ProgramsService(dbContext, mapper, usersService, categoriesService);

            var exercisesService = new ExercisesService(dbContext, mapper, usersService, categoriesService);

            var imagesService = new ImagesService(dbContext, mapper, postsService, exercisesService, productsService, programsService);

            var image = new Image
            {
                Id = ImageId,
                Url = ImageUrl,
            };

            await dbContext.Images.AddAsync(image);

            await dbContext.SaveChangesAsync();

            var expected = await imagesService.GetImageByIdAsync(ImageId);

            Assert.Equal(image.Id, expected.Id);
        }

        [Fact]
        public async Task EditImageAsyncShouldThrowExceptionIfPostIdIsIncorrect()
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

            var postsService = new PostsService(dbContext, mapper, usersService, categoriesService);

            var productsService = new ProductsService(dbContext, mapper, usersService, categoriesService);

            var programsService = new ProgramsService(dbContext, mapper, usersService, categoriesService);

            var exercisesService = new ExercisesService(dbContext, mapper, usersService, categoriesService);

            var imagesService = new ImagesService(dbContext, mapper, postsService, exercisesService, productsService, programsService);

            var image = new Image
            {
                Id = ImageId,
                Url = ImageUrl,
            };

            await dbContext.Images.AddAsync(image);

            await dbContext.SaveChangesAsync();

            var imageModel = new ImageAdminEditViewModel
            {
                Url = ImageUrl,
                PostId = PostId,
            };

            var exception = await Assert.ThrowsAsync<ArgumentNullException>(async () => await imagesService.EditImageAsync(imageModel));

            Assert.IsType<ArgumentNullException>(exception);
        }

        [Fact]
        public async Task EditImageAsyncShouldThrowExceptionIfProductIdIsIncorrect()
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

            var postsService = new PostsService(dbContext, mapper, usersService, categoriesService);

            var productsService = new ProductsService(dbContext, mapper, usersService, categoriesService);

            var programsService = new ProgramsService(dbContext, mapper, usersService, categoriesService);

            var exercisesService = new ExercisesService(dbContext, mapper, usersService, categoriesService);

            var imagesService = new ImagesService(dbContext, mapper, postsService, exercisesService, productsService, programsService);

            var image = new Image
            {
                Id = ImageId,
                Url = ImageUrl,
            };

            await dbContext.Images.AddAsync(image);

            await dbContext.SaveChangesAsync();

            var imageModel = new ImageAdminEditViewModel
            {
                Url = ImageUrl,
                ProductId = ProductId,
            };

            var exception = await Assert.ThrowsAsync<ArgumentNullException>(async () => await imagesService.EditImageAsync(imageModel));

            Assert.IsType<ArgumentNullException>(exception);
        }

        [Fact]
        public async Task EditImageAsyncShouldThrowExceptionIfProgramIdIsIncorrect()
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

            var postsService = new PostsService(dbContext, mapper, usersService, categoriesService);

            var productsService = new ProductsService(dbContext, mapper, usersService, categoriesService);

            var programsService = new ProgramsService(dbContext, mapper, usersService, categoriesService);

            var exercisesService = new ExercisesService(dbContext, mapper, usersService, categoriesService);

            var imagesService = new ImagesService(dbContext, mapper, postsService, exercisesService, productsService, programsService);

            var image = new Image
            {
                Id = ImageId,
                Url = ImageUrl,
            };

            await dbContext.Images.AddAsync(image);

            await dbContext.SaveChangesAsync();

            var imageModel = new ImageAdminEditViewModel
            {
                Url = ImageUrl,
                ProgramId = ProgramId,
            };

            var exception = await Assert.ThrowsAsync<ArgumentNullException>(async () => await imagesService.EditImageAsync(imageModel));

            Assert.IsType<ArgumentNullException>(exception);
        }

        [Fact]
        public async Task EditImageAsyncShouldThrowExceptionIfImageIsNull()
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

            var postsService = new PostsService(dbContext, mapper, usersService, categoriesService);

            var productsService = new ProductsService(dbContext, mapper, usersService, categoriesService);

            var programsService = new ProgramsService(dbContext, mapper, usersService, categoriesService);

            var exercisesService = new ExercisesService(dbContext, mapper, usersService, categoriesService);

            var imagesService = new ImagesService(dbContext, mapper, postsService, exercisesService, productsService, programsService);

            var imageModel = new ImageAdminEditViewModel
            {
                Url = ImageUrl,
            };

            var exception = await Assert.ThrowsAsync<ArgumentNullException>(async () => await imagesService.EditImageAsync(imageModel));

            Assert.IsType<ArgumentNullException>(exception);
        }

        [Fact]
        public async Task EditImageAsyncShouldEditImageSuccessfully()
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

            var postsService = new PostsService(dbContext, mapper, usersService, categoriesService);

            var productsService = new ProductsService(dbContext, mapper, usersService, categoriesService);

            var programsService = new ProgramsService(dbContext, mapper, usersService, categoriesService);

            var exercisesService = new ExercisesService(dbContext, mapper, usersService, categoriesService);

            var imagesService = new ImagesService(dbContext, mapper, postsService, exercisesService, productsService, programsService);

            var image = new Image
            {
                Id = ImageId,
                Url = ImageUrl,
            };

            await dbContext.Images.AddAsync(image);

            await dbContext.SaveChangesAsync();

            var imageModel = new ImageAdminEditViewModel
            {
                Id = ImageId,
                Url = ImageEditUrl,
            };

            await imagesService.EditImageAsync(imageModel);

            var actual = dbContext.Images.FirstOrDefaultAsync(i => i.Id == image.Id);

            Assert.Equal(imageModel.Url, actual.Result.Url);
        }

        [Fact]
        public async Task GetAllImagesForAdminAsyncShouldReturnAllImagesSuccessfully()
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

            var postsService = new PostsService(dbContext, mapper, usersService, categoriesService);

            var productsService = new ProductsService(dbContext, mapper, usersService, categoriesService);

            var programsService = new ProgramsService(dbContext, mapper, usersService, categoriesService);

            var exercisesService = new ExercisesService(dbContext, mapper, usersService, categoriesService);

            var imagesService = new ImagesService(dbContext, mapper, postsService, exercisesService, productsService, programsService);

            for (int i = 0; i < 4; i++)
            {
                var image = new Image
                {
                    Url = ImageUrl,
                };

                await dbContext.Images.AddAsync(image);

                await dbContext.SaveChangesAsync();
            }

            var expected = await imagesService.GetAllImagesForAdminAsync();

            Assert.Equal(4, expected.Count);
        }

        [Fact]
        public async Task GetImagesByProductIdAsyncShouldThrowExceptionIfProductIdIsIncorrect()
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

            var postsService = new PostsService(dbContext, mapper, usersService, categoriesService);

            var productsService = new ProductsService(dbContext, mapper, usersService, categoriesService);

            var programsService = new ProgramsService(dbContext, mapper, usersService, categoriesService);

            var exercisesService = new ExercisesService(dbContext, mapper, usersService, categoriesService);

            var imagesService = new ImagesService(dbContext, mapper, postsService, exercisesService, productsService, programsService);

            for (int i = 0; i < 4; i++)
            {
                var image = new Image
                {
                    Url = ImageUrl,
                };

                await dbContext.Images.AddAsync(image);

                await dbContext.SaveChangesAsync();
            }

            var expected = await imagesService.GetImagesByProductIdAsync(ProductId);

            var counter = 0;

            foreach (var image in expected)
            {
                counter++;
            }

            Assert.Equal(0, counter);
        }

        [Fact]
        public async Task GetImagesByProductIdAsyncShouldReturnImagesSuccessfully()
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

            var postsService = new PostsService(dbContext, mapper, usersService, categoriesService);

            var productsService = new ProductsService(dbContext, mapper, usersService, categoriesService);

            var programsService = new ProgramsService(dbContext, mapper, usersService, categoriesService);

            var exercisesService = new ExercisesService(dbContext, mapper, usersService, categoriesService);

            var imagesService = new ImagesService(dbContext, mapper, postsService, exercisesService, productsService, programsService);

            for (int i = 0; i < 4; i++)
            {
                var image = new Image
                {
                    Url = ImageUrl,
                    ProductId = ProductId,
                };

                await dbContext.Images.AddAsync(image);

                await dbContext.SaveChangesAsync();
            }

            var expected = await imagesService.GetImagesByProductIdAsync(ProductId);

            var counter = 0;

            foreach (var img in expected)
            {
                counter++;
            }

            Assert.Equal(4, counter);
        }

        [Fact]
        public async Task CreateImageAsyncShouldThrowExpetionIfPostIdIsIncorrect()
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

            var postsService = new PostsService(dbContext, mapper, usersService, categoriesService);

            var productsService = new ProductsService(dbContext, mapper, usersService, categoriesService);

            var programsService = new ProgramsService(dbContext, mapper, usersService, categoriesService);

            var exercisesService = new ExercisesService(dbContext, mapper, usersService, categoriesService);

            var imagesService = new ImagesService(dbContext, mapper, postsService, exercisesService, productsService, programsService);

            var imageModel = new ImageAdminCreateViewModel
            {
                Url = ImageUrl,
                PostId = PostId,
            };

            var exception = await Assert.ThrowsAsync<ArgumentNullException>(async () => await imagesService.CreateImageAsync(imageModel));

            Assert.IsType<ArgumentNullException>(exception);
        }

        [Fact]
        public async Task CreateImageAsyncShouldThrowExpetionIfProductIdIsIncorrect()
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

            var postsService = new PostsService(dbContext, mapper, usersService, categoriesService);

            var productsService = new ProductsService(dbContext, mapper, usersService, categoriesService);

            var programsService = new ProgramsService(dbContext, mapper, usersService, categoriesService);

            var exercisesService = new ExercisesService(dbContext, mapper, usersService, categoriesService);

            var imagesService = new ImagesService(dbContext, mapper, postsService, exercisesService, productsService, programsService);

            var imageModel = new ImageAdminCreateViewModel
            {
                Url = ImageUrl,
                ProductId = ProductId,
            };

            var exception = await Assert.ThrowsAsync<ArgumentNullException>(async () => await imagesService.CreateImageAsync(imageModel));

            Assert.IsType<ArgumentNullException>(exception);
        }

        [Fact]
        public async Task CreateImageAsyncShouldThrowExpetionIfProgramIdIsIncorrect()
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

            var postsService = new PostsService(dbContext, mapper, usersService, categoriesService);

            var productsService = new ProductsService(dbContext, mapper, usersService, categoriesService);

            var programsService = new ProgramsService(dbContext, mapper, usersService, categoriesService);

            var exercisesService = new ExercisesService(dbContext, mapper, usersService, categoriesService);

            var imagesService = new ImagesService(dbContext, mapper, postsService, exercisesService, productsService, programsService);

            var imageModel = new ImageAdminCreateViewModel
            {
                Url = ImageUrl,
                ProgramId = ProgramId,
            };

            var exception = await Assert.ThrowsAsync<ArgumentNullException>(async () => await imagesService.CreateImageAsync(imageModel));

            Assert.IsType<ArgumentNullException>(exception);
        }

        [Fact]
        public async Task CreateImageAsyncShouldThrowExpetionIfExerciseIdIsIncorrect()
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

            var postsService = new PostsService(dbContext, mapper, usersService, categoriesService);

            var productsService = new ProductsService(dbContext, mapper, usersService, categoriesService);

            var programsService = new ProgramsService(dbContext, mapper, usersService, categoriesService);

            var exercisesService = new ExercisesService(dbContext, mapper, usersService, categoriesService);

            var imagesService = new ImagesService(dbContext, mapper, postsService, exercisesService, productsService, programsService);

            var imageModel = new ImageAdminCreateViewModel
            {
                Url = ImageUrl,
                ExerciseId = ExerciseId,
            };

            var exception = await Assert.ThrowsAsync<ArgumentNullException>(async () => await imagesService.CreateImageAsync(imageModel));

            Assert.IsType<ArgumentNullException>(exception);
        }

        [Fact]
        public async Task CreateImageAsyncShouldCreateImageSuccessfully()
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

            var postsService = new PostsService(dbContext, mapper, usersService, categoriesService);

            var productsService = new ProductsService(dbContext, mapper, usersService, categoriesService);

            var programsService = new ProgramsService(dbContext, mapper, usersService, categoriesService);

            var exercisesService = new ExercisesService(dbContext, mapper, usersService, categoriesService);

            var imagesService = new ImagesService(dbContext, mapper, postsService, exercisesService, productsService, programsService);

            var imageModel = new ImageAdminCreateViewModel
            {
                Url = ImageUrl,
            };

            await imagesService.CreateImageAsync(imageModel);

            var actual = await dbContext.Images.FirstOrDefaultAsync(i => i.Url == imageModel.Url);

            Assert.Equal(imageModel.Url, actual.Url);
        }
    }
}
