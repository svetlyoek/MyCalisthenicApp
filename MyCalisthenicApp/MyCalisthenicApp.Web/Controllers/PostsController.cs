namespace MyCalisthenicApp.Web.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MyCalisthenicApp.Services.Contracts;

    public class PostsController : BaseController
    {
        private readonly IPostsService postsService;
        private readonly ICommentsService commentsService;

        public PostsController(IPostsService postsService, ICommentsService commentsService)
        {
            this.postsService = postsService;
            this.commentsService = commentsService;
        }

        public async Task<IActionResult> Index()
        {
            var allPosts = await this.postsService.GetAllPostsAsync();

            return this.View(allPosts);
        }

        public async Task<IActionResult> Details(string id)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View("Error404");
            }

            var post = await this.postsService.GetPostDetailsById(id);

            var comments = await this.commentsService.GetCommentsByPostIdAsync(post.Id);

            post.Comments = comments;

            return this.View(post);
        }

        public async Task<IActionResult> Sort(string sort)
        {
            var sortedPosts = await this.postsService.SortPostsByCategoryAsync(sort);

            return this.View("Index", sortedPosts);
        }

        [Authorize]
        public async Task<IActionResult> Rate(string id)
        {
            await this.postsService.AddRatingAsync(id);

            return this.RedirectToAction(nameof(this.Details), new { id = id });
        }
    }
}
