namespace MyCalisthenicApp.Web.Components
{
    using Microsoft.AspNetCore.Mvc;
    using MyCalisthenicApp.Services.Contracts;
    using MyCalisthenicApp.ViewModels.Comments;

    [ViewComponent(Name = "Comment")]
    public class CommentViewComponent : ViewComponent
    {
        private readonly ICommentsService commentsService;

        public CommentViewComponent(ICommentsService commentsService)
        {
            this.commentsService = commentsService;
        }

        [HttpPost]
        public IViewComponentResult Invoke(string id, CommentInputViewModel commentModel)
        {
            this.commentsService.CreateCommentAsync(id, commentModel);

            return this.View(commentModel);
        }
    }
}
