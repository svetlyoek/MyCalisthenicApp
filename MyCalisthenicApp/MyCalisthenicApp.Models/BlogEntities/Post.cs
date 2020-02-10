namespace MyCalisthenicApp.Models.BlogEntities
{
    using MyCalisthenicApp.Data.Common.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Post : BaseEntity<int>
    {
        public Post()
        {
            this.Comments = new HashSet<Comment>();
        }

        [MaxLength(100)]
        public string Title { get; set; }

        public int BlogUserId { get; set; }

        public virtual BlogUser Author { get; set; }

        public DateTime? PublishDate { get; set; }

        public int BlogCategoryId { get; set; }

        public virtual BlogCategory Category { get; set; }

        public int? Rating { get; set; }

        public string ImageUrl { get; set; }

        public string VideoUrl { get; set; }

        public string Description { get; set; }

        public bool IsPublic { get; set; }

        public bool IsDeleted { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
