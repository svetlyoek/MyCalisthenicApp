namespace MyCalisthenicApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using MyCalisthenicApp.Data.Common.Models;
    using MyCalisthenicApp.Models.TrainingEntities;

    public class ProgramCategory : BaseDeletableEntity<string>
    {
        public ProgramCategory()
        {
            this.Id = Guid.NewGuid().ToString();
            this.IsDeleted = false;
            this.CreatedOn = DateTime.UtcNow;
            this.Comments = new HashSet<Comment>();
            this.Exercises = new HashSet<Exercise>();
            this.Programs = new HashSet<Program>();
        }

        [Required]
        [MaxLength(DataValidations.ProgramCategoryNameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(DataValidations.ProgramCategoryDescriptionMaxLength)]
        public string Description { get; set; }

        public int? LikeCount { get; set; }

        public virtual ICollection<Program> Programs { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<Exercise> Exercises { get; set; }
    }
}
