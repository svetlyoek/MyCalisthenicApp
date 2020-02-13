namespace MyCalisthenicApp.Models.TrainingEntities
{
    using MyCalisthenicApp.Data.Common.Models;
    using MyCalisthenicApp.Models.ShopEntities;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Exercise : BaseDeletableEntity<int>
    {
        public Exercise()
        {
            this.IsDeleted = false;
            this.CreatedOn = DateTime.UtcNow;
        }

        [Required]
        [MaxLength(DataValidations.ExerciseNameMaxLength)]
        public string Name { get; set; }

        [MaxLength(DataValidations.ExerciseDescriptionMaxLength)]
        public string Description { get; set; }

        public int ImageId { get; set; }

        public virtual Image Image { get; set; }

        [Required]
        public string VideoUrl { get; set; }

        public int ProgramSubCategoryId { get; set; }

        public virtual ProgramSubCategory ProgramSubCategory { get; set; }

    }
}
