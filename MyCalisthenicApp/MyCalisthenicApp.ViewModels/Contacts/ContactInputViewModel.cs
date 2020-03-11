namespace MyCalisthenicApp.ViewModels.Contacts
{
    using System.ComponentModel.DataAnnotations;

    using MyCalisthenicApp.ViewModels.Validations;
    using MyCalisthenicApp.Web.Infrastructure;

    public class ContactInputViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Enter your full name.")]
        [Display(Name = "Your full name")]
        [StringLength(WebValidations.ContactFullNameMaxLength, ErrorMessage = WebValidations.InvalidContactFullNameLength, MinimumLength = WebValidations.ContactFullNameMinLength)]
        public string FullName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Enter your email address.")]
        [EmailAddress(ErrorMessage = "Enter your email address")]
        [Display(Name = "Your email address")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Enter message title.")]
        [StringLength(WebValidations.ContactTitleMaxLength, ErrorMessage = WebValidations.InvalidContactTitleLength, MinimumLength = WebValidations.ContactTitleMinLength)]
        [Display(Name = "Message title")]
        public string Title { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Enter message content.")]
        [StringLength(WebValidations.ContactContentMaxLength, ErrorMessage = WebValidations.InvalidContactContentLength, MinimumLength = WebValidations.ContactContentMinLength)]
        [Display(Name = "Message content")]
        public string Content { get; set; }

        [GoogleReCaptchaValidation]
        public string RecaptchaValue { get; set; }
    }
}
