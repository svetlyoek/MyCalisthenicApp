namespace MyCalisthenicApp.Services
{
    using MyCalisthenicApp.Services.Contracts;
    using MyCalisthenicApp.Data;
    using MyCalisthenicApp.Models;

    public class UserRequestService : IUserRequestsService
    {
        private readonly MyCalisthenicAppDbContext dbContext;

        public UserRequestService(MyCalisthenicAppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Create(string fullName, string email, string phoneNumber, string content)
        {
            var userRequest = new UserRequest
            {
                FullName = fullName,
                Email = email,
                PhoneNumber = phoneNumber,
                Content = content
            };

            this.dbContext.UserRequests.Add(userRequest);

            this.dbContext.SaveChanges();
        }
    }
}
