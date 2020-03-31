namespace MyCalisthenicApp.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MyCalisthenicApp.Services.Common;
    using MyCalisthenicApp.Services.Contracts;
    using MyCalisthenicApp.ViewModels.Posts;

    public class PostsController : BaseController
    {
        private readonly IPostsService postsService;
        private readonly ICommentsService commentsService;

        public PostsController(IPostsService postsService, ICommentsService commentsService)
        {
            this.postsService = postsService;
            this.commentsService = commentsService;
        }

        public async Task<IActionResult> Index(string sort, int page)
        {
            if (sort != null)
            {
                var sortedPosts = await this.postsService.SortPostsByCategoryAsync(sort);

                var sortedPostsViewModel = new PostPageViewModel
                {
                    PostsPerPage = ServicesConstants.PostsCountPerPage,
                    CurrentPage = page,
                    Posts = sortedPosts,
                };

                return this.View(sortedPostsViewModel);
            }
            else
            {
                var allPosts = await this.postsService.GetAllPostsAsync();

                var allPostsViewModel = new PostPageViewModel
                {
                    PostsPerPage = ServicesConstants.PostsCountPerPage,
                    CurrentPage = page,
                    Posts = allPosts,
                };

                return this.View(allPostsViewModel);
            }
        }

        public async Task<IActionResult> Details(string id)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View("Error404");
            }

            var post = await this.postsService.GetPostDetailsByIdAsync(id);

            var comments = await this.commentsService.GetCommentsByPostIdAsync(post.Id);

            post.Comments = comments;

            return this.View(post);
        }

        [Authorize]
        public async Task<IActionResult> Rate(string id)
        {
            await this.postsService.AddRatingAsync(id);

            return this.RedirectToAction(nameof(this.Details), new { id = id });
        }

        [HttpPost]
        public async Task<IActionResult> Search(PostSearchViewModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction("Index");
            }

            var posts = await this.postsService.GetPostsBySearchAsync(inputModel);

            var searchPostsViewModel = new PostPageViewModel
            {
                PostsPerPage = ServicesConstants.PostsCountPerPage,
                CurrentPage = ServicesConstants.PostsDefaultPage,
                Posts = posts,
            };

            return this.View("Index", searchPostsViewModel);
        }
    }
}
