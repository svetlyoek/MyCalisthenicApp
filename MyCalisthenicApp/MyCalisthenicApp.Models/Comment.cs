namespace MyCalisthenicApp.Models
{
    using MyCalisthenicApp.Data.Common.Models;
    using MyCalisthenicApp.Models.BlogEntities;
    using MyCalisthenicApp.Models.ShopEntities;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Comment : BaseDeletableEntity<string>
    {
        public Comment()
        {
            this.IsDeleted = false;
            this.CreatedOn = DateTime.UtcNow;
        }

        [Required]
        [MaxLength(DataValidations.CommentTextMaxLength)]
        public string Text { get; set; }

        [Required]
        public string AuthorId { get; set; }

        public ApplicationUser Author { get; set; }

        public int? Rating { get; set; }

        public string PostId { get; set; }

        public virtual Post Post { get; set; }

        public string ProductId { get; set; }

        public virtual Product Product { get; set; }

        public string CategoryId { get; set; }

        public virtual ProgramCategory Category { get; set; }

    }
}
