namespace MyCalisthenicApp.ViewModels.Posts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.AspNetCore.Mvc;

    public class PostPageViewModel
    {
        public IEnumerable<PostDetailsViewModel> Posts { get; set; }

        public IEnumerable<PostDetailsSidebarViewModel> SidebarPosts { get; set; }

        public int PostsPerPage { get; set; }

        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; }

        public int PageCount()
        {
            return Convert.ToInt32(Math.Ceiling(this.Posts.Count() / (double)this.PostsPerPage));
        }

        public IEnumerable<PostDetailsViewModel> PaginatedPosts()
        {
            int start = (this.CurrentPage - 1) * this.PostsPerPage;

            return this.Posts.Skip(start).Take(this.PostsPerPage);
        }

        public IEnumerable<PostDetailsSidebarViewModel> PaginatedSidebarPosts()
        {
            int start = (this.CurrentPage - 1) * this.PostsPerPage;

            return this.SidebarPosts.Skip(start).Take(this.PostsPerPage);
        }
    }
}
