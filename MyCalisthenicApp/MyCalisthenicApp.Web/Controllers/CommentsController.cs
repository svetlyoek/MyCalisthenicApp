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
        [Route("/Comments/Create")]
        public async Task<IActionResult> Create(string id, CommentInputViewModel inputModel)
        {
            await this.commentsService.CreateCommentAsync(id, inputModel);

            return this.RedirectToAction("Index");
        }
    }
}
