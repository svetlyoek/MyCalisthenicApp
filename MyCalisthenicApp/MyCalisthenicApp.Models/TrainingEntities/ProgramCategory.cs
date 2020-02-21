namespace MyCalisthenicApp.Models
{
    using MyCalisthenicApp.Data.Common.Models;
    using MyCalisthenicApp.Models.TrainingEntities;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ProgramCategory : BaseDeletableEntity<string>
    {
        public ProgramCategory()
        {
            this.IsDeleted = false;
            this.CreatedOn = DateTime.UtcNow;
            this.Comments = new HashSet<Comment>();
            this.Exercises = new HashSet<Exercise>();
        }

        [Required]
        [MaxLength(DataValidations.ProgramCategoryNameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(DataValidations.ProgramCategoryDescriptionMaxLength)]
        public string Description { get; set; }

        public int? LikeCount { get; set; }

        public virtual Program Program { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<Exercise> Exercises { get; set; }

    }
}
