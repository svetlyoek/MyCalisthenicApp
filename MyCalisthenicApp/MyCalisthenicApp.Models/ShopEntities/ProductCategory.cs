namespace MyCalisthenicApp.Models.ShopEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using MyCalisthenicApp.Data.Common.Models;

    public class ProductCategory : BaseDeletableEntity<string>
    {
        public ProductCategory()
        {
            this.Id = Guid.NewGuid().ToString();
            this.IsDeleted = false;
            this.CreatedOn = DateTime.UtcNow;
            this.Products = new HashSet<Product>();
        }

        [Required]
        [MaxLength(DataValidations.ShopCategoryNameMaxLength)]
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
