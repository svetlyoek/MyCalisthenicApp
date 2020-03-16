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

        public CommentsController(ICommentsService commentsService)
        {
            this.commentsService = commentsService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(string id, CommentInputViewModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View("Error404");
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

        public async Task<IActionResult> Rate(string postId, string commentId)
        {
            await this.commentsService.AddRatingAsync(commentId);

            return this.LocalRedirect($"/Posts/Details?id={postId}");
        }
    }
}
