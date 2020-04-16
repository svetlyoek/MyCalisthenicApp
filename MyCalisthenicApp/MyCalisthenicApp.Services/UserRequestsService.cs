namespace MyCalisthenicApp.Services
{
    using System.Threading.Tasks;

    using MyCalisthenicApp.Data;
    using MyCalisthenicApp.Models;
    using MyCalisthenicApp.Services.Contracts;

    public class UserRequestsService : IUserRequestsService
    {
        private readonly MyCalisthenicAppDbContext dbContext;

        public UserRequestsService(MyCalisthenicAppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task CreateAsync(string fullName, string email, string content)
        {
            var userRequest = new UserRequest
            {
                FullName = fullName,
                Email = email,
                Content = content,
            };

            await this.dbContext.UserRequests.AddAsync(userRequest);

            await this.dbContext.SaveChangesAsync();
        }
    }
}
