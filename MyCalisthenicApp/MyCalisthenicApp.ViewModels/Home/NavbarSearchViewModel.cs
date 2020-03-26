namespace MyCalisthenicApp.ViewModels.Home
{
    using System.ComponentModel.DataAnnotations;

    public class NavbarSearchViewModel
    {
        [Required]
        public string Text { get; set; }
    }
}
