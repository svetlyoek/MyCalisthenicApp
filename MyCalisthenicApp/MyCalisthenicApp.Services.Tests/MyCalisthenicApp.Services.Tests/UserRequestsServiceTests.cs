namespace MyCalisthenicApp.Services.Tests
{
    using Microsoft.EntityFrameworkCore;
    using MyCalisthenicApp.Data;
    using System;
    using System.Threading.Tasks;
    using Xunit;

    public class UserRequestsServiceTests
    {
        private const string UserRequestFullName = "Full name";
        private const string UserRequestEmail = "user@abv.bg";
        private const string UserRequestContent = "Request content";

        [Fact]
        public async Task CreateAsyncShouldCreateRequestSuccessfully()
        {
            var options = new DbContextOptionsBuilder<MyCalisthenicAppDbContext>()
                   .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                   .Options;

            var dbContext = new MyCalisthenicAppDbContext(options);

            var userRequestsService = new UserRequestsService(dbContext);

            await userRequestsService.CreateAsync(UserRequestFullName, UserRequestEmail, UserRequestContent);

            var actual = await dbContext.UserRequests.FirstOrDefaultAsync();

            Assert.Equal(actual.FullName, UserRequestFullName);
        }
    }
}
