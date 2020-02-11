namespace MyCalisthenicApp.Models.ShopEntities
{
    using MyCalisthenicApp.Data.Common.Models;
    using MyCalisthenicApp.Models.ShopEntities.Enums;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ProductCategory : BaseDeletableEntity<int>
    {
        public ProductCategory()
        {
            this.Products = new HashSet<Product>();
        }

        [Required]
        [MaxLength(DataValidations.ShopCategoryNameMaxLength)]
        public string Name { get; set; }

        public ProductSort Sort { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
