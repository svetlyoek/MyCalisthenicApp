namespace MyCalisthenicApp.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MyCalisthenicApp.Services.Contracts;
    using MyCalisthenicApp.ViewModels.Comments;

    [Authorize]
    public class CommentsController : BaseController
    {
        private readonly ICommentsService commentsService;
        private readonly IProductsService productsService;
        private readonly IProgramsService programsService;

        public CommentsController(
            ICommentsService commentsService,
            IPostsService postsService,
            IProductsService productsService,
            IProgramsService programsService)
        {
            this.commentsService = commentsService;
            this.postsService = postsService;
            this.productsService = productsService;
            this.programsService = programsService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(string id, CommentInputViewModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Redirect("~/Error404");
            }

            var comment = await this.commentsService.CreateCommentAsync(id, inputModel);

            if (comment.ProductId != null)
            {
                return this.LocalRedirect($"/Products/Details?id={id}");
            }

            if (comment.PostId != null)
            {
                return this.LocalRedirect($"/Posts/Details?id={id}");
            }

            if (comment.ProgramId != null)
            {
                return this.LocalRedirect($"/Programs/Details?id={id}");
            }

            return this.LocalRedirect("/Home/Index");
        }

        public async Task<IActionResult> Rate(string id)
        {
            var returnId = await this.commentsService.AddRatingAsync(id);

            if (this.programsService.GetProgramById(returnId))
            {
                return this.LocalRedirect($"/Programs/Details?id={returnId}");
            }
            else if (this.productsService.GetProductById(returnId))
            {
                return this.LocalRedirect($"/Products/Details?id={returnId}");
            }
            else
            {
                return this.LocalRedirect($"/Posts/Details?id={returnId}");
            }
        }
    }
}
