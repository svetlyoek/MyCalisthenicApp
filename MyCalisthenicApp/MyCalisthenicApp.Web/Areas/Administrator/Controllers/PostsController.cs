namespace MyCalisthenicApp.Web.Areas.Administrator.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using MyCalisthenicApp.Services.Contracts;
    using MyCalisthenicApp.ViewModels.Posts;

    public class PostsController : AdministratorController
    {
        private readonly IPostsService postsService;
        private readonly ICategoriesService categoriesService;
        private readonly IUsersService usersService;

        public PostsController(
            IPostsService postsService,
            ICategoriesService categoriesService,
            IUsersService usersService)
        {
            this.postsService = postsService;
            this.categoriesService = categoriesService;
            this.usersService = usersService;
        }

        public async Task<IActionResult> All()
        {
            var posts = await this.postsService.GetAllPostsForAdminAsync();

            return this.View(posts);
        }

        public async Task<IActionResult> Likes(string id)
        {
            var likes = await this.postsService.GetAllLikesByPostIdAsync(id);

            return this.View(likes);
        }

        public async Task<IActionResult> Edit(string id)
        {
            var post = await this.postsService.GetPostForAdminByIdAsync(id);

            return this.View(post);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PostAdminEditViewModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            await this.postsService.EditPostAsync(inputModel);

            return this.RedirectToAction("All");
        }

        public async Task<IActionResult> Create()
        {
            var categories = this.categoriesService.GetAllPostCategories();

            var adminId = await this.usersService.GetAdminIdAsync();

            var postViewModel = new PostAdminCreateViewModel
            {
                AuthorId = adminId,
                Categories = categories,
            };

            return this.View(postViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(PostAdminCreateViewModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            await this.postsService.CreatePostAsync(inputModel);

            return this.RedirectToAction("All");
        }
    }
}
