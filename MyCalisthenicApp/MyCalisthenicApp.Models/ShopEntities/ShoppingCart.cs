namespace MyCalisthenicApp.Models.ShopEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using MyCalisthenicApp.Data.Common.Models;

    public class ShoppingCart : BaseDeletableEntity<string>
    {
        public ShoppingCart()
        {
            this.Id = Guid.NewGuid().ToString();
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
