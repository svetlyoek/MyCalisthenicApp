namespace MyCalisthenicApp.Models.ShopEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using MyCalisthenicApp.Data.Common.Models;
    using MyCalisthenicApp.Models.ShopEntities.Enums;

    public class Product : BaseDeletableEntity<string>
    {
        public Product()
        {
            this.Id = Guid.NewGuid().ToString();
            this.IsSoldOut = false;
            this.IsDeleted = false;
            this.CreatedOn = DateTime.UtcNow;
            this.Images = new HashSet<Image>();
            this.Comments = new HashSet<Comment>();
            this.ShoppingCarts = new HashSet<ShoppingCartProduct>();
            this.Orders = new HashSet<OrderProduct>();
        }

        [Required]
        [MaxLength(DataValidations.ProductNameMaxLength)]
        public string Name { get; set; }

        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [Range(DataValidations.ProductPriceMinValue, double.MaxValue)]
        public decimal Price { get; set; }

        public ProductSize? Size { get; set; }

        public ProductColor? Color { get; set; }

        public ProductSort? Sort { get; set; }

        public ProductCategoryType? Type { get; set; }

        public int? Rating { get; set; }

        [Required]
        [MaxLength(DataValidations.ProductDescriptionMaxLength)]
        public string Description { get; set; }

        public bool IsSoldOut { get; set; }

        [Required]
        public string CategoryId { get; set; }

        public ProductCategory Category { get; set; }

        public virtual ICollection<ShoppingCartProduct> ShoppingCarts { get; set; }

        public virtual ICollection<Image> Images { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<OrderProduct> Orders { get; set; }
    }
}
