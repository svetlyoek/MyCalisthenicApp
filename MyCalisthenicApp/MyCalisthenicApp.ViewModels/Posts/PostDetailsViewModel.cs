namespace MyCalisthenicApp.ViewModels.Posts
{
    using System;
    using System.Collections.Generic;

    using MyCalisthenicApp.ViewModels.Comments;

    public class PostDetailsViewModel
    {
        public string Id { get; set; }

        public string ImageUrl { get; set; }

        public string VideoUrl { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Author { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public IEnumerable<CommentViewModel> Comments { get; set; }
    }
}
