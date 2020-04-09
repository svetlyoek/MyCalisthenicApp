namespace MyCalisthenicApp.ViewModels.Exercises
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using MyCalisthenicApp.Models;

    public class ExerciseAdminCreateViewModel
    {
        [Required]
        [MaxLength(DataValidations.ExerciseNameMaxLength)]
        public string Name { get; set; }

        [MaxLength(DataValidations.ExerciseDescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        public string VideoUrl { get; set; }

        [Required]
        public string ProgramCategoryId { get; set; }

        public IEnumerable<string> Categories { get; set; }
    }
}
