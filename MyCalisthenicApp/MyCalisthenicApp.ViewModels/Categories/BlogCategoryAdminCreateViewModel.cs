namespace MyCalisthenicApp.ViewModels.Categories
{
    using System.ComponentModel.DataAnnotations;

    using MyCalisthenicApp.Models;

    public class BlogCategoryAdminCreateViewModel
    {
        [Required]
        [MaxLength(DataValidations.BlogCategoryNameMaxLength)]
        public string Name { get; set; }
    }
}
