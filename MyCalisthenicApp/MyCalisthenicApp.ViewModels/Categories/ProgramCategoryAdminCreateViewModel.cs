namespace MyCalisthenicApp.ViewModels.Categories
{
    using System.ComponentModel.DataAnnotations;

    using MyCalisthenicApp.Models;

    public class ProgramCategoryAdminCreateViewModel
    {
        [Required]
        [MaxLength(DataValidations.ProgramCategoryNameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(DataValidations.ProgramCategoryDescriptionMaxLength)]
        public string Description { get; set; }
    }
}
