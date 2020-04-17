namespace MyCalisthenicApp.Services.Tests
{
    using AutoMapper;
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;
    using MyCalisthenicApp.Data;
    using MyCalisthenicApp.Mapping.MappingConfiguration;
    using MyCalisthenicApp.Models;
    using MyCalisthenicApp.Models.BlogEntities;
    using MyCalisthenicApp.Models.ShopEntities;
    using MyCalisthenicApp.ViewModels.Comments;
    using System;
    using System.Threading.Tasks;
    using Xunit;

    public class CommentsServiceTests
    {
        private const string UserId = "123456";
        private const string ProgramId = "123";
        private const string ProgramTitle = "Program title";
        private const string ProgramDescription = "Program description";
        private const string PostTitle = "Post title";
        private const string PostDescription = "Post description";
        private const string PostId = "123";
        private const string ProductId = "123";
        private const string ProductName = "Product name";
        private const decimal ProductPrice = 12.50M;
        private const string ProductDescription = "ProductDescription";
        private const string CategoryDescription = "Description";
        private const string CategoryName = "Name";
        private const string CommentText = "Comment text";
        private const int CommentRating = 12;
        private const string CommentId = "11";
        private const string UserFirstName = "Ivan";
        private const string UserLastName = "Ivanov";
        private const string UserEmail = "user@abv.bg";
        private const string UserUserName = "Username";


        [Fact]
        public async Task CreateCommentAsyncShouldThrowExceptionIfUserIsNull()
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

            var commentsService = new CommentsService(dbContext, mapper, usersService);

            var commentModel = new CommentInputViewModel
            {
                Text = CommentText,
            };

            var exception = await Assert.ThrowsAsync<NullReferenceException>(async () => await commentsService.CreateCommentAsync(PostId, commentModel));

            Assert.IsType<NullReferenceException>(exception);
        }




        //TODO Logg user manualy and check comment creation for post, program and product




        [Fact]
        public async Task GetCommentsByProgramIdAsyncShouldReturnCommentsSuccessfully()
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

            var commentsService = new CommentsService(dbContext, mapper, usersService);

            var programCategory = new ProgramCategory
            {
                Name = CategoryName,
                Description = CategoryDescription,
            };

            await dbContext.ProgramCategories.AddAsync(programCategory);

            await dbContext.SaveChangesAsync();

            var program = new Program
            {
                Title = ProgramTitle,
                Description = ProgramDescription,
                CategoryId = programCategory.Id,
            };

            await dbContext.Programs.AddAsync(program);

            await dbContext.SaveChangesAsync();

            var user = new ApplicationUser
            {
                FirstName = UserFirstName,
                LastName = UserLastName,
            };

            await dbContext.Users.AddAsync(user);

            await dbContext.SaveChangesAsync();

            var comment = new Comment
            {
                Text = CommentText,
                AuthorId = user.Id,
                ProgramId = program.Id,
            };

            await dbContext.Comments.AddAsync(comment);

            await dbContext.SaveChangesAsync();

            var expected = await commentsService.GetCommentsByProgramIdAsync(program.Id);

            var counter = 0;

            foreach (var comm in expected)
            {
                counter++;
            }

            Assert.Equal(1, counter);
        }

        [Fact]
        public async Task GetCommentsByProgramIdAsyncShouldThrowExceptionIfNoSuchProgramId()
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

            var commentsService = new CommentsService(dbContext, mapper, usersService);

            var expected = await commentsService.GetCommentsByProgramIdAsync(ProgramId);

            var counter = 0;

            foreach (var comment in expected)
            {
                counter++;
            }

            Assert.Equal(0, counter);
        }

        [Fact]
        public async Task GetCommentsByPostIdAsyncShouldReturnCommentsSuccessfully()
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

            var commentsService = new CommentsService(dbContext, mapper, usersService);

            var postCategory = new BlogCategory
            {
                Name = CategoryName,
            };

            await dbContext.BlogCategories.AddAsync(postCategory);

            await dbContext.SaveChangesAsync();

            var post = new Post
            {
                Title = PostTitle,
                Description = PostDescription,
                CategoryId = postCategory.Id,
            };

            await dbContext.Post.AddAsync(post);

            await dbContext.SaveChangesAsync();

            var user = new ApplicationUser
            {
                FirstName = UserFirstName,
                LastName = UserLastName,
            };

            await dbContext.Users.AddAsync(user);

            await dbContext.SaveChangesAsync();

            var comment = new Comment
            {
                Text = CommentText,
                AuthorId = user.Id,
                PostId = post.Id,
            };

            await dbContext.Comments.AddAsync(comment);

            await dbContext.SaveChangesAsync();

            var expected = await commentsService.GetCommentsByPostIdAsync(post.Id);

            var counter = 0;

            foreach (var comm in expected)
            {
                counter++;
            }

            Assert.Equal(1, counter);
        }

        [Fact]
        public async Task GetCommentsByPostIdAsyncShouldThrowExceptionIfNoSuchPostId()
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

            var commentsService = new CommentsService(dbContext, mapper, usersService);

            var expected = await commentsService.GetCommentsByPostIdAsync(PostId);

            var counter = 0;

            foreach (var comment in expected)
            {
                counter++;
            }

            Assert.Equal(0, counter);
        }

        [Fact]
        public async Task GetCommentsByProductIdAsyncShouldReturnCommentsSuccessfully()
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

            var commentsService = new CommentsService(dbContext, mapper, usersService);

            var productCategory = new ProductCategory
            {
                Name = CategoryName,
            };

            await dbContext.ProductCategories.AddAsync(productCategory);

            await dbContext.SaveChangesAsync();

            var product = new Product
            {
                Name = ProductName,
                Price = ProductPrice,
                Description = ProductDescription,
                CategoryId = productCategory.Id,
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

            var comment = new Comment
            {
                Text = CommentText,
                AuthorId = user.Id,
                ProductId = product.Id,
            };

            await dbContext.Comments.AddAsync(comment);

            await dbContext.SaveChangesAsync();

            var expected = await commentsService.GetCommentsByProductIdAsync(product.Id);

            var counter = 0;

            foreach (var comm in expected)
            {
                counter++;
            }

            Assert.Equal(1, counter);
        }

        [Fact]
        public async Task GetCommentsByProductIdAsyncShouldThrowExceptionIfNoSuchProductId()
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

            var commentsService = new CommentsService(dbContext, mapper, usersService);

            var expected = await commentsService.GetCommentsByProductIdAsync(ProductId);

            var counter = 0;

            foreach (var comment in expected)
            {
                counter++;
            }

            Assert.Equal(0, counter);
        }

        [Fact]
        public async Task AddRatingAsyncShouldThrowExceptionIfCommentIsNull()
        {
            var options = new DbContextOptionsBuilder<MyCalisthenicAppDbContext>()
                   .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                   .Options;

            var dbContext = new MyCalisthenicAppDbContext(options);

            IHttpContextAccessor httpContextAccessor = new HttpContextAccessor();

            var usersService = new UsersService(httpContextAccessor, dbContext, null);

            var commentsService = new CommentsService(dbContext, null, usersService);

            var exception = await Assert.ThrowsAsync<ArgumentNullException>(async () => await commentsService.AddRatingAsync(CommentId));

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

            var commentsService = new CommentsService(dbContext, null, usersService);

            var comment = new Comment
            {
                Id = CommentId,
                Text = CommentText,
            };

            await dbContext.Comments.AddAsync(comment);

            await dbContext.SaveChangesAsync();

            var exception = await Assert.ThrowsAsync<NullReferenceException>(async () => await commentsService.AddRatingAsync(comment.Id));

            Assert.IsType<NullReferenceException>(exception);
        }




        //TODO User logg and check other cases




        [Fact]
        public async Task GetAllLikesByCommentIdAsyncShouldThrowExceptionIfCommentIsNull()
        {
            var options = new DbContextOptionsBuilder<MyCalisthenicAppDbContext>()
                  .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                  .Options;

            var dbContext = new MyCalisthenicAppDbContext(options);

            IHttpContextAccessor httpContextAccessor = new HttpContextAccessor();

            var usersService = new UsersService(httpContextAccessor, dbContext, null);

            var commentsService = new CommentsService(dbContext, null, usersService);

            var exception = await Assert.ThrowsAsync<ArgumentNullException>(async () => await commentsService.GetAllLikesByCommentIdAsync(CommentId));

            Assert.IsType<ArgumentNullException>(exception);
        }

        [Fact]
        public async Task GetAllLikesByCommentIdAsyncShouldReturnLikesSuccessfully()
        {
            var options = new DbContextOptionsBuilder<MyCalisthenicAppDbContext>()
                  .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                  .Options;

            var dbContext = new MyCalisthenicAppDbContext(options);

            IHttpContextAccessor httpContextAccessor = new HttpContextAccessor();

            var usersService = new UsersService(httpContextAccessor, dbContext, null);

            var commentsService = new CommentsService(dbContext, null, usersService);

            var user = new ApplicationUser
            {
                FirstName = UserFirstName,
                LastName = UserLastName,
            };

            await dbContext.Users.AddAsync(user);

            await dbContext.SaveChangesAsync();

            var comment = new Comment
            {
                Text = CommentText,
                AuthorId = user.Id,
            };

            await dbContext.Comments.AddAsync(comment);

            await dbContext.SaveChangesAsync();

            var like = UserFirstName + user.Id;

            for (int i = 0; i < 4; i++)
            {
                comment.LikesUsersNames.Add(like);
            }

            dbContext.Update(comment);

            await dbContext.SaveChangesAsync();

            var likes = await commentsService.GetAllLikesByCommentIdAsync(comment.Id);

            Assert.Equal(4, likes.Count);
        }

        [Fact]
        public async Task GetCommentByIdAsyncShouldThrowExceptionIfCommentIsNull()
        {
            var options = new DbContextOptionsBuilder<MyCalisthenicAppDbContext>()
                  .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                  .Options;

            var dbContext = new MyCalisthenicAppDbContext(options);

            IHttpContextAccessor httpContextAccessor = new HttpContextAccessor();

            var usersService = new UsersService(httpContextAccessor, dbContext, null);

            var commentsService = new CommentsService(dbContext, null, usersService);

            var exception = await Assert.ThrowsAsync<ArgumentNullException>(async () => await commentsService.GetCommentByIdAsync(CommentId));

            Assert.IsType<ArgumentNullException>(exception);
        }

        [Fact]
        public async Task GetCommentByIdAsyncShouldReturnCommentSuccessfully()
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

            var commentsService = new CommentsService(dbContext, mapper, usersService);

            var user = new ApplicationUser
            {
                FirstName = UserFirstName,
                LastName = UserLastName,
            };

            await dbContext.Users.AddAsync(user);

            await dbContext.SaveChangesAsync();

            var comment = new Comment
            {
                Text = CommentText,
                AuthorId = user.Id,
            };

            await dbContext.Comments.AddAsync(comment);

            await dbContext.SaveChangesAsync();

            var expected = await commentsService.GetCommentByIdAsync(comment.Id);

            Assert.Equal(expected.Id, comment.Id);
        }

        [Fact]
        public async Task GetCommentByIdAsyncShouldThrowExeptionIfCommentIsNull()
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

            var commentsService = new CommentsService(dbContext, mapper, usersService);

            var exception = await Assert.ThrowsAsync<ArgumentNullException>(async () => await commentsService.GetCommentByIdAsync(CommentId));

            Assert.IsType<ArgumentNullException>(exception);
        }

        [Fact]
        public async Task EditCommentAsyncShouldThrowExceptionIfInvalidPostId()
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

            var commentsService = new CommentsService(dbContext, mapper, usersService);

            var user = new ApplicationUser
            {
                FirstName = UserFirstName,
                LastName = UserLastName,
            };

            await dbContext.Users.AddAsync(user);

            await dbContext.SaveChangesAsync();

            var commentModel = new CommentAdminEditViewModel
            {
                Text = CommentText,
                AuthorId = user.Id,
                PostId = PostId,
            };

            var exception = await Assert.ThrowsAsync<ArgumentNullException>(async () => await commentsService.EditCommentAsync(commentModel));

            Assert.IsType<ArgumentNullException>(exception);
        }

        [Fact]
        public async Task EditCommentAsyncShouldThrowExceptionIfInvalidProductId()
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

            var commentsService = new CommentsService(dbContext, mapper, usersService);

            var user = new ApplicationUser
            {
                FirstName = UserFirstName,
                LastName = UserLastName,
            };

            await dbContext.Users.AddAsync(user);

            await dbContext.SaveChangesAsync();

            var commentModel = new CommentAdminEditViewModel
            {
                Text = CommentText,
                AuthorId = user.Id,
                ProductId = ProductId,
            };

            var exception = await Assert.ThrowsAsync<ArgumentNullException>(async () => await commentsService.EditCommentAsync(commentModel));

            Assert.IsType<ArgumentNullException>(exception);
        }

        [Fact]
        public async Task EditCommentAsyncShouldThrowExceptionIfInvalidProgramId()
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

            var commentsService = new CommentsService(dbContext, mapper, usersService);

            var user = new ApplicationUser
            {
                FirstName = UserFirstName,
                LastName = UserLastName,
            };

            await dbContext.Users.AddAsync(user);

            await dbContext.SaveChangesAsync();

            var commentModel = new CommentAdminEditViewModel
            {
                Text = CommentText,
                AuthorId = user.Id,
                ProgramId = ProgramId,
            };

            var exception = await Assert.ThrowsAsync<ArgumentNullException>(async () => await commentsService.EditCommentAsync(commentModel));

            Assert.IsType<ArgumentNullException>(exception);
        }

        [Fact]
        public async Task EditCommentAsyncShouldThrowExceptionIfCommentIsNull()
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

            var commentsService = new CommentsService(dbContext, mapper, usersService);

            var user = new ApplicationUser
            {
                FirstName = UserFirstName,
                LastName = UserLastName,
            };

            await dbContext.Users.AddAsync(user);

            await dbContext.SaveChangesAsync();

            var commentModel = new CommentAdminEditViewModel
            {
                Text = CommentText,
                AuthorId = user.Id,
            };

            var exception = await Assert.ThrowsAsync<ArgumentNullException>(async () => await commentsService.EditCommentAsync(commentModel));

            Assert.IsType<ArgumentNullException>(exception);
        }

        [Fact]
        public async Task EditCommentAsyncShouldEditCommentSuccessfully()
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

            var commentsService = new CommentsService(dbContext, mapper, usersService);

            var user = new ApplicationUser
            {
                FirstName = UserFirstName,
                LastName = UserLastName,
            };

            await dbContext.Users.AddAsync(user);

            await dbContext.SaveChangesAsync();

            var comment = new Comment
            {
                Id = CommentId,
                Text = CommentText,
                AuthorId = user.Id,
            };

            await dbContext.Comments.AddAsync(comment);

            await dbContext.SaveChangesAsync();

            var commentModel = new CommentAdminEditViewModel
            {
                Id = CommentId,
                Text = CommentText,
                AuthorId = user.Id,
                Rating = CommentRating,
            };

            await commentsService.EditCommentAsync(commentModel);

            Assert.Equal(comment.Rating, commentModel.Rating);
        }
    }
}
