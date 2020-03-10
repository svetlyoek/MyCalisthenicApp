namespace MyCalisthenicApp.ViewModels.Comments
{
    using System.ComponentModel.DataAnnotations;

    using MyCalisthenicApp.ViewModels.Validations;

    public class CommentInputViewModel
    {
        [Required]
        [MaxLength(WebValidations.CommentMessageMaxLength)]
        public string Message { get; set; }

        [Required]
        [MaxLength(WebValidations.CommentFirstNameMaxLength)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(WebValidations.CommentLastNameMaxLength)]
        public string LastName { get; set; }
    }
}
