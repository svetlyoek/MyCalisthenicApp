namespace MyCalisthenicApp.Web.Components
{
    using Microsoft.AspNetCore.Mvc;

    [ViewComponent(Name = "Comment")]
    public class CommentViewComponent : ViewComponent
    {
        public CommentViewComponent()
        {
        }

        public IViewComponentResult Invoke()
        {
            return this.View();
        }
    }
}
