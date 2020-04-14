namespace MyCalisthenicApp.Services.Tests
{
    using AutoMapper;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Moq;
    using MyCalisthenicApp.Data;
    using MyCalisthenicApp.Mapping.MappingConfiguration;
    using MyCalisthenicApp.Models;
    using MyCalisthenicApp.Models.TrainingEntities;
    using MyCalisthenicApp.ViewModels.Exercises;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using Xunit;

    public class ExercisesServiceTests
    {
        private const string ExerciseId = "1234";
        private const string ExerciseName = "Exercise name";
        private const string ExerciseDescription = "Exercise description";
        private const string ExerciseEditDescription = "Exercise edit description";
        private const string ExerciseVideoUrl = "https://exercise1.com";
        private const string ProgramCategoryId = "123456";
        private const string CategoryName = "Category name";
        private const string CategoryDescription = "Category description";
        private const string UserId = "123";
        private const string UserFirstName = "Ivan";
        private const string UserLastName = "Ivanov";

        [Fact]
        public async Task GetExercisesByCategoryIdAsyncShouldThrowExpetionIfUserIsNull()
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

            var exercisesService = new ExercisesService(dbContext, mapper, usersService, categoriesService);

            var userFromDb = await usersService.GetLoggedUserByIdAsync(UserId);

            Assert.Null(userFromDb);
        }




        //TODO test first method in service and logg user



        [Fact]
        public async Task GetAllExercisesForAdminAsyncShouldReturnAllExercises()
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

            var exercisesService = new ExercisesService(dbContext, mapper, usersService, categoriesService);

            var programCategory = new ProgramCategory
            {
                Name = CategoryName,
                Description = CategoryDescription,
            };

            await dbContext.ProgramCategories.AddAsync(programCategory);

            await dbContext.SaveChangesAsync();

            for (int i = 0; i < 4; i++)
            {
                var exrecise = new Exercise
                {
                    Name = ExerciseName,
                    Description = ExerciseDescription,
                    VideoUrl = ExerciseVideoUrl,
                    ProgramCategoryId = programCategory.Id,
                };

                await dbContext.Exercises.AddAsync(exrecise);

                await dbContext.SaveChangesAsync();
            }

            var expected = await exercisesService.GetAllExercisesForAdminAsync();

            Assert.Equal(4, expected.Count);
        }

        [Fact]
        public async Task GetExerciseByIdAsyncShouldThrowExceptionIfExerciseIsNull()
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

            var exercisesService = new ExercisesService(dbContext, mapper, usersService, categoriesService);

            var exception = await Assert.ThrowsAsync<ArgumentNullException>(async () => await exercisesService.GetExerciseByIdAsync(ExerciseId));

            Assert.IsType<ArgumentNullException>(exception);
        }

        [Fact]
        public async Task GetExerciseByIdAsyncShouldReturnExerciseSuccessfully()
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

            var exercisesService = new ExercisesService(dbContext, mapper, usersService, categoriesService);

            var programCategory = new ProgramCategory
            {
                Name = CategoryName,
                Description = CategoryDescription,
            };

            await dbContext.ProgramCategories.AddAsync(programCategory);

            await dbContext.SaveChangesAsync();

            var exrecise = new Exercise
            {
                Id = ExerciseId,
                Name = ExerciseName,
                Description = ExerciseDescription,
                VideoUrl = ExerciseVideoUrl,
                ProgramCategoryId = programCategory.Id,
            };

            await dbContext.Exercises.AddAsync(exrecise);

            await dbContext.SaveChangesAsync();

            var expected = await exercisesService.GetExerciseByIdAsync(ExerciseId);

            Assert.Equal(expected.Id, exrecise.Id);
        }

        [Fact]
        public async Task EditExerciseAsyncShouldThrowExptionIfProgramCategoryIsNull()
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

            var exercisesService = new ExercisesService(dbContext, mapper, usersService, categoriesService);

            var programCategory = new ProgramCategory
            {
                Name = CategoryName,
                Description = CategoryDescription,
            };

            await dbContext.ProgramCategories.AddAsync(programCategory);

            await dbContext.SaveChangesAsync();

            var exerciseModel = new ExerciseAdminEditViewModel
            {
                Id = ExerciseId,
                Name = ExerciseName,
                Description = ExerciseDescription,
                VideoUrl = ExerciseVideoUrl,
                ProgramCategoryId = ProgramCategoryId,
            };

            var exception = await Assert.ThrowsAsync<ArgumentNullException>(async () => await exercisesService.EditExerciseAsync(exerciseModel));

            Assert.IsType<ArgumentNullException>(exception);
        }

        [Fact]
        public async Task EditExerciseAsyncShouldThrowExptionIfExerciseIsNull()
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

            var exercisesService = new ExercisesService(dbContext, mapper, usersService, categoriesService);

            var exerciseModel = new ExerciseAdminEditViewModel
            {
                Id = ExerciseId,
                Name = ExerciseName,
                Description = ExerciseDescription,
                VideoUrl = ExerciseVideoUrl,
                ProgramCategoryId = ProgramCategoryId,
            };

            var exception = await Assert.ThrowsAsync<ArgumentNullException>(async () => await exercisesService.EditExerciseAsync(exerciseModel));

            Assert.IsType<ArgumentNullException>(exception);
        }

        [Fact]
        public async Task EditExerciseAsyncShouldEditExerciseSuccessfully()
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

            var exercisesService = new ExercisesService(dbContext, mapper, usersService, categoriesService);

            var programCategory = new ProgramCategory
            {
                Name = CategoryName,
                Description = CategoryDescription,
            };

            await dbContext.ProgramCategories.AddAsync(programCategory);

            await dbContext.SaveChangesAsync();

            var exrecise = new Exercise
            {
                Id = ExerciseId,
                Name = ExerciseName,
                Description = ExerciseDescription,
                VideoUrl = ExerciseVideoUrl,
                ProgramCategoryId = programCategory.Id,
            };

            await dbContext.Exercises.AddAsync(exrecise);

            await dbContext.SaveChangesAsync();

            var exerciseModel = new ExerciseAdminEditViewModel
            {
                Id = ExerciseId,
                Name = ExerciseName,
                Description = ExerciseEditDescription,
                VideoUrl = ExerciseVideoUrl,
                ProgramCategoryId = programCategory.Id,
            };

            await exercisesService.EditExerciseAsync(exerciseModel);

            Assert.Equal(exrecise.Description, exerciseModel.Description);
        }

        [Fact]
        public async Task CreateExerciseAsyncShouldThrowExptionIfProgramCategoryIsNull()
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

            var exercisesService = new ExercisesService(dbContext, mapper, usersService, categoriesService);

            var programCategory = new ProgramCategory
            {
                Name = CategoryName,
                Description = CategoryDescription,
            };

            await dbContext.ProgramCategories.AddAsync(programCategory);

            await dbContext.SaveChangesAsync();

            var exerciseModel = new ExerciseAdminCreateViewModel
            {
                Name = ExerciseName,
                Description = ExerciseDescription,
                VideoUrl = ExerciseVideoUrl,
                ProgramCategoryId = ProgramCategoryId,
            };

            var exception = await Assert.ThrowsAsync<ArgumentNullException>(async () => await exercisesService.CreateExerciseAsync(exerciseModel));

            Assert.IsType<ArgumentNullException>(exception);
        }

        [Fact]
        public async Task CreateExerciseAsyncShouldCreateExerciseSuccessfully()
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

            var exercisesService = new ExercisesService(dbContext, mapper, usersService, categoriesService);

            var programCategory = new ProgramCategory
            {
                Name = CategoryName,
                Description = CategoryDescription,
            };

            await dbContext.ProgramCategories.AddAsync(programCategory);

            await dbContext.SaveChangesAsync();

            var exerciseModel = new ExerciseAdminCreateViewModel
            {
                Name = ExerciseName,
                Description = ExerciseDescription,
                VideoUrl = ExerciseVideoUrl,
                ProgramCategoryId = programCategory.Id,
            };

            await exercisesService.CreateExerciseAsync(exerciseModel);

            var actual = await dbContext.Exercises.FirstOrDefaultAsync(e => e.Name == exerciseModel.Name);

            Assert.Equal(actual.Name, exerciseModel.Name);
        }
    }
}
