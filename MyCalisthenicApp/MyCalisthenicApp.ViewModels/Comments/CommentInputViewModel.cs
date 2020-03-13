namespace MyCalisthenicApp.ViewModels.Comments
{
    using System.ComponentModel.DataAnnotations;

    using MyCalisthenicApp.ViewModels.Validations;

    public class CommentInputViewModel
    {
        [Required]
        [MaxLength(WebValidations.CommentMessageMaxLength)]
        [MinLength(WebValidations.CommentMessageMinLength)]
        public string Text { get; set; }
    }
}
