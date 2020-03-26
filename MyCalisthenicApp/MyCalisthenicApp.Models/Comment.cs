namespace MyCalisthenicApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using MyCalisthenicApp.Data.Common.Models;
    using MyCalisthenicApp.Models.BlogEntities;
    using MyCalisthenicApp.Models.ShopEntities;

    public class Comment : BaseDeletableEntity<string>
    {
        public Comment()
        {
            this.Id = Guid.NewGuid().ToString();
            this.IsDeleted = false;
            this.CreatedOn = DateTime.UtcNow;
            this.LikesUsersNames = new List<string>();
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

        public string ProgramId { get; set; }

        public virtual Program Program { get; set; }

        public List<string> LikesUsersNames { get; set; }
    }
}
