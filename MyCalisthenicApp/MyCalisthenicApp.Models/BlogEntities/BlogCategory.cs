namespace MyCalisthenicApp.Models.BlogEntities
{
    using MyCalisthenicApp.Data.Common.Models;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class BlogCategory : BaseEntity<int>
    {
        public BlogCategory()
        {
            this.Posts = new HashSet<Post>();
        }
        [MaxLength(50)]
        public string Name { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}
