namespace MyCalisthenicApp.ViewModels.Comments
{
    using System.ComponentModel.DataAnnotations;

    using MyCalisthenicApp.ViewModels.Validations;

    public class CommentInputViewModel
    {
        [Required]
        [StringLength(WebValidations.CommentMessageMaxLength, ErrorMessage = WebValidations.InvalidCommentTextLength, MinimumLength = WebValidations.CommentMessageMinLength)]
        public string Text { get; set; }

        public string Id { get; set; }
    }
}
