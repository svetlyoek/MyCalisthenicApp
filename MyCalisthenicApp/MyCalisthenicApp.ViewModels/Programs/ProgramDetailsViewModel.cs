namespace MyCalisthenicApp.ViewModels.Programs
{
    using System.Collections.Generic;

    using MyCalisthenicApp.ViewModels.Categories;
    using MyCalisthenicApp.ViewModels.Comments;

    public class ProgramDetailsViewModel
    {
        public string Id { get; set; }

        public string ImageUrl { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int? Rating { get; set; }

        public string Type { get; set; }

        public string MembershipType { get; set; }

        public IEnumerable<CommentViewModel> Comments { get; set; }

        public CategoryViewModel Category { get; set; }
    }
}
