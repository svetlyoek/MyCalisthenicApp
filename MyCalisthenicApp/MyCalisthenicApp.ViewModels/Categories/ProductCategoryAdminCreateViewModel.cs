namespace MyCalisthenicApp.ViewModels.Categories
{
    using System.ComponentModel.DataAnnotations;

    using MyCalisthenicApp.Models;

    public class ProductCategoryAdminCreateViewModel
    {
        [Required]
        [MaxLength(DataValidations.ProductCategoryNameMaxLength)]
        public string Name { get; set; }
    }
}
