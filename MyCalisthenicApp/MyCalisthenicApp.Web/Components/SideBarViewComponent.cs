namespace MyCalisthenicApp.Web.Components
{
    using Microsoft.AspNetCore.Mvc;
    using MyCalisthenicApp.Services.Contracts;

    [ViewComponent(Name = "SideBar")]
    public class SideBarViewComponent : ViewComponent
    {
        private readonly IPostsService postsService;

        public SideBarViewComponent(IPostsService postsService)
        {
            this.postsService = postsService;
        }

        public IViewComponentResult Invoke()
        {
            var posts = this.postsService.GetFourLatestPosts()
                .GetAwaiter()
                .GetResult();

            return this.View(posts);
        }
    }
}
