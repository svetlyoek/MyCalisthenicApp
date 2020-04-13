namespace MyCalisthenicApp.Services.Tests
{
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using MyCalisthenicApp.Data;
    using MyCalisthenicApp.Mapping.MappingConfiguration;
    using MyCalisthenicApp.Models;
    using MyCalisthenicApp.Models.ShopEntities;
    using MyCalisthenicApp.ViewModels.Addresses;
    using System;
    using System.Threading.Tasks;
    using Xunit;

    public class AddressesServiceTests
    {
        private const string CityName = "Sofia";
        private const string CityPostCode = "1000";
        private const string AddressCountryName = "Bulgaria";
        private const string AddressEditCountryName = "France";
        private const string AddressStreet = "Shipka 156";
        private const string AddressId = "123456";
        private const string UserId = "123";
        private const string CityId = "123";
        private const string UserFirstName = "123";
        private const string UserLastName = "123";

        [Fact]
        public async Task EditAddressAsyncShouldEditAddressSuccessfully()
        {
            var options = new DbContextOptionsBuilder<MyCalisthenicAppDbContext>()
                    .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                    .Options;

            var dbContext = new MyCalisthenicAppDbContext(options);

            var addressService = new AddressesService(dbContext, null);

            var city = new City
            {
                Id = Guid.NewGuid().ToString(),
                Name = CityName,
                PostCode = CityPostCode,
            };

            await dbContext.Cities.AddAsync(city);

            await dbContext.SaveChangesAsync();

            var user = new ApplicationUser
            {
                FirstName = UserFirstName,
                LastName = UserLastName,
            };

            await dbContext.Users.AddAsync(user);

            await dbContext.SaveChangesAsync();

            var address = new Address
            {
                Country = AddressCountryName,
                Street = AddressStreet,
                CityId = city.Id,
                UserId = user.Id,
            };

            await dbContext.Addresses.AddAsync(address);

            await dbContext.SaveChangesAsync();

            var addressViewModel = new AddressAdminEditViewModel
            {
                Id = address.Id,
                CityId = city.Id,
                Country = AddressEditCountryName,
                UserId = user.Id,
            };

            await addressService.EditAddressAsync(addressViewModel);

            Assert.Equal(address.Country, addressViewModel.Country);
        }

        [Fact]
        public async Task EditAddressAsyncShouldThrowExceptionIfCityIdDoesNotExists()
        {
            var options = new DbContextOptionsBuilder<MyCalisthenicAppDbContext>()
                    .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                    .Options;

            var dbContext = new MyCalisthenicAppDbContext(options);

            var addressService = new AddressesService(dbContext, null);

            var city = new City
            {
                Id = Guid.NewGuid().ToString(),
                Name = CityName,
                PostCode = CityPostCode,
            };

            await dbContext.Cities.AddAsync(city);

            await dbContext.SaveChangesAsync();

            var user = new ApplicationUser
            {
                FirstName = UserFirstName,
                LastName = UserLastName,
            };

            await dbContext.Users.AddAsync(user);

            await dbContext.SaveChangesAsync();

            var address = new Address
            {
                Country = AddressCountryName,
                Street = AddressStreet,
                CityId = city.Id,
                UserId = user.Id,
            };

            await dbContext.Addresses.AddAsync(address);

            await dbContext.SaveChangesAsync();

            var addressViewModel = new AddressAdminEditViewModel
            {
                Id = address.Id,
                CityId = CityId,
                Country = AddressEditCountryName,
                UserId = user.Id,
            };

            var exception = await Assert.ThrowsAsync<ArgumentNullException>(async () => await addressService.EditAddressAsync(addressViewModel));

            Assert.IsType<ArgumentNullException>(exception);
        }

        [Fact]
        public async Task EditAddressAsyncShouldThrowExceptionIfUserIdDoesNotExists()
        {
            var options = new DbContextOptionsBuilder<MyCalisthenicAppDbContext>()
                    .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                    .Options;

            var dbContext = new MyCalisthenicAppDbContext(options);

            var addressService = new AddressesService(dbContext, null);

            var city = new City
            {
                Id = Guid.NewGuid().ToString(),
                Name = CityName,
                PostCode = CityPostCode,
            };

            await dbContext.Cities.AddAsync(city);

            await dbContext.SaveChangesAsync();

            var user = new ApplicationUser
            {
                FirstName = UserFirstName,
                LastName = UserLastName,
            };

            await dbContext.Users.AddAsync(user);

            await dbContext.SaveChangesAsync();

            var address = new Address
            {
                Country = AddressCountryName,
                Street = AddressStreet,
                CityId = city.Id,
                UserId = user.Id,
            };

            await dbContext.Addresses.AddAsync(address);

            await dbContext.SaveChangesAsync();

            var addressViewModel = new AddressAdminEditViewModel
            {
                Id = address.Id,
                CityId = CityId,
                Country = AddressEditCountryName,
                UserId = UserId,
            };

            var exception = await Assert.ThrowsAsync<ArgumentNullException>(async () => await addressService.EditAddressAsync(addressViewModel));

            Assert.IsType<ArgumentNullException>(exception);
        }

        [Fact]
        public async Task EditAddressAsyncShouldThrowExceptionIfCityIsNull()
        {
            var option = new DbContextOptionsBuilder<MyCalisthenicAppDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;

            var dbContext = new MyCalisthenicAppDbContext(option);

            var addressService = new AddressesService(dbContext, null);

            var city = new City
            {
                Id = Guid.NewGuid().ToString(),
                Name = CityName,
                PostCode = CityPostCode,
            };

            await dbContext.Cities.AddAsync(city);

            await dbContext.SaveChangesAsync();

            var addressViewModel = new AddressAdminEditViewModel
            {
                CityId = Guid.NewGuid().ToString(),
            };

            var exception = await Assert.ThrowsAsync<ArgumentNullException>(async () => await addressService.EditAddressAsync(addressViewModel));

            Assert.IsType<ArgumentNullException>(exception);
        }

        [Fact]
        public async Task EditAddressAsyncShouldThrowExceptionIfAddressIsNull()
        {
            var option = new DbContextOptionsBuilder<MyCalisthenicAppDbContext>()
                  .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;

            var dbContext = new MyCalisthenicAppDbContext(option);

            var addressService = new AddressesService(dbContext, null);

            var city = new City
            {
                Id = Guid.NewGuid().ToString(),
                Name = CityName,
                PostCode = CityPostCode,
            };

            await dbContext.Cities.AddAsync(city);

            await dbContext.SaveChangesAsync();

            var address = new Address
            {
                Country = AddressCountryName,
                Street = AddressStreet,
                CityId = city.Id,
            };

            await dbContext.Addresses.AddAsync(address);

            await dbContext.SaveChangesAsync();

            var addressViewModel = new AddressAdminEditViewModel
            {
                Id = Guid.NewGuid().ToString(),
            };

            var exception = await Assert.ThrowsAsync<ArgumentNullException>(async () => await addressService.EditAddressAsync(addressViewModel));

            Assert.IsType<ArgumentNullException>(exception);
        }

        [Fact]
        public async Task GetAddressByIdAsyncShouldReturnAddressByIdSuccessfully()
        {
            var option = new DbContextOptionsBuilder<MyCalisthenicAppDbContext>()
                 .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;

            var dbContext = new MyCalisthenicAppDbContext(option);

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MyCalisthenicAppProfile());
            });

            var mapper = mockMapper.CreateMapper();

            var addressService = new AddressesService(dbContext, mapper);

            var city = new City
            {
                Id = Guid.NewGuid().ToString(),
                Name = CityName,
                PostCode = CityPostCode,
            };

            await dbContext.Cities.AddAsync(city);

            await dbContext.SaveChangesAsync();

            var address = new Address
            {
                Id = AddressId,
                Country = AddressCountryName,
                Street = AddressStreet,
                CityId = city.Id,
            };

            await dbContext.Addresses.AddAsync(address);

            await dbContext.SaveChangesAsync();

            var expected = await addressService.GetAddressByIdAsync(AddressId);

            Assert.Equal(expected.Id, address.Id);
        }

        [Fact]
        public async Task GetAddressByIdAsyncShouldThrowExceptionIfNull()
        {
            var option = new DbContextOptionsBuilder<MyCalisthenicAppDbContext>()
                 .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;

            var dbContext = new MyCalisthenicAppDbContext(option);

            var addressService = new AddressesService(dbContext, null);

            var city = new City
            {
                Id = Guid.NewGuid().ToString(),
                Name = CityName,
                PostCode = CityPostCode,
            };

            await dbContext.Cities.AddAsync(city);

            await dbContext.SaveChangesAsync();

            var address = new Address
            {
                Id = Guid.NewGuid().ToString(),
                Country = AddressCountryName,
                Street = AddressStreet,
                CityId = city.Id,
            };

            await dbContext.Addresses.AddAsync(address);

            await dbContext.SaveChangesAsync();

            var exception = await Assert.ThrowsAsync<ArgumentNullException>(async () => await addressService.GetAddressByIdAsync(AddressId));

            Assert.IsType<ArgumentNullException>(exception);
        }

    }
}
