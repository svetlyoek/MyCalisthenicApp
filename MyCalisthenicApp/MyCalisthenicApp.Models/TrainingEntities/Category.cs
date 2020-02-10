namespace MyCalisthenicApp.Models
{
    using MyCalisthenicApp.Models.TrainingEntities;
    using System.ComponentModel.DataAnnotations;

    public class Category : BaseEntity<int>
    {

        [MaxLength(30)]
        public string Name { get; set; }

        public int? CommentCount { get; set; }

        public int? LikeCount { get; set; }

        public int SubCategoryId { get; set; }

        public virtual SubCategory SubCategory { get; set; }
    }
}
