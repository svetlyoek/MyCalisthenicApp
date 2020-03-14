﻿namespace MyCalisthenicApp.ViewModels.Posts
{
    using System;

    public class PopularPostsHomeViewModel
    {
        public string ImageUrl { get; set; }

        public DateTime CreatedOn { get; set; }

        public string AuthorName { get; set; }

        public int? CommentsCount { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
    }
}
