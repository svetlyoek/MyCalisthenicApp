namespace MyCalisthenicApp.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IImagesService
    {
        Task<IEnumerable<string>> GetImagesByProductIdAsync(string id);
    }
}
