namespace MyCalisthenicApp.Services.Tests
{
    using AutoMapper;
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;
    using MyCalisthenicApp.Data;
    using MyCalisthenicApp.Mapping.MappingConfiguration;
    using MyCalisthenicApp.Models;
    using MyCalisthenicApp.Models.Enums;
    using MyCalisthenicApp.Models.ShopEntities;
    using MyCalisthenicApp.ViewModels.Programs;
    using System;
    using System.Threading.Tasks;
    using Xunit;

    public class ProgramsServiceTests
    {
        private const string CategoryName = "Category name";
        private const string CategoryDescription = "Category description";
        private const string ProgramId = "856";
        private const string ProgramTitle = "Program title";
        private const string ProgramDescription = "Program description";
        private const string ProgramEnumType = "Advanced";
        private int? ProgramRating = 8;
        private const string ProgramLike = "Ivan Ivanov:83785";
        private const string ImageUrl = "https://image345.com";
        private const string CommentText = "Comment text";

        [Fact]
        public async Task GetAllProgramsAsyncShouldReturnProgramsSuccessfully()
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

            var programsService = new ProgramsService(dbContext, mapper, usersService, categoriesService);

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

                await dbContext.Programs.AddAsync(program);

                await dbContext.SaveChangesAsync();
            }

            var expected = await programsService.GetAllProgramsAsync();

            var counter = 0;

            foreach (var program in expected)
            {
                counter++;
            }

            Assert.Equal(3, counter);
        }

        [Fact]
        public async Task GetFivePopularProgramsAsyncShouldReturnFiveProgramsSuccessfully()
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

            var programsService = new ProgramsService(dbContext, mapper, usersService, categoriesService);

            var category = new ProgramCategory
            {
                Name = CategoryName,
                Description = CategoryDescription,
            };

            await dbContext.ProgramCategories.AddAsync(category);

            await dbContext.SaveChangesAsync();

            for (int i = 0; i < 7; i++)
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

            var expected = await programsService.GetFivePopularProgramsAsync();

            var counter = 0;

            foreach (var program in expected)
            {
                counter++;
            }

            Assert.Equal(5, counter);
        }

        [Fact]
        public async Task GetProgramDetailsByIdAsyncShouldThrowExceptionIfProgramIsNull()
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

            var programsService = new ProgramsService(dbContext, mapper, usersService, categoriesService);

            var exception = await Assert.ThrowsAsync<ArgumentNullException>(async () => await programsService.GetProgramDetailsByIdAsync(ProgramId));

            Assert.IsType<ArgumentNullException>(exception);
        }

        [Fact]
        public async Task GetProgramDetailsByIdAsyncShouldReturnProgramSuccessfully()
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

            var programsService = new ProgramsService(dbContext, mapper, usersService, categoriesService);

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

                program.Comments.Add(new Comment
                {
                    Text = CommentText,
                });

                await dbContext.Programs.AddAsync(program);

                await dbContext.SaveChangesAsync();
            }

            var programToReturn = new Program
            {
                Id = ProgramId,
                Title = ProgramTitle,
                Description = ProgramDescription,
                CategoryId = category.Id,

            };

            await dbContext.Programs.AddAsync(programToReturn);

            await dbContext.SaveChangesAsync();

            var expected = await programsService.GetProgramDetailsByIdAsync(ProgramId);

            Assert.Equal(expected.Id, programToReturn.Id);
        }

        [Fact]
        public async Task GetProgramsByCategoryAsyncShouldReturnProgramsSuccessfully()
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

            var programsService = new ProgramsService(dbContext, mapper, usersService, categoriesService);

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

            var programToReturn = new Program
            {
                Title = ProgramTitle,
                Description = ProgramDescription,
                CategoryId = category.Id,
                Type = ProgramType.Advanced,
            };

            programToReturn.Images.Add(new Image
            {
                Url = ImageUrl,
            });

            await dbContext.Programs.AddAsync(programToReturn);

            await dbContext.SaveChangesAsync();

            var expected = await programsService.GetProgramsByCategoryAsync(ProgramEnumType);

            var counter = 0;

            foreach (var program in expected)
            {
                counter++;
            }

            Assert.Equal(1, counter);
        }

        [Fact]
        public async Task AddRatingAsyncShouldThrowExpetionIfProgramIsNull()
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

            var programsService = new ProgramsService(dbContext, mapper, usersService, categoriesService);

            var exception = await Assert.ThrowsAsync<ArgumentNullException>(async () => await programsService.AddRatingAsync(ProgramId));

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

            var programsService = new ProgramsService(dbContext, mapper, usersService, categoriesService);

            var category = new ProgramCategory
            {
                Name = CategoryName,
                Description = CategoryDescription,
            };

            await dbContext.ProgramCategories.AddAsync(category);

            await dbContext.SaveChangesAsync();

            var program = new Program
            {
                Id = ProgramId,
                Title = ProgramTitle,
                Description = ProgramDescription,
                CategoryId = category.Id,
            };

            await dbContext.Programs.AddAsync(program);

            await dbContext.SaveChangesAsync();

            var exception = await Assert.ThrowsAsync<NullReferenceException>(async () => await programsService.AddRatingAsync(ProgramId));

            Assert.IsType<NullReferenceException>(exception);
        }

        [Fact]
        public async Task GetProgramByIdShouldReturnTrueIfProgramExists()
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

            var programsService = new ProgramsService(dbContext, mapper, usersService, categoriesService);

            var category = new ProgramCategory
            {
                Name = CategoryName,
                Description = CategoryDescription,
            };

            await dbContext.ProgramCategories.AddAsync(category);

            await dbContext.SaveChangesAsync();

            var program = new Program
            {
                Id = ProgramId,
                Title = ProgramTitle,
                Description = ProgramDescription,
                CategoryId = category.Id,
            };

            await dbContext.Programs.AddAsync(program);

            await dbContext.SaveChangesAsync();

            var result = programsService.GetProgramById(ProgramId);

            Assert.True(result);
        }

        [Fact]
        public async Task GetProgramByIdShouldReturnFalseIfProgramDoesNotExists()
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

            var programsService = new ProgramsService(dbContext, mapper, usersService, categoriesService);

            var category = new ProgramCategory
            {
                Name = CategoryName,
                Description = CategoryDescription,
            };

            await dbContext.ProgramCategories.AddAsync(category);

            await dbContext.SaveChangesAsync();

            var program = new Program
            {
                Title = ProgramTitle,
                Description = ProgramDescription,
                CategoryId = category.Id,
            };

            await dbContext.Programs.AddAsync(program);

            await dbContext.SaveChangesAsync();

            var result = programsService.GetProgramById(ProgramId);

            Assert.False(result);
        }

        [Fact]
        public async Task GetAllProgramsForAdminAsyncShouldReturnProgramsSuccessfully()
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

            var programsService = new ProgramsService(dbContext, mapper, usersService, categoriesService);

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

            var expected = await programsService.GetAllProgramsForAdminAsync();

            var counter = 0;

            foreach (var program in expected)
            {
                counter++;
            }

            Assert.Equal(3, counter);
        }

        [Fact]
        public async Task GetAllLikesByProgramIdAsyncShouldThrowExceptionIfProgramIsNull()
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

            var programsService = new ProgramsService(dbContext, mapper, usersService, categoriesService);

            var exception = await Assert.ThrowsAsync<ArgumentNullException>(async () => await programsService.GetAllLikesByProgramIdAsync(ProgramId));

            Assert.IsType<ArgumentNullException>(exception);
        }

        [Fact]
        public async Task GetAllLikesByProgramIdAsyncShouldReturnLikesSuccessfully()
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

            var programsService = new ProgramsService(dbContext, mapper, usersService, categoriesService);

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

                await dbContext.Programs.AddAsync(program);

                await dbContext.SaveChangesAsync();
            }

            var programToReturn = new Program
            {
                Id = ProgramId,
                Title = ProgramTitle,
                Description = ProgramDescription,
                CategoryId = category.Id,
            };

            programToReturn.LikesUsersNames.Add(ProgramLike);

            await dbContext.Programs.AddAsync(programToReturn);

            await dbContext.SaveChangesAsync();

            var expected = await programsService.GetAllLikesByProgramIdAsync(ProgramId);

            Assert.Equal(1, expected.Count);
        }

        [Fact]
        public async Task GetProgramByIdAsyncShouldThrowExceptionIfProgramIsNull()
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

            var programsService = new ProgramsService(dbContext, mapper, usersService, categoriesService);

            var exception = await Assert.ThrowsAsync<ArgumentNullException>(async () => await programsService.GetProgramByIdAsync(ProgramId));

            Assert.IsType<ArgumentNullException>(exception);
        }

        [Fact]
        public async Task GetProgramByIdAsyncShouldReturnProgramSuccessfully()
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

            var programsService = new ProgramsService(dbContext, mapper, usersService, categoriesService);

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

                await dbContext.Programs.AddAsync(program);

                await dbContext.SaveChangesAsync();
            }

            var programToReturn = new Program
            {
                Id = ProgramId,
                Title = ProgramTitle,
                Description = ProgramDescription,
                CategoryId = category.Id,
            };

            await dbContext.Programs.AddAsync(programToReturn);

            await dbContext.SaveChangesAsync();

            var expected = await programsService.GetProgramByIdAsync(ProgramId);

            Assert.Equal(expected.Id, programToReturn.Id);
        }

        [Fact]
        public async Task EditProgramAsyncShouldThrowExceptionIfCategoryIsIncorrect()
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

            var programsService = new ProgramsService(dbContext, mapper, usersService, categoriesService);

            var programModel = new ProgramAdminEditViewModel
            {
                Title = ProgramTitle,
                Description = ProgramDescription,
                CategoryId = null,
            };

            var exception = await Assert.ThrowsAsync<ArgumentNullException>(async () => await programsService.EditProgramAsync(programModel));

            Assert.IsType<ArgumentNullException>(exception);
        }

        [Fact]
        public async Task EditProgramAsyncShouldThrowExceptionIfProgramIsNull()
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

            var programsService = new ProgramsService(dbContext, mapper, usersService, categoriesService);

            var category = new ProgramCategory
            {
                Name = CategoryName,
                Description = CategoryDescription,
            };

            await dbContext.ProgramCategories.AddAsync(category);

            await dbContext.SaveChangesAsync();

            var programModel = new ProgramAdminEditViewModel
            {
                Title = ProgramTitle,
                Description = ProgramDescription,
                CategoryId = category.Id,
            };

            var exception = await Assert.ThrowsAsync<ArgumentNullException>(async () => await programsService.EditProgramAsync(programModel));

            Assert.IsType<ArgumentNullException>(exception);
        }

        [Fact]
        public async Task EditProgramAsyncShouldEditProgramSuccessfully()
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

            var programsService = new ProgramsService(dbContext, mapper, usersService, categoriesService);

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

                await dbContext.Programs.AddAsync(program);

                await dbContext.SaveChangesAsync();
            }

            var programToEdit = new Program
            {
                Title = ProgramTitle,
                Description = ProgramDescription,
                CategoryId = category.Id,
            };

            await dbContext.Programs.AddAsync(programToEdit);

            await dbContext.SaveChangesAsync();

            var programModel = new ProgramAdminEditViewModel
            {
                Id = programToEdit.Id,
                Title = ProgramTitle,
                Description = ProgramDescription,
                Rating = ProgramRating,
                CategoryId = category.Id,
            };

            await programsService.EditProgramAsync(programModel);

            var actual = await dbContext.Programs.FirstOrDefaultAsync(p => p.Id == programToEdit.Id);

            Assert.Equal(programToEdit.Rating, actual.Rating);
        }

        [Fact]
        public async Task CreateProgramAsyncShouldThrowExceptionIfCategoryIsIncorrect()
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

            var programsService = new ProgramsService(dbContext, mapper, usersService, categoriesService);

            var programModel = new ProgramAdminCreateViewModel
            {
                Title = ProgramTitle,
                Description = ProgramDescription,
                Rating = ProgramRating,
                CategoryId = null,
            };

            var exception = await Assert.ThrowsAsync<ArgumentNullException>(async () => await programsService.CreateProgramAsync(programModel));

            Assert.IsType<ArgumentNullException>(exception);
        }

        [Fact]
        public async Task CreateProgramAsyncShouldCreateProgramSuccessfully()
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

            var programsService = new ProgramsService(dbContext, mapper, usersService, categoriesService);

            var category = new ProgramCategory
            {
                Name = CategoryName,
                Description = CategoryDescription,
            };

            await dbContext.ProgramCategories.AddAsync(category);

            await dbContext.SaveChangesAsync();

            var programModel = new ProgramAdminCreateViewModel
            {
                Title = ProgramTitle,
                Description = ProgramDescription,
                Rating = ProgramRating,
                CategoryId = category.Id,
            };

            await programsService.CreateProgramAsync(programModel);

            var actual = await dbContext.Programs.FirstOrDefaultAsync();

            Assert.Equal(programModel.Title, actual.Title);
        }

    }
}
