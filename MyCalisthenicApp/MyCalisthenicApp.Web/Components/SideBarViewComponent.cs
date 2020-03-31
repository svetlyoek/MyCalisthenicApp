namespace MyCalisthenicApp.Web.Components
{
    using Microsoft.AspNetCore.Mvc;
    using MyCalisthenicApp.Services.Common;
    using MyCalisthenicApp.Services.Contracts;
    using MyCalisthenicApp.ViewModels.Posts;

    [ViewComponent(Name = "SideBar")]
    public class SideBarViewComponent : ViewComponent
    {
        private readonly IPostsService postsService;

        public SideBarViewComponent(IPostsService postsService)
        {
            this.postsService = postsService;
        }

        public IViewComponentResult Invoke(int page)
        {
            var posts = this.postsService.GetFourLatestPostsAsync()
                .GetAwaiter()
                .GetResult();

            var postsViewModel = new PostPageViewModel
            {
                PostsPerPage = ServicesConstants.PostsCountPerPage,
                CurrentPage = page,
                SidebarPosts = posts,
            };

            return this.View(postsViewModel);
        }
    }
}
