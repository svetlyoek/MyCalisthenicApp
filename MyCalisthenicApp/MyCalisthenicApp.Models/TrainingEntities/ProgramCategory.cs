namespace MyCalisthenicApp.Models
{
    using MyCalisthenicApp.Data.Common.Models;
    using MyCalisthenicApp.Models.TrainingEntities;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ProgramCategory : BaseDeletableEntity<int>
    {
        public ProgramCategory()
        {
            this.IsDeleted = false;
            this.CreatedOn = DateTime.UtcNow;
            this.Comments = new HashSet<Comment>();
            this.SubCategories = new HashSet<ProgramSubCategory>();
        }

        [Required]
        [MaxLength(DataValidations.ProgramCategoryNameMaxLength)]
        public string Name { get; set; }

        public int? LikeCount { get; set; }

        public virtual Program Program { get; set; }

        public virtual ICollection<ProgramSubCategory> SubCategories { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

    }
}
