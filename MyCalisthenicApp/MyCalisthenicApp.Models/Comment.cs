namespace MyCalisthenicApp.Models
{
    using MyCalisthenicApp.Data.Common.Models;
    using MyCalisthenicApp.Models.BlogEntities;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Comment : BaseEntity<int>
    {
        [MaxLength(200)]
        public string Text { get; set; }

        [MaxLength(50)]
        public string AuthorName { get; set; }

        public DateTime? PublishDate { get; set; }

        public int PostId { get; set; }

        public Post Post { get; set; }

        public bool IsDeleted { get; set; }
    }
}
