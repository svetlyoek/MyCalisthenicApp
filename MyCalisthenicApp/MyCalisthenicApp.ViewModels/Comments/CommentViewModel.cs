namespace MyCalisthenicApp.ViewModels.Comments
{
    using MyCalisthenicApp.ViewModels.Users;

    public class CommentViewModel
    {
        public UserCommentViewModel Author { get; set; }

        public string Text { get; set; }

        public int? Rating { get; set; }
    }
}
