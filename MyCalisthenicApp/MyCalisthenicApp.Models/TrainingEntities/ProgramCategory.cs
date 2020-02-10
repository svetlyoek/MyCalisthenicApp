namespace MyCalisthenicApp.Models
{
    using MyCalisthenicApp.Data.Common.Models;
    using MyCalisthenicApp.Models.TrainingEntities;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ProgramCategory : BaseEntity<int>
    {
        public ProgramCategory()
        {
            this.Comments = new HashSet<Comment>();
        }

        [MaxLength(30)]
        public string Name { get; set; }

        public int? LikeCount { get; set; }

        public int SubCategoryId { get; set; }

        public virtual ProgramSubCategory SubCategory { get; set; }

        public ICollection<Comment> Comments { get; set; }

    }
}
