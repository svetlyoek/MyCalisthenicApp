namespace MyCalisthenicApp.Services.Tests
{
    using AutoMapper;
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;
    using MyCalisthenicApp.Data;
    using MyCalisthenicApp.Mapping.MappingConfiguration;
    using MyCalisthenicApp.Models;
    using MyCalisthenicApp.Models.BlogEntities;
    using MyCalisthenicApp.Models.BlogEntities.Enums;
    using MyCalisthenicApp.Models.ShopEntities;
    using MyCalisthenicApp.ViewModels.Home;
    using MyCalisthenicApp.ViewModels.Posts;
    using System;
    using System.Threading.Tasks;
    using Xunit;

    public class PostsServiceTests
    {
        private const string PostId = "16364";
        private const string PostTitle = "Post title";
        private const string PostLike = "Ivan Ivanov:1234";
        private const string SearchTitle = "Search text something";
        private const string PostDescription = "Post description";
        private const string PostEditDescription = "Post edit description";
        private const string PostCategory = "Motivation";
        private const string CategoryId = "5487567";
        private const string CategoryName = "Category name";
        private const string ImageUrl = "https://image23.bg";
        private const string CommentText = "Comment text";
        private const string UserId = "7475";
        private const string UserFirstName = "Ivan";
        private const string UserLastName = "Ivanov";
        private const string SearchText = "Search text";
        private const string InvalidSearchText = "aaa";

        [Fact]
        public async Task AddRatingAsyncShouldThrowExceptionIfPostIsNull()
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

            var postService = new PostsService(dbContext, mapper, usersService, categoriesService);

            var exception = await Assert.ThrowsAsync<ArgumentNullException>(async () => await postService.AddRatingAsync(PostId));

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

            var postService = new PostsService(dbContext, mapper, usersService, categoriesService);

            var category = new BlogCategory
            {
                Name = CategoryName,
            };

            await dbContext.BlogCategories.AddAsync(category);

            await dbContext.SaveChangesAsync();

            var post = new Post
            {
                Title = PostTitle,
                Description = PostDescription,
                CategoryId = category.Id,
            };

            await dbContext.Post.AddAsync(post);

            await dbContext.SaveChangesAsync();

            var exception = await Assert.ThrowsAsync<NullReferenceException>(async () => await postService.AddRatingAsync(post.Id));

            Assert.IsType<NullReferenceException>(exception);
        }

        [Fact]
        public async Task GetAllPostsAsyncShouldReturnAllPostsSuccessfully()
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

            var postService = new PostsService(dbContext, mapper, usersService, categoriesService);

            var user = new ApplicationUser
            {
                FirstName = UserFirstName,
                LastName = UserLastName,
            };

            await dbContext.Users.AddAsync(user);

            await dbContext.SaveChangesAsync();

            var category = new BlogCategory
            {
                Name = CategoryName,
            };

            await dbContext.BlogCategories.AddAsync(category);

            await dbContext.SaveChangesAsync();

            for (int i = 0; i < 4; i++)
            {
                var post = new Post
                {
                    Title = PostTitle,
                    Description = PostDescription,
                    CategoryId = category.Id,
                    AuthorId = user.Id,
                };

                post.Images.Add(new Image
                {
                    Url = ImageUrl,
                    PostId = post.Id,
                });

                post.Comments.Add(new Comment
                {
                    Text = CommentText,
                    PostId = post.Id,
                });

                await dbContext.Post.AddAsync(post);

                await dbContext.SaveChangesAsync();
            }

            var counter = 0;

            var expected = await postService.GetAllPostsAsync();

            foreach (var post in expected)
            {
                counter++;
            }

            Assert.Equal(4, counter);
        }

        [Fact]
        public async Task GetFourLatestPostsAsyncShouldReturnFourLatestPostsSuccessfully()
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

            var postService = new PostsService(dbContext, mapper, usersService, categoriesService);

            var user = new ApplicationUser
            {
                FirstName = UserFirstName,
                LastName = UserLastName,
            };

            await dbContext.Users.AddAsync(user);

            await dbContext.SaveChangesAsync();

            var category = new BlogCategory
            {
                Name = CategoryName,
            };

            await dbContext.BlogCategories.AddAsync(category);

            await dbContext.SaveChangesAsync();

            for (int i = 0; i < 5; i++)
            {
                var post = new Post
                {
                    Title = PostTitle,
                    Description = PostDescription,
                    CategoryId = category.Id,
                    AuthorId = user.Id,
                };

                post.Images.Add(new Image
                {
                    Url = ImageUrl,
                    PostId = post.Id,
                });

                await dbContext.Post.AddAsync(post);

                await dbContext.SaveChangesAsync();
            }

            var counter = 0;

            var expected = await postService.GetFourLatestPostsAsync();

            foreach (var post in expected)
            {
                counter++;
            }

            Assert.Equal(4, counter);
        }

        [Fact]
        public async Task GetPopularPostsAsyncShouldReturnPopularPostsSuccessfully()
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

            var postService = new PostsService(dbContext, mapper, usersService, categoriesService);

            var user = new ApplicationUser
            {
                FirstName = UserFirstName,
                LastName = UserLastName,
            };

            await dbContext.Users.AddAsync(user);

            await dbContext.SaveChangesAsync();

            var category = new BlogCategory
            {
                Name = CategoryName,
            };

            await dbContext.BlogCategories.AddAsync(category);

            await dbContext.SaveChangesAsync();

            for (int i = 0; i < 9; i++)
            {
                var post = new Post
                {
                    Title = PostTitle,
                    Description = PostDescription,
                    CategoryId = category.Id,
                    AuthorId = user.Id,
                };

                post.Images.Add(new Image
                {
                    Url = ImageUrl,
                    PostId = post.Id,
                });

                post.Comments.Add(new Comment
                {
                    Text = CommentText,
                    PostId = post.Id,
                });

                await dbContext.Post.AddAsync(post);

                await dbContext.SaveChangesAsync();
            }

            var counter = 0;

            var expected = await postService.GetPopularPostsAsync();

            foreach (var post in expected)
            {
                counter++;
            }

            Assert.Equal(8, counter);
        }

        [Fact]
        public async Task GetPostByIdShouldReturnTrueIfPostExists()
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

            var postService = new PostsService(dbContext, mapper, usersService, categoriesService);

            var user = new ApplicationUser
            {
                FirstName = UserFirstName,
                LastName = UserLastName,
            };

            await dbContext.Users.AddAsync(user);

            await dbContext.SaveChangesAsync();

            var category = new BlogCategory
            {
                Name = CategoryName,
            };

            await dbContext.BlogCategories.AddAsync(category);

            await dbContext.SaveChangesAsync();

            var post = new Post
            {
                Id = PostId,
                Title = PostTitle,
                Description = PostDescription,
                CategoryId = category.Id,
                AuthorId = user.Id,
            };

            await dbContext.Post.AddAsync(post);

            await dbContext.SaveChangesAsync();

            var expected = postService.GetPostById(post.Id);

            Assert.True(expected);
        }

        [Fact]
        public async Task GetPostByIdShouldReturnFalseIfPostDoesNotExists()
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

            var postService = new PostsService(dbContext, mapper, usersService, categoriesService);

            var user = new ApplicationUser
            {
                FirstName = UserFirstName,
                LastName = UserLastName,
            };

            await dbContext.Users.AddAsync(user);

            await dbContext.SaveChangesAsync();

            var category = new BlogCategory
            {
                Name = CategoryName,
            };

            await dbContext.BlogCategories.AddAsync(category);

            await dbContext.SaveChangesAsync();

            var post = new Post
            {
                Title = PostTitle,
                Description = PostDescription,
                CategoryId = category.Id,
                AuthorId = user.Id,
            };

            await dbContext.Post.AddAsync(post);

            await dbContext.SaveChangesAsync();

            var expected = postService.GetPostById(PostId);

            Assert.False(expected);
        }

        [Fact]
        public async Task GetPostDetailsByIdAsyncShouldThrowExceptionIfPostIsNull()
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

            var postService = new PostsService(dbContext, mapper, usersService, categoriesService);

            var user = new ApplicationUser
            {
                FirstName = UserFirstName,
                LastName = UserLastName,
            };

            await dbContext.Users.AddAsync(user);

            await dbContext.SaveChangesAsync();

            var category = new BlogCategory
            {
                Name = CategoryName,
            };

            await dbContext.BlogCategories.AddAsync(category);

            await dbContext.SaveChangesAsync();

            var post = new Post
            {
                Title = PostTitle,
                Description = PostDescription,
                CategoryId = category.Id,
                AuthorId = user.Id,
            };

            await dbContext.Post.AddAsync(post);

            await dbContext.SaveChangesAsync();

            var exception = await Assert.ThrowsAsync<ArgumentNullException>(async () => await postService.GetPostDetailsByIdAsync(PostId));

            Assert.IsType<ArgumentNullException>(exception);
        }

        [Fact]
        public async Task GetPostDetailsByIdAsyncShouldreturnPostSuccessfully()
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

            var postService = new PostsService(dbContext, mapper, usersService, categoriesService);

            var user = new ApplicationUser
            {
                FirstName = UserFirstName,
                LastName = UserLastName,
            };

            await dbContext.Users.AddAsync(user);

            await dbContext.SaveChangesAsync();

            var category = new BlogCategory
            {
                Name = CategoryName,
            };

            await dbContext.BlogCategories.AddAsync(category);

            await dbContext.SaveChangesAsync();

            var post = new Post
            {
                Id = PostId,
                Title = PostTitle,
                Description = PostDescription,
                CategoryId = category.Id,
                AuthorId = user.Id,
            };

            await dbContext.Post.AddAsync(post);

            await dbContext.SaveChangesAsync();

            var expected = await postService.GetPostDetailsByIdAsync(PostId);

            Assert.Equal(expected.Id, post.Id);
        }

        [Fact]
        public async Task GetPostsBySearchAsyncShouldThrowNullIfTextIsNull()
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

            var postService = new PostsService(dbContext, mapper, usersService, categoriesService);

            var postModel = new SearchViewModel
            {
                Text = null,
            };

            var expected = await postService.GetPostsBySearchAsync(postModel);

            Assert.Null(expected);
        }

        [Fact]
        public async Task GetPostsBySearchAsyncShouldThrowNullIfTextLengthIslessThanFourSymbols()
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

            var postService = new PostsService(dbContext, mapper, usersService, categoriesService);

            var postModel = new SearchViewModel
            {
                Text = InvalidSearchText,
            };

            var expected = await postService.GetPostsBySearchAsync(postModel);

            Assert.Null(expected);
        }

        [Fact]
        public async Task GetPostsBySearchAsyncShouldReturnPostsSuccessfully()
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

            var postService = new PostsService(dbContext, mapper, usersService, categoriesService);

            var user = new ApplicationUser
            {
                FirstName = UserFirstName,
                LastName = UserLastName,
            };

            await dbContext.Users.AddAsync(user);

            await dbContext.SaveChangesAsync();

            var category = new BlogCategory
            {
                Name = CategoryName,
            };

            await dbContext.BlogCategories.AddAsync(category);

            await dbContext.SaveChangesAsync();

            for (int i = 0; i < 2; i++)
            {
                var searchPost = new Post
                {
                    Title = SearchTitle,
                    Description = PostDescription,
                    CategoryId = category.Id,
                    AuthorId = user.Id,

                };

                searchPost.Images.Add(new Image
                {
                    Url = ImageUrl,
                    PostId = searchPost.Id,
                });

                searchPost.Comments.Add(new Comment
                {
                    Text = CommentText,
                    PostId = searchPost.Id,
                });

                await dbContext.Post.AddAsync(searchPost);

                await dbContext.SaveChangesAsync();
            }

            var post = new Post
            {
                Title = PostTitle,
                Description = PostDescription,
                CategoryId = category.Id,
                AuthorId = user.Id,
            };

            await dbContext.Post.AddAsync(post);

            await dbContext.SaveChangesAsync();

            var postModel = new SearchViewModel
            {
                Text = SearchText,
            };

            var expected = await postService.GetPostsBySearchAsync(postModel);

            var counter = 0;

            foreach (var searchPost in expected)
            {
                counter++;
            }

            Assert.Equal(2, counter);
        }

        [Fact]
        public async Task GetPostsBySearchAsyncShouldReturnNullIfPostsNotFound()
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

            var postService = new PostsService(dbContext, mapper, usersService, categoriesService);

            var user = new ApplicationUser
            {
                FirstName = UserFirstName,
                LastName = UserLastName,
            };

            await dbContext.Users.AddAsync(user);

            await dbContext.SaveChangesAsync();

            var category = new BlogCategory
            {
                Name = CategoryName,
            };

            await dbContext.BlogCategories.AddAsync(category);

            await dbContext.SaveChangesAsync();

            for (int i = 0; i < 2; i++)
            {
                var searchPost = new Post
                {
                    Title = PostTitle,
                    Description = PostDescription,
                    CategoryId = category.Id,
                    AuthorId = user.Id,

                };

                searchPost.Images.Add(new Image
                {
                    Url = ImageUrl,
                    PostId = searchPost.Id,
                });

                searchPost.Comments.Add(new Comment
                {
                    Text = CommentText,
                    PostId = searchPost.Id,
                });

                await dbContext.Post.AddAsync(searchPost);

                await dbContext.SaveChangesAsync();
            }

            var post = new Post
            {
                Title = PostTitle,
                Description = PostDescription,
                CategoryId = category.Id,
                AuthorId = user.Id,
            };

            await dbContext.Post.AddAsync(post);

            await dbContext.SaveChangesAsync();

            var postModel = new SearchViewModel
            {
                Text = SearchText,
            };

            var expected = await postService.GetPostsBySearchAsync(postModel);

            Assert.Null(expected);
        }

        [Fact]
        public async Task SortPostsByCategoryAsyncShouldReturnSortedPostsSuccessfully()
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

            var postService = new PostsService(dbContext, mapper, usersService, categoriesService);

            var user = new ApplicationUser
            {
                FirstName = UserFirstName,
                LastName = UserLastName,
            };

            await dbContext.Users.AddAsync(user);

            await dbContext.SaveChangesAsync();

            var category = new BlogCategory
            {
                Name = CategoryName,
            };

            await dbContext.BlogCategories.AddAsync(category);

            await dbContext.SaveChangesAsync();

            for (int i = 0; i < 2; i++)
            {
                var sortPost = new Post
                {
                    Title = PostTitle,
                    Description = PostDescription,
                    CategoryId = category.Id,
                    AuthorId = user.Id,
                    Type = CategoryType.Motivation,
                };

                sortPost.Images.Add(new Image
                {
                    Url = ImageUrl,
                    PostId = sortPost.Id,
                });

                sortPost.Comments.Add(new Comment
                {
                    Text = CommentText,
                    PostId = sortPost.Id,
                });

                await dbContext.Post.AddAsync(sortPost);

                await dbContext.SaveChangesAsync();
            }

            var post = new Post
            {
                Title = PostTitle,
                Description = PostDescription,
                CategoryId = category.Id,
                AuthorId = user.Id,
                Type = CategoryType.BeginnerCalisthenic,
            };

            await dbContext.Post.AddAsync(post);

            await dbContext.SaveChangesAsync();

            var expected = await postService.SortPostsByCategoryAsync(PostCategory);

            var counter = 0;

            foreach (var sortPost in expected)
            {
                counter++;
            }

            Assert.Equal(2, counter);
        }

        [Fact]
        public async Task GetAllPostsForAdminAsyncShouldReturnAllPostsSuccessfully()
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

            var postService = new PostsService(dbContext, mapper, usersService, categoriesService);

            var user = new ApplicationUser
            {
                FirstName = UserFirstName,
                LastName = UserLastName,
            };

            await dbContext.Users.AddAsync(user);

            await dbContext.SaveChangesAsync();

            var category = new BlogCategory
            {
                Name = CategoryName,
            };

            await dbContext.BlogCategories.AddAsync(category);

            await dbContext.SaveChangesAsync();

            for (int i = 0; i < 2; i++)
            {
                var sortPost = new Post
                {
                    Title = PostTitle,
                    Description = PostDescription,
                    CategoryId = category.Id,
                    AuthorId = user.Id,
                };

                sortPost.Images.Add(new Image
                {
                    Url = ImageUrl,
                    PostId = sortPost.Id,
                });

                sortPost.Comments.Add(new Comment
                {
                    Text = CommentText,
                    PostId = sortPost.Id,
                });

                await dbContext.Post.AddAsync(sortPost);

                await dbContext.SaveChangesAsync();
            }

            var expected = await postService.GetAllPostsForAdminAsync();

            var counter = 0;

            foreach (var sortPost in expected)
            {
                counter++;
            }

            Assert.Equal(2, counter);
        }


        [Fact]
        public async Task GetAllLikesByPostIdAsyncShouldThrowExceptionIfPostIsNull()
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

            var postService = new PostsService(dbContext, mapper, usersService, categoriesService);

            var exception = await Assert.ThrowsAsync<ArgumentNullException>(async () => await postService.GetAllLikesByPostIdAsync(PostId));

            Assert.IsType<ArgumentNullException>(exception);
        }

        [Fact]
        public async Task GetAllLikesByPostIdAsyncShouldReturnPostSuccessfully()
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

            var postService = new PostsService(dbContext, mapper, usersService, categoriesService);

            var user = new ApplicationUser
            {
                FirstName = UserFirstName,
                LastName = UserLastName,
            };

            await dbContext.Users.AddAsync(user);

            await dbContext.SaveChangesAsync();

            var category = new BlogCategory
            {
                Name = CategoryName,
            };

            await dbContext.BlogCategories.AddAsync(category);

            await dbContext.SaveChangesAsync();

            var post = new Post
            {
                Id = PostId,
                Title = PostTitle,
                Description = PostDescription,
                CategoryId = category.Id,
                AuthorId = user.Id,
            };

            post.LikesUsersNames.Add(PostLike);

            await dbContext.Post.AddAsync(post);

            await dbContext.SaveChangesAsync();

            var expected = await postService.GetAllLikesByPostIdAsync(PostId);

            Assert.Equal(1, expected.Count);
        }

        [Fact]
        public async Task GetPostForAdminByIdAsyncShouldThrowExceptionIfPostIsNull()
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

            var postService = new PostsService(dbContext, mapper, usersService, categoriesService);

            var exception = await Assert.ThrowsAsync<ArgumentNullException>(async () => await postService.GetPostForAdminByIdAsync(PostId));

            Assert.IsType<ArgumentNullException>(exception);
        }

        [Fact]
        public async Task GetPostForAdminByIdAsyncShouldReturnPostSuccessfully()
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

            var postService = new PostsService(dbContext, mapper, usersService, categoriesService);

            var user = new ApplicationUser
            {
                FirstName = UserFirstName,
                LastName = UserLastName,
            };

            await dbContext.Users.AddAsync(user);

            await dbContext.SaveChangesAsync();

            var category = new BlogCategory
            {
                Name = CategoryName,
            };

            await dbContext.BlogCategories.AddAsync(category);

            await dbContext.SaveChangesAsync();

            var post = new Post
            {
                Id = PostId,
                Title = PostTitle,
                Description = PostDescription,
                CategoryId = category.Id,
                AuthorId = user.Id,
            };

            await dbContext.Post.AddAsync(post);

            await dbContext.SaveChangesAsync();

            var expected = await postService.GetPostForAdminByIdAsync(PostId);

            Assert.Equal(expected.Id, post.Id);
        }

        [Fact]
        public async Task EditPostAsyncShouldThrowExceptionIfUserIsIncorrect()
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

            var postService = new PostsService(dbContext, mapper, usersService, categoriesService);

            var user = new ApplicationUser
            {
                FirstName = UserFirstName,
                LastName = UserLastName,
            };

            await dbContext.Users.AddAsync(user);

            await dbContext.SaveChangesAsync();

            var category = new BlogCategory
            {
                Name = CategoryName,
            };

            await dbContext.BlogCategories.AddAsync(category);

            await dbContext.SaveChangesAsync();

            var postModel = new PostAdminEditViewModel
            {
                Title = PostTitle,
                Description = PostDescription,
                CategoryId = category.Id,
                AuthorId = UserId,
            };

            var exception = await Assert.ThrowsAsync<ArgumentNullException>(async () => await postService.EditPostAsync(postModel));

            Assert.IsType<ArgumentNullException>(exception);
        }

        [Fact]
        public async Task EditPostAsyncShouldThrowExceptionIfCategoryIsIncorrect()
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

            var postService = new PostsService(dbContext, mapper, usersService, categoriesService);

            var user = new ApplicationUser
            {
                FirstName = UserFirstName,
                LastName = UserLastName,
            };

            await dbContext.Users.AddAsync(user);

            await dbContext.SaveChangesAsync();

            var category = new BlogCategory
            {
                Name = CategoryName,
            };

            await dbContext.BlogCategories.AddAsync(category);

            await dbContext.SaveChangesAsync();

            var postModel = new PostAdminEditViewModel
            {
                Title = PostTitle,
                Description = PostDescription,
                CategoryId = CategoryId,
                AuthorId = user.Id,
            };

            var exception = await Assert.ThrowsAsync<ArgumentNullException>(async () => await postService.EditPostAsync(postModel));

            Assert.IsType<ArgumentNullException>(exception);
        }

        [Fact]
        public async Task EditPostAsyncShouldThrowExceptionIfPostIsNull()
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

            var postService = new PostsService(dbContext, mapper, usersService, categoriesService);

            var user = new ApplicationUser
            {
                FirstName = UserFirstName,
                LastName = UserLastName,
            };

            await dbContext.Users.AddAsync(user);

            await dbContext.SaveChangesAsync();

            var category = new BlogCategory
            {
                Name = CategoryName,
            };

            await dbContext.BlogCategories.AddAsync(category);

            await dbContext.SaveChangesAsync();

            var postModel = new PostAdminEditViewModel
            {
                Title = PostTitle,
                Description = PostDescription,
                CategoryId = category.Id,
                AuthorId = user.Id,
            };

            var exception = await Assert.ThrowsAsync<ArgumentNullException>(async () => await postService.EditPostAsync(postModel));

            Assert.IsType<ArgumentNullException>(exception);
        }

        [Fact]
        public async Task EditPostAsyncShouldEditPostSuccessfully()
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

            var postService = new PostsService(dbContext, mapper, usersService, categoriesService);

            var user = new ApplicationUser
            {
                FirstName = UserFirstName,
                LastName = UserLastName,
            };

            await dbContext.Users.AddAsync(user);

            await dbContext.SaveChangesAsync();

            var category = new BlogCategory
            {
                Name = CategoryName,
            };

            await dbContext.BlogCategories.AddAsync(category);

            await dbContext.SaveChangesAsync();

            var post = new Post
            {
                Id = PostId,
                Title = PostTitle,
                Description = PostDescription,
                AuthorId = user.Id,
                CategoryId = category.Id,
            };

            await dbContext.Post.AddAsync(post);

            await dbContext.SaveChangesAsync();

            var postModel = new PostAdminEditViewModel
            {
                Id = PostId,
                Title = PostTitle,
                Description = PostEditDescription,
                CategoryId = category.Id,
                AuthorId = user.Id,
            };

            await postService.EditPostAsync(postModel);

            var actual = await dbContext.Post.FirstOrDefaultAsync(p => p.Id == post.Id);

            Assert.Equal(post.Description, actual.Description);
        }

        [Fact]
        public async Task CreatePostAsyncShouldThrowExceptionIfUserIsIncorrect()
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

            var postService = new PostsService(dbContext, mapper, usersService, categoriesService);

            var postModel = new PostAdminCreateViewModel
            {
                Title = PostTitle,
                Description = PostEditDescription,
                AuthorId = UserId,
            };

            var exception = await Assert.ThrowsAsync<ArgumentNullException>(async () => await postService.CreatePostAsync(postModel));

            Assert.IsType<ArgumentNullException>(exception);
        }

        [Fact]
        public async Task CreatePostAsyncShouldThrowExceptionIfCategoryIsIncorrect()
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

            var postService = new PostsService(dbContext, mapper, usersService, categoriesService);

            var user = new ApplicationUser
            {
                FirstName = UserFirstName,
                LastName = UserLastName,
            };

            await dbContext.Users.AddAsync(user);

            await dbContext.SaveChangesAsync();

            var postModel = new PostAdminCreateViewModel
            {
                Title = PostTitle,
                Description = PostEditDescription,
                AuthorId = user.Id,
                CategoryId = CategoryId,
            };

            var exception = await Assert.ThrowsAsync<ArgumentNullException>(async () => await postService.CreatePostAsync(postModel));

            Assert.IsType<ArgumentNullException>(exception);
        }

        [Fact]
        public async Task CreatePostAsyncShouldCreatePostSuccessfully()
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

            var postService = new PostsService(dbContext, mapper, usersService, categoriesService);

            var user = new ApplicationUser
            {
                FirstName = UserFirstName,
                LastName = UserLastName,
            };

            await dbContext.Users.AddAsync(user);

            await dbContext.SaveChangesAsync();

            var category = new BlogCategory
            {
                Name = CategoryName,
            };

            await dbContext.BlogCategories.AddAsync(category);

            await dbContext.SaveChangesAsync();

            var postModel = new PostAdminCreateViewModel
            {
                Title = PostTitle,
                Description = PostEditDescription,
                AuthorId = user.Id,
                CategoryId = category.Id,
            };

            await postService.CreatePostAsync(postModel);

            var actual = await dbContext.Post.FirstOrDefaultAsync(p => p.Title == postModel.Title);

            Assert.Equal(postModel.Title, actual.Title);
        }
    }
}
