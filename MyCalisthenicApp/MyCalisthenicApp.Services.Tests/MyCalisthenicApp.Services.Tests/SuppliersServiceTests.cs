namespace MyCalisthenicApp.Services.Tests
{
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using MyCalisthenicApp.Data;
    using MyCalisthenicApp.Mapping.MappingConfiguration;
    using MyCalisthenicApp.Models.ShopEntities;
    using MyCalisthenicApp.ViewModels.Suppliers;
    using System;
    using System.Threading.Tasks;
    using Xunit;

    public class SuppliersServiceTests
    {
        private const string SupplierId = "48575";
        private const string SupplierName = "Supplier name";
        private const string SupplierEditName = "Supplier edit name";
        private decimal SupplierPriceToHome = 6.80M;
        private decimal SupplierPriceToOffice = 6.00M;

        [Fact]
        public async Task GetAllSuppliersAsyncShouldReturnAllSuppliersSuccessfully()
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

            var suppliersService = new SuppliersService(dbContext, mapper);

            for (int i = 0; i < 3; i++)
            {
                var supplier = new Supplier
                {
                    Name = SupplierName,
                    PriceToHome = SupplierPriceToHome,
                    PriceToOffice = SupplierPriceToOffice,
                };

                await dbContext.Suppliers.AddAsync(supplier);

                await dbContext.SaveChangesAsync();
            }

            var deletedSupplier = new Supplier
            {
                Name = SupplierName,
                IsDeleted = true,
                PriceToHome = SupplierPriceToHome,
                PriceToOffice = SupplierPriceToOffice,
            };

            await dbContext.Suppliers.AddAsync(deletedSupplier);

            await dbContext.SaveChangesAsync();

            var expected = await suppliersService.GetAllSuppliersAsync();

            var counter = 0;

            foreach (var supp in expected)
            {
                counter++;
            }

            Assert.Equal(3, counter);
        }

        [Fact]
        public async Task GetAllSuppliersForAdminAsyncShouldReturnAllSuppliersSuccessfully()
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

            var suppliersService = new SuppliersService(dbContext, mapper);

            for (int i = 0; i < 3; i++)
            {
                var supplier = new Supplier
                {
                    Name = SupplierName,
                    PriceToHome = SupplierPriceToHome,
                    PriceToOffice = SupplierPriceToOffice,
                };

                await dbContext.Suppliers.AddAsync(supplier);

                await dbContext.SaveChangesAsync();
            }

            var deletedSupplier = new Supplier
            {
                Name = SupplierName,
                IsDeleted = true,
                PriceToHome = SupplierPriceToHome,
                PriceToOffice = SupplierPriceToOffice,
            };

            await dbContext.Suppliers.AddAsync(deletedSupplier);

            await dbContext.SaveChangesAsync();

            var expected = await suppliersService.GetAllSuppliersForAdminAsync();

            var counter = 0;

            foreach (var supp in expected)
            {
                counter++;
            }

            Assert.Equal(4, counter);
        }

        [Fact]
        public async Task EditSupplierAsyncShouldThrowExceptionIfSupplierIsNull()
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

            var suppliersService = new SuppliersService(dbContext, mapper);

            var supplierModel = new SupplierAdminEditViewModel
            {
                Name = SupplierName,
                PriceToHome = SupplierPriceToHome,
                PriceToOffice = SupplierPriceToOffice,
            };

            var exception = await Assert.ThrowsAsync<ArgumentNullException>(async () => await suppliersService.EditSupplierAsync(supplierModel));

            Assert.IsType<ArgumentNullException>(exception);
        }

        [Fact]
        public async Task EditSupplierAsyncShouldEditSupplierSuccessfully()
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

            var suppliersService = new SuppliersService(dbContext, mapper);

            var supplier = new Supplier
            {
                Id = SupplierId,
                Name = SupplierName,
                PriceToHome = SupplierPriceToHome,
                PriceToOffice = SupplierPriceToOffice,
            };

            await dbContext.Suppliers.AddAsync(supplier);

            await dbContext.SaveChangesAsync();

            var supplierModel = new SupplierAdminEditViewModel
            {
                Id = supplier.Id,
                Name = SupplierEditName,
                PriceToHome = SupplierPriceToHome,
                PriceToOffice = SupplierPriceToOffice,
            };

            await suppliersService.EditSupplierAsync(supplierModel);

            var actual = await dbContext.Suppliers.FirstOrDefaultAsync(s => s.Name == supplier.Name);

            Assert.Equal(supplierModel.Name, actual.Name);
        }

        [Fact]
        public async Task GetSupplierByIdAsyncShouldThrowExceptionIfSupplierIsNull()
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

            var suppliersService = new SuppliersService(dbContext, mapper);

            var exception = await Assert.ThrowsAsync<ArgumentNullException>(async () => await suppliersService.GetSupplierByIdAsync(SupplierId));

            Assert.IsType<ArgumentNullException>(exception);
        }

        [Fact]
        public async Task GetSupplierByIdAsyncShouldReturnSupplierSuccessfully()
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

            var suppliersService = new SuppliersService(dbContext, mapper);

            var supplier = new Supplier
            {
                Name = SupplierName,
                PriceToHome = SupplierPriceToHome,
                PriceToOffice = SupplierPriceToOffice,
            };

            await dbContext.Suppliers.AddAsync(supplier);

            await dbContext.SaveChangesAsync();

            var expected = await suppliersService.GetSupplierByIdAsync(supplier.Id);

            Assert.Equal(expected.Id, supplier.Id);
        }

        [Fact]
        public async Task CreateSupplierAsyncShouldCreateSupplierSuccessfully()
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

            var suppliersService = new SuppliersService(dbContext, mapper);

            var supplierModel = new SupplierAdminCreateViewModel
            {
                Name = SupplierName,
                PriceToHome = SupplierPriceToHome,
                PriceToOffice = SupplierPriceToOffice,
            };

            await suppliersService.CreateSupplierAsync(supplierModel);

            var actual = await dbContext.Suppliers.FirstOrDefaultAsync();

            Assert.Equal(supplierModel.Name, actual.Name);
        }
    }
}
