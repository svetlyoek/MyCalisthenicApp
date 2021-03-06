﻿namespace MyCalisthenicApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Identity;
    using MyCalisthenicApp.Data.Common.Contracts;
    using MyCalisthenicApp.Models.BlogEntities;
    using MyCalisthenicApp.Models.ShopEntities;

    public class ApplicationUser : IdentityUser, IAuditInfo, IDeletableEntity
    {
        public ApplicationUser()
        {
            this.Roles = new HashSet<IdentityUserRole<string>>();
            this.Claims = new HashSet<IdentityUserClaim<string>>();
            this.Logins = new HashSet<IdentityUserLogin<string>>();

            this.Id = Guid.NewGuid().ToString();
            this.IsDeleted = false;
            this.HasMembership = false;
            this.HasCoupon = false;
            this.CreatedOn = DateTime.UtcNow;
            this.Posts = new HashSet<Post>();
            this.Addresses = new HashSet<Address>();
            this.Orders = new HashSet<Order>();
            this.Comments = new HashSet<Comment>();
        }

        [Required]
        [MaxLength(DataValidations.ApplicationUserFirstNameMaxLength)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(DataValidations.ApplicationUserLastNameMaxLength)]
        public string LastName { get; set; }

        public bool IsDeleted { get; set; }

        public bool HasMembership { get; set; }

        public bool HasCoupon { get; set; }

        public bool HasSubscribe { get; set; }

        public DateTime? MembershipExpirationDate { get; set; }

        public DateTime? DeletedOn { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public string ShoppingCartId { get; set; }

        public virtual ShoppingCart ShoppingCart { get; set; }

        public virtual ICollection<Post> Posts { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }

        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }

        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }
    }
}
