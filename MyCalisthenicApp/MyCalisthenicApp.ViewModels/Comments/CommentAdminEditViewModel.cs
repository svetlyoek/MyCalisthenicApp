namespace MyCalisthenicApp.ViewModels.Comments
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using MyCalisthenicApp.Models;

    public class CommentAdminEditViewModel
    {
        public string Id { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        [Required]
        [MaxLength(DataValidations.CommentTextMaxLength)]
        public string Text { get; set; }

        [Required]
        public string AuthorId { get; set; }

        public int? Rating { get; set; }

        public string PostId { get; set; }

        public string ProductId { get; set; }

        public string ProgramId { get; set; }
    }
}
