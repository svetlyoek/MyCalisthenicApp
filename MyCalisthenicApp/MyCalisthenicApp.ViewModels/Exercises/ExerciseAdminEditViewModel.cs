namespace MyCalisthenicApp.ViewModels.Exercises
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using MyCalisthenicApp.Models;

    public class ExerciseAdminEditViewModel
    {
        public string Id { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        [Required]
        [MaxLength(DataValidations.ExerciseNameMaxLength)]
        public string Name { get; set; }

        [MaxLength(DataValidations.ExerciseDescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        public string VideoUrl { get; set; }

        [Required]
        public string ProgramCategoryId { get; set; }

        public bool ProgramCategoryIsDeleted { get; set; }

        public string ProgramCategoryName { get; set; }

        public string ProgramCategoryDescription { get; set; }

        public int? ProgramCategoryRating { get; set; }

        [NotMapped]
        public IEnumerable<string> Categories { get; set; }
    }
}
