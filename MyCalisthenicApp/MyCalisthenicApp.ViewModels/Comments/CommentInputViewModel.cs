namespace MyCalisthenicApp.ViewModels.Comments
{
    using System.ComponentModel.DataAnnotations;

    public class CommentInputViewModel
    {
        [Required]
        public string Text { get; set; }

        public string Id { get; set; }
    }
}
