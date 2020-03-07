namespace MyCalisthenicApp.ViewModels.Blogs
{
    using System.ComponentModel.DataAnnotations;

    using MyCalisthenicApp.ViewModels.Validations;

    public class CommentInputViewModel
    {
        [Required]
        [MaxLength(WebValidations.CommentMessageMaxLength)]
        public string Message { get; set; }

        [Required]
        [MaxLength(WebValidations.CommentFullNameMaxLength)]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
