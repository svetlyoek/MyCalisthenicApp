namespace MyCalisthenicApp.Web.Components
{
    using Microsoft.AspNetCore.Mvc;
    using MyCalisthenicApp.Services.Contracts;

    [ViewComponent(Name = "HomeLatestNews")]
    public class HomeLatestNewsViewComponent : ViewComponent
    {
        private readonly IPostsService postsService;

        public HomeLatestNewsViewComponent(IPostsService postsService)
        {
            this.postsService = postsService;
        }

        public IViewComponentResult Invoke()
        {
            var posts = this.postsService.GetPopularPostsAsync()
                .GetAwaiter()
                .GetResult();

            return this.View(posts);

        }
    }
}
