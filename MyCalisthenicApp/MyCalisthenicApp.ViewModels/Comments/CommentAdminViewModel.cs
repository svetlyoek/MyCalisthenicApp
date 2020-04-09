namespace MyCalisthenicApp.ViewModels.Comments
{
    using System;

    public class CommentAdminViewModel
    {
        public string Id { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public DateTime? CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public string Text { get; set; }

        public string AuthorId { get; set; }

        public string AuthorName { get; set; }

        public int? Rating { get; set; }

        public string PostId { get; set; }

        public string PostTitle { get; set; }

        public string ProductId { get; set; }

        public string ProductName { get; set; }

        public string ProgramId { get; set; }

        public string ProgramTitle { get; set; }
    }
}
