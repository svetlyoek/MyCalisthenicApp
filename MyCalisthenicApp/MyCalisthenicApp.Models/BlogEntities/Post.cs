namespace MyCalisthenicApp.Models.BlogEntities
{
    using MyCalisthenicApp.Data.Common.Models;
    using MyCalisthenicApp.Models.ShopEntities;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Post : BaseDeletableEntity<string>
    {
        public Post()
        {
            this.PublishDate = DateTime.UtcNow;
            this.IsPublic = true;
            this.IsDeleted = false;
            this.Comments = new HashSet<Comment>();
        }

        [Required]
        [MaxLength(DataValidations.PostTitleMaxLength)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public DateTime PublishDate { get; set; }

        [Required]
        public string CategoryId { get; set; }

        public virtual BlogCategory Category { get; set; }

        public string ImageId { get; set; }

        public virtual Image Image { get; set; }

        public string VideoUrl { get; set; }

        public bool IsPublic { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
