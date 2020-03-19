namespace MyCalisthenicApp.ViewModels.Posts
{
    using System.ComponentModel.DataAnnotations;

    public class PostSearchViewModel
    {
        [Required]
        public string Text { get; set; }
    }
}
