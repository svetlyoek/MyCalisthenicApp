namespace MyCalisthenicApp.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using MyCalisthenicApp.ViewModels.Posts;

    public interface IPostsService
    {
        Task<IEnumerable<PopularPostsHomeViewModel>> GetPopularPostsAsync();

        Task<PostDetailsViewModel> GetPostDetailsById(string id);

        Task<IEnumerable<PostDetailsSidebarViewModel>> GetFourLatestPosts();

        Task<IEnumerable<PostDetailsViewModel>> GetAllPostsAsync();

        Task<IEnumerable<PostDetailsViewModel>> SortPostsByCategoryAsync(string sort);

        Task AddRatingAsync(string postId);

    }
}
