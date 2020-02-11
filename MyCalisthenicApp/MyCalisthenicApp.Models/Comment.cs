namespace MyCalisthenicApp.Models
{
    using MyCalisthenicApp.Data.Common.Models;
    using MyCalisthenicApp.Models.BlogEntities;
    using MyCalisthenicApp.Models.ShopEntities;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Comment : BaseDeletableEntity<int>
    {
        [Required]
        [MaxLength(DataValidations.CommentTextMaxLength)]
        public string Text { get; set; }

        public ApplicationUser Author { get; set; }

        public DateTime? PublishDate { get; set; }

        public int? Rating { get; set; }

        public int? PostId { get; set; }

        public virtual Post Post { get; set; }

        public int? ProductId { get; set; }

        public virtual Product Product { get; set; }

    }
}
