namespace MyCalisthenicApp.ViewModels.Subscribes
{
    using System.ComponentModel.DataAnnotations;

    public class SubscribeInputViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
