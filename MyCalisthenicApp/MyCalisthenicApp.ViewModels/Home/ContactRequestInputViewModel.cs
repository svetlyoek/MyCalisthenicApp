namespace MyCalisthenicApp.ViewModels.Home
{
    using MyCalisthenicApp.ViewModels.Validations;
    using System.ComponentModel.DataAnnotations;

    public class ContactRequestInputViewModel
    {
        [Required]
        [MaxLength(WebValidations.ContactFullNameMaxLength)]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        [MaxLength(WebValidations.ContactContentMaxLength)]
        public string Content { get; set; }
    }
}
