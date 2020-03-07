namespace MyCalisthenicApp.Models.BlogEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using MyCalisthenicApp.Data.Common.Models;

    public class BlogCategory : BaseDeletableEntity<string>
    {
        public BlogCategory()
        {
            this.Id = Guid.NewGuid().ToString();
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
