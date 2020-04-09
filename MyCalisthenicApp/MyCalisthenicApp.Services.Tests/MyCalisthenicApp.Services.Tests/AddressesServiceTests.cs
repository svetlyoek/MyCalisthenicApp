namespace MyCalisthenicApp.Services.Tests
{
    using Microsoft.EntityFrameworkCore;
    using MyCalisthenicApp.Data;
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

        [Fact]
        public async Task EditAddressAsyncShouldEditAddress()
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
                Id = address.Id,
                CityId = city.Id,
                Country = AddressEditCountryName,
            };

            await addressService.EditAddressAsync(addressViewModel);

            Assert.Equal(address.Country, addressViewModel.Country);
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
        public async Task GetAddressByIdAsyncShouldGetAddressByIdSuccessfully()
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
                Id = AddressId,
                Country = AddressCountryName,
                Street = AddressStreet,
                CityId = city.Id,
            };

            await dbContext.Addresses.AddAsync(address);

            await dbContext.SaveChangesAsync();

            var addressViewModel = new AddressAdminEditViewModel
            {
                Id = address.Id,
                Country = address.Country,
                Street = address.Street,
                CityId = city.Id,
            };

            var actual = dbContext.Addresses.FirstOrDefaultAsync(a => a.Id == AddressId);

            Assert.Equal(actual.Result.Id, addressViewModel.Id);
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
