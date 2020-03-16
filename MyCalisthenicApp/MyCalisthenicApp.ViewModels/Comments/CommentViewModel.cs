namespace MyCalisthenicApp.ViewModels.Comments
{
    using System;

    using MyCalisthenicApp.ViewModels.Users;

    public class CommentViewModel
    {
        public CommentViewModel()
        {
            this.CreatedOn = DateTime.UtcNow;
        }

        public string Id { get; set; }

        public UserCommentViewModel Author { get; set; }

        public string Text { get; set; }

        public int? Rating { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
