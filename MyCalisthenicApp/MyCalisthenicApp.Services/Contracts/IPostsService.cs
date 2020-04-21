namespace MyCalisthenicApp.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using MyCalisthenicApp.ViewModels.Home;
    using MyCalisthenicApp.ViewModels.Posts;

    public interface IPostsService
    {
        Task<IEnumerable<PopularPostsHomeViewModel>> GetPopularPostsAsync();

        Task<PostDetailsViewModel> GetPostDetailsByIdAsync(string id);

        Task<IEnumerable<PostDetailsSidebarViewModel>> GetFourLatestPostsAsync();

        Task<IEnumerable<PostDetailsViewModel>> GetAllPostsAsync();

        Task<IList<PostsAdminViewModel>> GetAllPostsForAdminAsync();

        Task<PostAdminEditViewModel> GetPostForAdminByIdAsync(string id);

        Task EditPostAsync(PostAdminEditViewModel inputModel);

        Task CreatePostAsync(PostAdminCreateViewModel inputModel);

        Task<IList<string>> GetAllLikesByPostIdAsync(string id);

        Task<IEnumerable<PostDetailsViewModel>> SortPostsByCategoryAsync(string sort);

        Task AddRatingAsync(string id);

        bool GetPostById(string id);

        Task<IEnumerable<PostDetailsViewModel>> GetPostsBySearchAsync(SearchViewModel inputModel);
    }
}
