namespace MyCalisthenicApp.Models.BlogEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using MyCalisthenicApp.Data.Common.Models;
    using MyCalisthenicApp.Models.BlogEntities.Enums;
    using MyCalisthenicApp.Models.ShopEntities;

    public class Post : BaseDeletableEntity<string>
    {
        public Post()
        {
            this.Id = Guid.NewGuid().ToString();
            this.CreatedOn = DateTime.UtcNow;
            this.IsPublic = true;
            this.IsDeleted = false;
            this.Comments = new HashSet<Comment>();
            this.Images = new HashSet<Image>();
            this.LikesUsersNames = new List<string>();
        }

        [Required]
        [MaxLength(DataValidations.PostTitleMaxLength)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        [Required]
        public string CategoryId { get; set; }

        public virtual BlogCategory Category { get; set; }

        public int? Rating { get; set; }

        public CategoryType? Type { get; set; }

        public string VideoUrl { get; set; }

        public bool IsPublic { get; set; }

        public List<string> LikesUsersNames { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<Image> Images { get; set; }
    }
}
