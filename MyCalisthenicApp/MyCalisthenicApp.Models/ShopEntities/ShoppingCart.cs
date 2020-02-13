namespace MyCalisthenicApp.Models.ShopEntities
{
    using MyCalisthenicApp.Data.Common.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ShoppingCart : BaseDeletableEntity<int>
    {
        public ShoppingCart()
        {
            this.IsDeleted = false;
            this.CreatedOn = DateTime.UtcNow;
            this.Products = new HashSet<ShoppingCartProduct>();
        }

        [Required]
        [MaxLength(DataValidations.ShoppingCartNumberMaxLength)]
        public string CardNumber { get; set; }

        [Required]
        [MaxLength(DataValidations.ShoppingCartCVVMaxLength)]
        public string CVV { get; set; }

        public DateTime ExpirationDate { get; set; }

        public ApplicationUser User { get; set; }

        public virtual ICollection<ShoppingCartProduct> Products { get; set; }
    }
}
