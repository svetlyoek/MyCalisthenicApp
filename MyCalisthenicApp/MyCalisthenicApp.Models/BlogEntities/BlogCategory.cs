namespace MyCalisthenicApp.Models.BlogEntities
{
    using MyCalisthenicApp.Data.Common.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class BlogCategory : BaseDeletableEntity<int>
    {
        public BlogCategory()
        {
            this.IsDeleted = false;
            this.CreatedOn = DateTime.UtcNow;
            this.Posts = new HashSet<Post>();
        }

        [Required]
        [MaxLength(DataValidations.BlogCategoryNameMaxLength)]
        public string Name { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}
