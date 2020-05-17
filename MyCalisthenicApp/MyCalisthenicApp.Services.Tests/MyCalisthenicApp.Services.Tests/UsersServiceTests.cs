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
    using MyCalisthenicApp.ViewModels.Coupons;
    using MyCalisthenicApp.ViewModels.Users;
    using System;
    using System.Threading.Tasks;
    using Xunit;

    public class UsersServiceTests
    {
        private const string CouponText = "Coupon text";
        private const string UserId = "86867";
        private const string UserFirstName = "Ivan";
        private const string UserLastName = "Ivanov";
        private const string UserEmail = "user@gmail.com";
        private const string CommentText = "Comment text";
        private const string PostCategoryName = "Post category name";
        private const string ProductCategoryName = "Product category name";
        private const string ProgramCategoryName = "Program category name";
        private const string ProgramTitle = "Program title";
        private const string ProgramDescription = "Program description";
        private const string PostTitle = "Post title";
        private const string PostDescription = "Post description";
        private const string ProductName = "Product name";
        private const string ProductDescription = "Product description";
        private const string AddressCountry = "Address country";
        private const string AddressStreet = "Address street";
        private const string CityPostCode = "5757";
        private const string CityName = "Sofia";
        private const string OrderId = "94865";
        private const string UserRequestFullName = "Ivan Ivanov";
        private const string UserRequestEmail = "user_90@abv.bg";
        private const string UserRequestContent = "Request content";
        private const string AdministratorFirstName = "Svetoslav";
        private const string AdministratorLastName = "Kazakov";
        private const string AdministratorEmail = "svetoslav.kazakov@outlook.com";

        [Fact]
        public async Task AddDiscountToUserAsyncShouldThrowExceptionIfUserIsNull()
        {
            var options = new DbContextOptionsBuilder<MyCalisthenicAppDbContext>()
                 .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                 .Options;

            var dbContext = new MyCalisthenicAppDbContext(options);

            IHttpContextAccessor httpContextAccessor = new HttpContextAccessor();

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MyCalisthenicAppProfile());
            });

            var mapper = mockMapper.CreateMapper();

            var usersService = new UsersService(httpContextAccessor, dbContext, mapper);

            var coupon = new CouponViewModel
            {
                Coupon = CouponText,
            };

            var exception = await Assert.ThrowsAsync<NullReferenceException>(async () => await usersService.AddDiscountToUserAsync(coupon));

            Assert.IsType<NullReferenceException>(exception);
        }

        [Fact]
        public async Task GetLoggedUserByIdAsyncShouldReturnUserSuccessfully()
        {
            var options = new DbContextOptionsBuilder<MyCalisthenicAppDbContext>()
                 .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                 .Options;

            var dbContext = new MyCalisthenicAppDbContext(options);

            IHttpContextAccessor httpContextAccessor = new HttpContextAccessor();

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MyCalisthenicAppProfile());
            });

            var mapper = mockMapper.CreateMapper();

            var usersService = new UsersService(httpContextAccessor, dbContext, mapper);

            var user = new ApplicationUser
            {
                FirstName = UserFirstName,
                LastName = UserLastName,
            };

            await dbContext.Users.AddAsync(user);

            await dbContext.SaveChangesAsync();

            var expected = await usersService.GetLoggedUserByIdAsync(user.Id);

            Assert.Equal(expected.Id, user.Id);
        }

        [Fact]
        public async Task GetAllUsersAsyncShouldReturnUsersSuccessfully()
        {
            var options = new DbContextOptionsBuilder<MyCalisthenicAppDbContext>()
                 .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                 .Options;

            var dbContext = new MyCalisthenicAppDbContext(options);

            IHttpContextAccessor httpContextAccessor = new HttpContextAccessor();

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MyCalisthenicAppProfile());
            });

            var mapper = mockMapper.CreateMapper();

            var usersService = new UsersService(httpContextAccessor, dbContext, mapper);

            for (int i = 0; i < 3; i++)
            {
                var user = new ApplicationUser
                {
                    FirstName = UserFirstName,
                    LastName = UserLastName,
                };

                await dbContext.Users.AddAsync(user);

                await dbContext.SaveChangesAsync();
            }

            var expected = await usersService.GetAllUsersAsync();

            Assert.Equal(3, expected.Count);
        }

        [Fact]
        public async Task GetBannedUsersAsyncShouldReturnBannedUsersSuccessfully()
        {
            var options = new DbContextOptionsBuilder<MyCalisthenicAppDbContext>()
                 .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                 .Options;

            var dbContext = new MyCalisthenicAppDbContext(options);

            IHttpContextAccessor httpContextAccessor = new HttpContextAccessor();

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MyCalisthenicAppProfile());
            });

            var mapper = mockMapper.CreateMapper();

            var usersService = new UsersService(httpContextAccessor, dbContext, mapper);

            for (int i = 0; i < 3; i++)
            {
                var user = new ApplicationUser
                {
                    FirstName = UserFirstName,
                    LastName = UserLastName,
                    IsDeleted = true,
                };

                await dbContext.Users.AddAsync(user);

                await dbContext.SaveChangesAsync();
            }

            var notBannedUser = new ApplicationUser
            {
                FirstName = UserFirstName,
                LastName = UserLastName,
            };

            await dbContext.Users.AddAsync(notBannedUser);

            await dbContext.SaveChangesAsync();

            var expected = await usersService.GetBannedUsersAsync();

            Assert.Equal(3, expected.Count);
        }

        [Fact]
        public async Task GetBannedUserAsyncShouldReturnBannedUserSuccessfully()
        {
            var options = new DbContextOptionsBuilder<MyCalisthenicAppDbContext>()
                 .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                 .Options;

            var dbContext = new MyCalisthenicAppDbContext(options);

            IHttpContextAccessor httpContextAccessor = new HttpContextAccessor();

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MyCalisthenicAppProfile());
            });

            var mapper = mockMapper.CreateMapper();

            var usersService = new UsersService(httpContextAccessor, dbContext, mapper);

            for (int i = 0; i < 3; i++)
            {
                var user = new ApplicationUser
                {
                    FirstName = UserFirstName,
                    LastName = UserLastName,
                };

                await dbContext.Users.AddAsync(user);

                await dbContext.SaveChangesAsync();
            }

            var bannedUser = new ApplicationUser
            {
                FirstName = UserFirstName,
                LastName = UserLastName,
                Email = UserEmail,
                IsDeleted = true,
            };

            await dbContext.Users.AddAsync(bannedUser);

            await dbContext.SaveChangesAsync();

            var expected = await usersService.GetBannedUserAsync(UserEmail);

            Assert.Equal(expected.Id, bannedUser.Id);
        }

        [Fact]
        public async Task BlockUnblockUserByIdAsyncShouldThrowExceptionIfUserIsNull()
        {
            var options = new DbContextOptionsBuilder<MyCalisthenicAppDbContext>()
                 .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                 .Options;

            var dbContext = new MyCalisthenicAppDbContext(options);

            IHttpContextAccessor httpContextAccessor = new HttpContextAccessor();

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MyCalisthenicAppProfile());
            });

            var mapper = mockMapper.CreateMapper();

            var usersService = new UsersService(httpContextAccessor, dbContext, mapper);

            var exception = await Assert.ThrowsAsync<NullReferenceException>(async () => await usersService.BlockUnblockUserByIdAsync(UserId));

            Assert.IsType<NullReferenceException>(exception);
        }

        [Fact]
        public async Task BlockUnblockUserByIdAsyncShouldDeleteUserSuccessfully()
        {
            var options = new DbContextOptionsBuilder<MyCalisthenicAppDbContext>()
                 .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                 .Options;

            var dbContext = new MyCalisthenicAppDbContext(options);

            IHttpContextAccessor httpContextAccessor = new HttpContextAccessor();

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MyCalisthenicAppProfile());
            });

            var mapper = mockMapper.CreateMapper();

            var usersService = new UsersService(httpContextAccessor, dbContext, mapper);

            for (int i = 0; i < 3; i++)
            {
                var user = new ApplicationUser
                {
                    FirstName = UserFirstName,
                    LastName = UserLastName,
                };

                await dbContext.Users.AddAsync(user);

                await dbContext.SaveChangesAsync();
            }

            var userToDelete = new ApplicationUser
            {
                Id = UserId,
                FirstName = UserFirstName,
                LastName = UserLastName,
            };

            await dbContext.Users.AddAsync(userToDelete);

            await dbContext.SaveChangesAsync();

            var expected = await usersService.BlockUnblockUserByIdAsync(UserId);

            Assert.True(expected.IsDeleted);
        }

        [Fact]
        public async Task BlockUnblockUserByIdAsyncShouldUnBlockUserSuccessfully()
        {
            var options = new DbContextOptionsBuilder<MyCalisthenicAppDbContext>()
                 .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                 .Options;

            var dbContext = new MyCalisthenicAppDbContext(options);

            IHttpContextAccessor httpContextAccessor = new HttpContextAccessor();

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MyCalisthenicAppProfile());
            });

            var mapper = mockMapper.CreateMapper();

            var usersService = new UsersService(httpContextAccessor, dbContext, mapper);

            for (int i = 0; i < 3; i++)
            {
                var user = new ApplicationUser
                {
                    FirstName = UserFirstName,
                    LastName = UserLastName,
                };

                await dbContext.Users.AddAsync(user);

                await dbContext.SaveChangesAsync();
            }

            var userToDelete = new ApplicationUser
            {
                Id = UserId,
                FirstName = UserFirstName,
                LastName = UserLastName,
                IsDeleted = true,
            };

            await dbContext.Users.AddAsync(userToDelete);

            await dbContext.SaveChangesAsync();

            var expected = await usersService.BlockUnblockUserByIdAsync(UserId);

            Assert.False(expected.IsDeleted);
        }

        [Fact]
        public async Task GetUserToBlockAsyncShouldThrowExceptionIfUserIsNull()
        {
            var options = new DbContextOptionsBuilder<MyCalisthenicAppDbContext>()
                 .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                 .Options;

            var dbContext = new MyCalisthenicAppDbContext(options);

            IHttpContextAccessor httpContextAccessor = new HttpContextAccessor();

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MyCalisthenicAppProfile());
            });

            var mapper = mockMapper.CreateMapper();

            var usersService = new UsersService(httpContextAccessor, dbContext, mapper);

            var exception = await Assert.ThrowsAsync<NullReferenceException>(async () => await usersService.GetUserToBlockAsync(UserId));

            Assert.IsType<NullReferenceException>(exception);
        }

        [Fact]
        public async Task GetUserToBlockAsyncShouldBlockUserSuccessfully()
        {
            var options = new DbContextOptionsBuilder<MyCalisthenicAppDbContext>()
                 .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                 .Options;

            var dbContext = new MyCalisthenicAppDbContext(options);

            IHttpContextAccessor httpContextAccessor = new HttpContextAccessor();

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MyCalisthenicAppProfile());
            });

            var mapper = mockMapper.CreateMapper();

            var usersService = new UsersService(httpContextAccessor, dbContext, mapper);

            for (int i = 0; i < 3; i++)
            {
                var user = new ApplicationUser
                {
                    FirstName = UserFirstName,
                    LastName = UserLastName,
                };

                await dbContext.Users.AddAsync(user);

                await dbContext.SaveChangesAsync();
            }

            var userToBlock = new ApplicationUser
            {
                Id = UserId,
                FirstName = UserFirstName,
                LastName = UserLastName,
            };

            await dbContext.Users.AddAsync(userToBlock);

            await dbContext.SaveChangesAsync();

            await usersService.GetUserToBlockAsync(UserId);

            var actual = await dbContext.Users.FirstOrDefaultAsync(u => u.Id == userToBlock.Id);

            Assert.True(actual.IsDeleted);
        }

        [Fact]
        public async Task GetUserByEmailAsyncShouldReturnUserSuccessfully()
        {
            var options = new DbContextOptionsBuilder<MyCalisthenicAppDbContext>()
                 .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                 .Options;

            var dbContext = new MyCalisthenicAppDbContext(options);

            IHttpContextAccessor httpContextAccessor = new HttpContextAccessor();

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MyCalisthenicAppProfile());
            });

            var mapper = mockMapper.CreateMapper();

            var usersService = new UsersService(httpContextAccessor, dbContext, mapper);

            for (int i = 0; i < 3; i++)
            {
                var user = new ApplicationUser
                {
                    FirstName = UserFirstName,
                    LastName = UserLastName,
                };

                await dbContext.Users.AddAsync(user);

                await dbContext.SaveChangesAsync();
            }

            var userToReturn = new ApplicationUser
            {
                FirstName = UserFirstName,
                LastName = UserLastName,
                Email = UserEmail,
            };

            await dbContext.Users.AddAsync(userToReturn);

            await dbContext.SaveChangesAsync();

            var expected = await usersService.GetUserByEmailAsync(UserEmail);

            Assert.Equal(expected.Email, userToReturn.Email);
        }

        [Fact]
        public async Task GetAllCommentsByUserIdAsyncShouldReturnCommentsSuccessfully()
        {
            var options = new DbContextOptionsBuilder<MyCalisthenicAppDbContext>()
                 .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                 .Options;

            var dbContext = new MyCalisthenicAppDbContext(options);

            IHttpContextAccessor httpContextAccessor = new HttpContextAccessor();

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MyCalisthenicAppProfile());
            });

            var mapper = mockMapper.CreateMapper();

            var usersService = new UsersService(httpContextAccessor, dbContext, mapper);

            var postCategory = new BlogCategory
            {
                Name = PostCategoryName,
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

            var productCategory = new ProductCategory
            {
                Name = ProductCategoryName,
            };

            await dbContext.ProductCategories.AddAsync(productCategory);

            await dbContext.SaveChangesAsync();

            var product = new Product
            {
                Name = ProductName,
                Description = ProductDescription,
                CategoryId = productCategory.Id,
            };

            await dbContext.Products.AddAsync(product);

            await dbContext.SaveChangesAsync();

            var programCategory = new ProgramCategory
            {
                Name = ProgramCategoryName,
                Description = ProgramDescription,
            };

            await dbContext.ProgramCategories.AddAsync(programCategory);

            await dbContext.SaveChangesAsync();

            var program = new Program
            {
                Title = ProgramTitle,
                Description = ProgramDescription,
                CategoryId = productCategory.Id,
            };

            await dbContext.Programs.AddAsync(program);

            await dbContext.SaveChangesAsync();

            var user = new ApplicationUser
            {
                Id = UserId,
                FirstName = UserFirstName,
                LastName = UserLastName,
            };

            await dbContext.Users.AddAsync(user);

            await dbContext.SaveChangesAsync();

            for (int i = 0; i < 3; i++)
            {
                var comment = new Comment
                {
                    Text = CommentText,
                    Author = user,
                    Post = post,
                    Product = product,
                    Program = program,
                };

                await dbContext.Comments.AddAsync(comment);

                await dbContext.SaveChangesAsync();
            }

            var expected = await usersService.GetAllCommentsByUserIdAsync(UserId);

            Assert.Equal(3, expected.Count);
        }

        [Fact]
        public async Task GetAllOrdersByUserIdAsyncShouldReturnOrdersSuccessfully()
        {
            var options = new DbContextOptionsBuilder<MyCalisthenicAppDbContext>()
                 .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                 .Options;

            var dbContext = new MyCalisthenicAppDbContext(options);

            IHttpContextAccessor httpContextAccessor = new HttpContextAccessor();

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MyCalisthenicAppProfile());
            });

            var mapper = mockMapper.CreateMapper();

            var usersService = new UsersService(httpContextAccessor, dbContext, mapper);

            var user = new ApplicationUser
            {
                Id = UserId,
                FirstName = UserFirstName,
                LastName = UserLastName,
            };

            await dbContext.Users.AddAsync(user);

            await dbContext.SaveChangesAsync();

            for (int i = 0; i < 3; i++)
            {
                var order = new Order
                {
                    UserId = user.Id,
                };

                await dbContext.Orders.AddAsync(order);

                await dbContext.SaveChangesAsync();
            }

            var expected = await usersService.GetAllOrdersByUserIdAsync(UserId);

            Assert.Equal(3, expected.Count);
        }

        [Fact]
        public async Task GetAllOrdersAsyncShouldReturnOrdersSuccessfully()
        {
            var options = new DbContextOptionsBuilder<MyCalisthenicAppDbContext>()
                 .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                 .Options;

            var dbContext = new MyCalisthenicAppDbContext(options);

            IHttpContextAccessor httpContextAccessor = new HttpContextAccessor();

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MyCalisthenicAppProfile());
            });

            var mapper = mockMapper.CreateMapper();

            var usersService = new UsersService(httpContextAccessor, dbContext, mapper);

            var user = new ApplicationUser
            {
                FirstName = UserFirstName,
                LastName = UserLastName,
            };

            await dbContext.Users.AddAsync(user);

            await dbContext.SaveChangesAsync();

            for (int i = 0; i < 3; i++)
            {
                var order = new Order
                {
                    UserId = user.Id,
                };

                await dbContext.Orders.AddAsync(order);

                await dbContext.SaveChangesAsync();
            }

            var expected = await usersService.GetAllOrdersAsync();

            Assert.Equal(3, expected.Count);
        }

        [Fact]
        public async Task GetAllAddressesByUserIdAsyncShouldReturnAddressesSuccessfully()
        {
            var options = new DbContextOptionsBuilder<MyCalisthenicAppDbContext>()
                 .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                 .Options;

            var dbContext = new MyCalisthenicAppDbContext(options);

            IHttpContextAccessor httpContextAccessor = new HttpContextAccessor();

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MyCalisthenicAppProfile());
            });

            var mapper = mockMapper.CreateMapper();

            var usersService = new UsersService(httpContextAccessor, dbContext, mapper);

            var user = new ApplicationUser
            {
                Id = UserId,
                FirstName = UserFirstName,
                LastName = UserLastName,
            };

            await dbContext.Users.AddAsync(user);

            await dbContext.SaveChangesAsync();

            var city = new City
            {
                Name = CityName,
                PostCode = CityPostCode,
            };

            await dbContext.Cities.AddAsync(city);

            await dbContext.SaveChangesAsync();

            for (int i = 0; i < 3; i++)
            {
                var address = new Address
                {
                    Country = AddressCountry,
                    Street = AddressStreet,
                    CityId = city.Id,
                    UserId = user.Id,
                };

                await dbContext.Addresses.AddAsync(address);

                await dbContext.SaveChangesAsync();
            }

            var expected = await usersService.GetAllAddressesByUserIdAsync(UserId);

            Assert.Equal(3, expected.Count);
        }

        [Fact]
        public async Task GetAllProductsByOrderIdAsyncShouldReturnProductsSuccessfully()
        {
            var options = new DbContextOptionsBuilder<MyCalisthenicAppDbContext>()
                 .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                 .Options;

            var dbContext = new MyCalisthenicAppDbContext(options);

            IHttpContextAccessor httpContextAccessor = new HttpContextAccessor();

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MyCalisthenicAppProfile());
            });

            var mapper = mockMapper.CreateMapper();

            var usersService = new UsersService(httpContextAccessor, dbContext, mapper);

            var user = new ApplicationUser
            {
                FirstName = UserFirstName,
                LastName = UserLastName,
            };

            await dbContext.Users.AddAsync(user);

            await dbContext.SaveChangesAsync();

            var order = new Order
            {
                Id = OrderId,
                UserId = user.Id,
            };

            await dbContext.Orders.AddAsync(order);

            await dbContext.SaveChangesAsync();

            var productCategory = new ProductCategory
            {
                Name = ProductCategoryName,
            };

            await dbContext.ProductCategories.AddAsync(productCategory);

            await dbContext.SaveChangesAsync();

            var product = new Product
            {
                Name = ProductName,
                Description = ProductDescription,
                CategoryId = productCategory.Id,
            };

            await dbContext.Products.AddAsync(product);

            await dbContext.SaveChangesAsync();

            var orderProduct = new OrderProduct
            {
                OrderId = order.Id,
                ProductId = product.Id,
                Product = product,
            };

            await dbContext.OrderProducts.AddAsync(orderProduct);

            await dbContext.SaveChangesAsync();

            var expected = await usersService.GetAllProductsByOrderIdAsync(OrderId);

            Assert.Equal(1, expected.Count);
        }

        [Fact]
        public async Task UserSubscribeAsyncShouldSubscribeUserSuccessfully()
        {
            var options = new DbContextOptionsBuilder<MyCalisthenicAppDbContext>()
                 .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                 .Options;

            var dbContext = new MyCalisthenicAppDbContext(options);

            IHttpContextAccessor httpContextAccessor = new HttpContextAccessor();

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MyCalisthenicAppProfile());
            });

            var mapper = mockMapper.CreateMapper();

            var usersService = new UsersService(httpContextAccessor, dbContext, mapper);

            var user = new ApplicationUser
            {
                FirstName = UserFirstName,
                LastName = UserLastName,
            };

            await dbContext.Users.AddAsync(user);

            await dbContext.SaveChangesAsync();

            await usersService.UserSubscribeAsync(user);

            var actual = await dbContext.Users.FirstOrDefaultAsync(u => u.Id == user.Id);

            Assert.True(actual.HasSubscribe);
        }

        [Fact]
        public async Task GetAllRequestsAsyncShouldReturnUserRequestsSuccessfully()
        {
            var options = new DbContextOptionsBuilder<MyCalisthenicAppDbContext>()
                 .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                 .Options;

            var dbContext = new MyCalisthenicAppDbContext(options);

            IHttpContextAccessor httpContextAccessor = new HttpContextAccessor();

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MyCalisthenicAppProfile());
            });

            var mapper = mockMapper.CreateMapper();

            var usersService = new UsersService(httpContextAccessor, dbContext, mapper);

            for (int i = 0; i < 3; i++)
            {
                var request = new UserRequest
                {
                    FullName = UserRequestFullName,
                    Content = UserRequestContent,
                    Email = UserRequestEmail,
                };

                await dbContext.UserRequests.AddAsync(request);

                await dbContext.SaveChangesAsync();
            }

            var expected = await usersService.GetAllRequestsAsync();

            Assert.Equal(3, expected.Count);
        }

        [Fact]
        public async Task GetUserToEditAsyncShouldThrowExceptionIfUserIsNull()
        {
            var options = new DbContextOptionsBuilder<MyCalisthenicAppDbContext>()
                 .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                 .Options;

            var dbContext = new MyCalisthenicAppDbContext(options);

            IHttpContextAccessor httpContextAccessor = new HttpContextAccessor();

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MyCalisthenicAppProfile());
            });

            var mapper = mockMapper.CreateMapper();

            var usersService = new UsersService(httpContextAccessor, dbContext, mapper);

            var exception = await Assert.ThrowsAsync<NullReferenceException>(async () => await usersService.GetUserToEditAsync(UserId));

            Assert.IsType<NullReferenceException>(exception);
        }

        [Fact]
        public async Task GetUserToEditAsyncShouldReturnUserSuccessfully()
        {
            var options = new DbContextOptionsBuilder<MyCalisthenicAppDbContext>()
                 .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                 .Options;

            var dbContext = new MyCalisthenicAppDbContext(options);

            IHttpContextAccessor httpContextAccessor = new HttpContextAccessor();

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MyCalisthenicAppProfile());
            });

            var mapper = mockMapper.CreateMapper();

            var usersService = new UsersService(httpContextAccessor, dbContext, mapper);

            var user = new ApplicationUser
            {
                Id = UserId,
                FirstName = UserFirstName,
                LastName = UserLastName,
            };

            await dbContext.Users.AddAsync(user);

            await dbContext.SaveChangesAsync();

            var expected = await usersService.GetUserToEditAsync(UserId);

            Assert.Equal(expected.Id, user.Id);
        }

        [Fact]
        public async Task EditUserAsyncShouldThrowExceptionIfUserIsNull()
        {
            var options = new DbContextOptionsBuilder<MyCalisthenicAppDbContext>()
                 .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                 .Options;

            var dbContext = new MyCalisthenicAppDbContext(options);

            IHttpContextAccessor httpContextAccessor = new HttpContextAccessor();

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MyCalisthenicAppProfile());
            });

            var mapper = mockMapper.CreateMapper();

            var usersService = new UsersService(httpContextAccessor, dbContext, mapper);

            var userModel = new UserAdminEditViewModel
            {
                Id = null,
            };

            var exception = await Assert.ThrowsAsync<NullReferenceException>(async () => await usersService.EditUserAsync(userModel));

            Assert.IsType<NullReferenceException>(exception);
        }

        [Fact]
        public async Task EditUserAsyncShouldReturnUserSuccessfully()
        {
            var options = new DbContextOptionsBuilder<MyCalisthenicAppDbContext>()
                 .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                 .Options;

            var dbContext = new MyCalisthenicAppDbContext(options);

            IHttpContextAccessor httpContextAccessor = new HttpContextAccessor();

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MyCalisthenicAppProfile());
            });

            var mapper = mockMapper.CreateMapper();

            var usersService = new UsersService(httpContextAccessor, dbContext, mapper);

            var user = new ApplicationUser
            {
                Id = UserId,
                FirstName = UserFirstName,
                LastName = UserLastName,
            };

            await dbContext.Users.AddAsync(user);

            await dbContext.SaveChangesAsync();

            var userModel = new UserAdminEditViewModel
            {
                Id = UserId,
                HasMembership = true,
            };

            await usersService.EditUserAsync(userModel);

            var actual = await dbContext.Users.FirstOrDefaultAsync(u => u.Id == UserId);

            Assert.True(actual.HasMembership);
        }

        [Fact]
        public async Task GetAdminIdAsyncShouldReturnAdminIdSuccessfully()
        {
            var options = new DbContextOptionsBuilder<MyCalisthenicAppDbContext>()
                 .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                 .Options;

            var dbContext = new MyCalisthenicAppDbContext(options);

            IHttpContextAccessor httpContextAccessor = new HttpContextAccessor();

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MyCalisthenicAppProfile());
            });

            var mapper = mockMapper.CreateMapper();

            var usersService = new UsersService(httpContextAccessor, dbContext, mapper);

            var user = new ApplicationUser
            {
                Id = UserId,
                FirstName = AdministratorFirstName,
                LastName = AdministratorLastName,
                Email = AdministratorEmail,
            };

            await dbContext.Users.AddAsync(user);

            await dbContext.SaveChangesAsync();

            var expected = await usersService.GetAdminIdAsync();

            Assert.Equal(expected, UserId);
        }

    }
}
