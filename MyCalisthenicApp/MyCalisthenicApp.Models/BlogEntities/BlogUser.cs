namespace MyCalisthenicApp.Models.BlogEntities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class BlogUser : ApplicationUser
    {
        public BlogUser()
        {
            this.Posts = new HashSet<Post>();
        }

        [MaxLength(50)]
        public string Username { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}
