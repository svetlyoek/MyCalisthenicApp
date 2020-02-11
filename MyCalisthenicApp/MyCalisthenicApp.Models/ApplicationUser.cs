namespace MyCalisthenicApp.Models
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using MyCalisthenicApp.Data.Common.Contracts;
    using MyCalisthenicApp.Models.BlogEntities;
    using MyCalisthenicApp.Models.ShopEntities;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public abstract class ApplicationUser : IdentityUser, IAuditInfo, IDeletableEntity
    {
        public ApplicationUser()
        {
            this.Posts = new HashSet<Post>();
            this.Addresses = new HashSet<Address>();
        }

        [Required]
        [MaxLength(DataValidations.ApplicationUserFullNameMaxLength)]
        public string FullName { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public int? ShoppingCartId { get; set; }

        public virtual ShoppingCart ShoppingCart { get; set; }

        public virtual ICollection<Post> Posts { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
    }
}
