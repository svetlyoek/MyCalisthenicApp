namespace MyCalisthenicApp.ViewModels.Home
{
    using System.ComponentModel.DataAnnotations;

    public class SearchViewModel
    {
        [Required]
        public string Text { get; set; }
    }
}
