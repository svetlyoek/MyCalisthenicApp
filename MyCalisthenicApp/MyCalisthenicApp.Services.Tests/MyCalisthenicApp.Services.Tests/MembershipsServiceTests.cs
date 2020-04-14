namespace MyCalisthenicApp.Services.Tests
{
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using MyCalisthenicApp.Data;
    using MyCalisthenicApp.Mapping.MappingConfiguration;
    using MyCalisthenicApp.Models;
    using MyCalisthenicApp.ViewModels.Memberships;
    using System;
    using System.Threading.Tasks;
    using Xunit;

    public class MembershipsServiceTests
    {
        private const string MembershipName = "Membership name";
        private const string MembershipId = "1234";
        private decimal? MembershipYearlyPrice = 89.90M;

        [Fact]
        public async Task GetAllMembershipPlansAsyncShouldReturnAllMemberships()
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

            var membershipsService = new MembershipsService(dbContext, mapper);

            for (int i = 0; i < 4; i++)
            {
                var membership = new Membership
                {
                    Name = MembershipName,
                    YearlyPrice = MembershipYearlyPrice,
                };

                await dbContext.Memberships.AddAsync(membership);

                await dbContext.SaveChangesAsync();
            }

            var expected = await membershipsService.GetAllMembershipPlansAsync();

            var counter = 0;

            foreach (var mms in expected)
            {
                counter++;
            }

            Assert.Equal(4, counter);
        }

        [Fact]
        public async Task GetAllMembershipsAsyncShouldReturnAllMemberships()
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

            var membershipsService = new MembershipsService(dbContext, mapper);

            for (int i = 0; i < 4; i++)
            {
                var membership = new Membership
                {
                    Name = MembershipName,
                };

                await dbContext.Memberships.AddAsync(membership);

                await dbContext.SaveChangesAsync();
            }

            var expected = await membershipsService.GetAllMembershipsAsync();

            var counter = 0;

            foreach (var mms in expected)
            {
                counter++;
            }

            Assert.Equal(4, counter);
        }

        [Fact]
        public async Task GetMembershipByIdAsyncShouldThrowExceptionIfMembershipIsNull()
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

            var membershipsService = new MembershipsService(dbContext, mapper);

            var membership = new Membership
            {
                Name = MembershipName,
            };

            await dbContext.Memberships.AddAsync(membership);

            await dbContext.SaveChangesAsync();

            var exception = await Assert.ThrowsAsync<ArgumentNullException>(async () => await membershipsService.GetMembershipByIdAsync(MembershipId));

            Assert.IsType<ArgumentNullException>(exception);
        }

        [Fact]
        public async Task GetMembershipByIdAsyncShouldReturnMembershipSuccessfully()
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

            var membershipsService = new MembershipsService(dbContext, mapper);

            var membership = new Membership
            {
                Id = MembershipId,
                Name = MembershipName,
            };

            await dbContext.Memberships.AddAsync(membership);

            await dbContext.SaveChangesAsync();

            var expected = await membershipsService.GetMembershipByIdAsync(MembershipId);

            Assert.Equal(expected.Id, membership.Id);
        }

        [Fact]
        public async Task EditMembershipAsyncShouldThrowExceptionIfmembershipIsNull()
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

            var membershipsService = new MembershipsService(dbContext, mapper);

            var membership = new Membership
            {
                Name = MembershipName,
            };

            await dbContext.Memberships.AddAsync(membership);

            await dbContext.SaveChangesAsync();

            var membershipModel = new MembershipAdminEditViewModel
            {
                Id = MembershipId,
                Name = MembershipName,
            };

            var exception = await Assert.ThrowsAsync<ArgumentNullException>(async () => await membershipsService.EditMembershipAsync(membershipModel));

            Assert.IsType<ArgumentNullException>(exception);
        }

        [Fact]
        public async Task EditMembershipAsyncShouldEditMembershipSuccessfully()
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

            var membershipsService = new MembershipsService(dbContext, mapper);

            var membership = new Membership
            {
                Id = MembershipId,
                Name = MembershipName,
            };

            await dbContext.Memberships.AddAsync(membership);

            await dbContext.SaveChangesAsync();

            var membershipModel = new MembershipAdminEditViewModel
            {
                Id = MembershipId,
                Name = MembershipName,
                YearlyPrice = MembershipYearlyPrice,
            };

            await membershipsService.EditMembershipAsync(membershipModel);

            var actual = await dbContext.Memberships.FirstOrDefaultAsync(m => m.Id == MembershipId);

            Assert.Equal(actual.YearlyPrice, membershipModel.YearlyPrice);
        }

        [Fact]
        public async Task GetMembershipPriceByIdAsyncShouldReturnmembershipPriceSuccessfully()
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

            var membershipsService = new MembershipsService(dbContext, mapper);

            var membership = new Membership
            {
                Id = MembershipId,
                Name = MembershipName,
                YearlyPrice = MembershipYearlyPrice,
            };

            await dbContext.Memberships.AddAsync(membership);

            await dbContext.SaveChangesAsync();

            var expected = await membershipsService.GetMembershipPriceByIdAsync(MembershipId);

            Assert.Equal(expected, MembershipYearlyPrice);
        }

        [Fact]
        public async Task GetMembershipPriceByIdAsyncShouldReturnZeroIfMembershipPriceIsNull()
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

            var membershipsService = new MembershipsService(dbContext, mapper);

            var membership = new Membership
            {
                Id = MembershipId,
                Name = MembershipName,
            };

            await dbContext.Memberships.AddAsync(membership);

            await dbContext.SaveChangesAsync();

            var expected = await membershipsService.GetMembershipPriceByIdAsync(MembershipId);

            Assert.Equal(0, expected);
        }

        [Fact]
        public async Task CreateMembershipAsyncShouldCreateMembershipSuccessfully()
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

            var membershipsService = new MembershipsService(dbContext, mapper);

            var membershipModel = new MembershipAdminCreateViewModel
            {
                Name = MembershipName,
                YearlyPrice = MembershipYearlyPrice,
            };

            await membershipsService.CreateMembershipAsync(membershipModel);

            var actual = await dbContext.Memberships.FirstOrDefaultAsync();

            Assert.Equal(membershipModel.YearlyPrice, actual.YearlyPrice);
        }
    }
}
