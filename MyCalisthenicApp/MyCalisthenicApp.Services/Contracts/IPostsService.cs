namespace MyCalisthenicApp.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using MyCalisthenicApp.ViewModels.Posts;

    public interface IPostsService
    {
        Task<IEnumerable<PopularPostsHomeViewModel>> GetPopularPostsAsync();
    }
}
