namespace MyCalisthenicApp.Services.Tests
{
    using AutoMapper;
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;
    using MyCalisthenicApp.Data;
    using MyCalisthenicApp.Mapping.MappingConfiguration;
    using MyCalisthenicApp.Models;
    using MyCalisthenicApp.Models.ShopEntities;
    using MyCalisthenicApp.ViewModels.Orders;
    using System;
    using System.Threading.Tasks;
    using Xunit;

    public class OrdersServiceTests
    {
        private decimal? MembershipPrice = 60.90M;
        private const string UserId = "1234";
        private const string UserFirstName = "Ivan";
        private const string UserLastName = "Ivanov";
        private const string ProductName = "Product name";
        private decimal ProductPrice = 12.49M;
        private const string ProductDescription = "Product description";
        private const string CategoryId = "12";
        private const string OrderId = "34554";
        private decimal OrderTotalPrice = 100.20M;
        private const string CityName = "City name";
        private const string CityPostCode = "City post code";
        private const string AddressCountry = "Address country";
        private const string AddressStreet = "Address street";

        [Fact]
        public async Task CreateMembershipToOrderAsyncShouldThrowExceptionIfUserIsNull()
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

            var ordersService = new OrdersService(dbContext, mapper, usersService);

            var exception = await Assert.ThrowsAsync<NullReferenceException>(async () => await ordersService.CreateMembershipToOrderAsync(MembershipPrice));

            Assert.IsType<NullReferenceException>(exception);
        }

        [Fact]
        public async Task CreateOrderAsyncShouldReturnFalseIfProductIsSoldOut()
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

            var ordersService = new OrdersService(dbContext, mapper, usersService);

            var product = new Product
            {
                Name = ProductName,
                Price = ProductPrice,
                Description = ProductDescription,
                IsSoldOut = true,
                CategoryId = CategoryId,
            };

            var expected = await ordersService.CreateOrderAsync(product);

            Assert.False(expected);
        }

        [Fact]
        public async Task CreateOrderAsyncShouldThrowExceptionIfUserIsNull()
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

            var ordersService = new OrdersService(dbContext, mapper, usersService);

            var product = new Product
            {
                Name = ProductName,
                Price = ProductPrice,
                Description = ProductDescription,
                CategoryId = CategoryId,
            };

            var exception = await Assert.ThrowsAsync<NullReferenceException>(async () => await ordersService.CreateOrderAsync(product));

            Assert.IsType<NullReferenceException>(exception);
        }


        [Fact]
        public async Task SendOrderAsyncShouldThrowExceptionIfUserIsNull()
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

            var ordersService = new OrdersService(dbContext, mapper, usersService);

            var exception = await Assert.ThrowsAsync<NullReferenceException>(async () => await ordersService.SendOrderAsync(OrderId));

            Assert.IsType<NullReferenceException>(exception);
        }


        [Fact]
        public async Task GetOrderByIdAsyncShouldThrowExceptionIfOrderIsNull()
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

            var ordersService = new OrdersService(dbContext, mapper, usersService);

            var exception = await Assert.ThrowsAsync<ArgumentNullException>(async () => await ordersService.GetOrderByIdAsync(OrderId));

            Assert.IsType<ArgumentNullException>(exception);
        }

        [Fact]
        public async Task GetOrderByIdAsyncShouldReturnOrderSuccessfully()
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

            var ordersService = new OrdersService(dbContext, mapper, usersService);

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

            var expected = await ordersService.GetOrderByIdAsync(order.Id);

            Assert.Equal(expected.Id, order.Id);
        }

        [Fact]
        public async Task EditOrderAsyncShouldThrowExceptionIfUserIdIsIncorrect()
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

            var ordersService = new OrdersService(dbContext, mapper, usersService);

            var user = new ApplicationUser
            {
                FirstName = UserFirstName,
                LastName = UserLastName,
            };

            await dbContext.Users.AddAsync(user);

            await dbContext.SaveChangesAsync();

            var orderModel = new OrderAdminEditViewModel
            {
                UserId = UserId,
            };

            var exception = await Assert.ThrowsAsync<ArgumentNullException>(async () => await ordersService.EditOrderAsync(orderModel));

            Assert.IsType<ArgumentNullException>(exception);
        }

        [Fact]
        public async Task EditOrderAsyncShouldThrowExceptionIfDeliveryAddressIdIsIncorrect()
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

            var ordersService = new OrdersService(dbContext, mapper, usersService);

            var user = new ApplicationUser
            {
                Id = UserId,
                FirstName = UserFirstName,
                LastName = UserLastName,
            };

            await dbContext.Users.AddAsync(user);

            await dbContext.SaveChangesAsync();

            var orderModel = new OrderAdminEditViewModel
            {
                UserId = user.Id,
            };

            var exception = await Assert.ThrowsAsync<ArgumentNullException>(async () => await ordersService.EditOrderAsync(orderModel));

            Assert.IsType<ArgumentNullException>(exception);
        }

        [Fact]
        public async Task EditOrderAsyncShouldThrowExceptionIfOrderIsNull()
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

            var ordersService = new OrdersService(dbContext, mapper, usersService);

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

            var address = new Address
            {
                Country = AddressCountry,
                Street = AddressStreet,
                CityId = city.Id,
            };

            await dbContext.Addresses.AddAsync(address);

            await dbContext.SaveChangesAsync();

            var orderModel = new OrderAdminEditViewModel
            {
                UserId = user.Id,
                DeliveryAddressId = address.Id,
            };

            var exception = await Assert.ThrowsAsync<ArgumentNullException>(async () => await ordersService.EditOrderAsync(orderModel));

            Assert.IsType<ArgumentNullException>(exception);
        }

        [Fact]
        public async Task EditOrderAsyncShouldEditOrderSuccessfully()
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

            var ordersService = new OrdersService(dbContext, mapper, usersService);

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

            var address = new Address
            {
                Country = AddressCountry,
                Street = AddressStreet,
                CityId = city.Id,
            };

            await dbContext.Addresses.AddAsync(address);

            await dbContext.SaveChangesAsync();

            var order = new Order
            {
                Id = OrderId,
                UserId = user.Id,
            };

            await dbContext.Orders.AddAsync(order);

            await dbContext.SaveChangesAsync();

            var orderModel = new OrderAdminEditViewModel
            {
                Id = order.Id,
                UserId = user.Id,
                DeliveryAddressId = address.Id,
                TotalPrice = OrderTotalPrice,
            };

            await ordersService.EditOrderAsync(orderModel);

            var actual = await dbContext.Orders.FirstOrDefaultAsync(o => o.Id == order.Id);

            Assert.Equal(order.TotalPrice, actual.TotalPrice);
        }
    }
}
