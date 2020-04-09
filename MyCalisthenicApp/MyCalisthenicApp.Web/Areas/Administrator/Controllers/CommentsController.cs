namespace MyCalisthenicApp.Web.Areas.Administrator.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using MyCalisthenicApp.Services.Contracts;
    using MyCalisthenicApp.ViewModels.Comments;

    public class CommentsController : AdministratorController
    {
        private readonly ICommentsService commentsService;

        public CommentsController(ICommentsService commentsService)
        {
            this.commentsService = commentsService;
        }

        public async Task<IActionResult> Likes(string id)
        {
            var likes = await this.commentsService.GetAllLikesByCommentIdAsync(id);

            return this.View(likes);
        }

        public async Task<IActionResult> Edit(string id)
        {
            var comment = await this.commentsService.GetCommentByIdAsync(id);

            return this.View(comment);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CommentAdminEditViewModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            await this.commentsService.EditCommentAsync(inputModel);

            return this.RedirectToAction("Comments", "Users", new { id = inputModel.AuthorId });
        }
    }
}
