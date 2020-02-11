namespace MyCalisthenicApp.Models.ShopEntities
{
    using MyCalisthenicApp.Data.Common.Models;
    using MyCalisthenicApp.Models.ShopEntities.Enums;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Product : BaseDeletableEntity<int>
    {
        public Product()
        {
            this.Images = new HashSet<Image>();
            this.Comments = new HashSet<Comment>();
            this.ShoppingCartProducts = new HashSet<ShoppingCartProduct>();
        }

        [Required]
        [MaxLength(DataValidations.ProductNameMaxLength)]
        public string Name { get; set; }

        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [Range(DataValidations.ProductPriceMinValue, double.MaxValue)]
        public decimal Price { get; set; }

        public ProductSize Size { get; set; }

        public ProductColor Color { get; set; }

        [Required]
        [MaxLength(DataValidations.ProductDescriptionMaxLength)]
        public string Description { get; set; }

        public bool IsSoldOut { get; set; }

        public int ProductCategoryId { get; set; }

        public ProductCategory Category { get; set; }

        public virtual ICollection<ShoppingCartProduct> ShoppingCartProducts { get; set; }

        public virtual ICollection<Image> Images { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
