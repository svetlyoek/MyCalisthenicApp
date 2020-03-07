namespace MyCalisthenicApp.Services.Contracts
{
    using System.Threading.Tasks;

    public interface IUserRequestsService
    {
        Task CreateAsync(string fullName, string email, string content);
    }
}
