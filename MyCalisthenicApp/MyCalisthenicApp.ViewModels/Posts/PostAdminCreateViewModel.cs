namespace MyCalisthenicApp.ViewModels.Posts
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using MyCalisthenicApp.Models;
    using MyCalisthenicApp.Models.BlogEntities.Enums;

    public class PostAdminCreateViewModel
    {
        [Required]
        [MaxLength(DataValidations.PostTitleMaxLength)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string AuthorId { get; set; }

        [Required]
        public string CategoryId { get; set; }

        public int? Rating { get; set; }

        public CategoryType? Type { get; set; }

        public string VideoUrl { get; set; }

        public IEnumerable<string> Categories { get; set; }
    }
}
