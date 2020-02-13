namespace MyCalisthenicApp.Models.TrainingEntities
{
    using MyCalisthenicApp.Data.Common.Models;
    using MyCalisthenicApp.Models.TrainingEntities.Enums;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ProgramSubCategory : BaseDeletableEntity<int>
    {
        public ProgramSubCategory()
        {
            this.CreatedOn = DateTime.UtcNow;
            this.IsDeleted = false;
            this.Exercises = new HashSet<Exercise>();
        }

        [Required]
        [MaxLength(DataValidations.ProgramSubCategoryNameMaxLength)]
        public string Name { get; set; }

        [MaxLength(DataValidations.ProgramSubCategoryDescriptionMaxLength)]
        public string Description { get; set; }

        public MembershipType MembershipType { get; set; }

        public int ProgramCategoryId { get; set; }

        public virtual ProgramCategory ProgramCategory { get; set; }

        public virtual ICollection<Exercise> Exercises { get; set; }
    }
}
