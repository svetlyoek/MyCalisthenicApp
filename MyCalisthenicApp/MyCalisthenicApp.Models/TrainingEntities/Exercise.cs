namespace MyCalisthenicApp.Models.TrainingEntities
{
    using MyCalisthenicApp.Data.Common.Models;
    using System.ComponentModel.DataAnnotations;

    public class Exercise : BaseDeletableEntity<int>
    {
        [Required]
        [MaxLength(DataValidations.ExerciseNameMaxLength)]
        public string Name { get; set; }

        [MaxLength(DataValidations.ExerciseDescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public string VideoUrl { get; set; }

        public int ProgramSubCategoryId { get; set; }

        public virtual ProgramSubCategory SubCategory { get; set; }

    }
}
