namespace MyCalisthenicApp.Services.Contracts
{
    public interface IUserRequestsService
    {
        void Create(string fullName, string email, string phoneNumber, string content);
    }
}
