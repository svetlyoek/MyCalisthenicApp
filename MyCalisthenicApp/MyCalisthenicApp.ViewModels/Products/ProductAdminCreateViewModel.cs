namespace MyCalisthenicApp.ViewModels.Products
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using MyCalisthenicApp.Models;
    using MyCalisthenicApp.Models.ShopEntities.Enums;

    public class ProductAdminCreateViewModel
    {
        [Required]
        [MaxLength(DataValidations.ProductNameMaxLength)]
        public string Name { get; set; }

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

        [Required]
        public string CategoryId { get; set; }

        public IEnumerable<string> Categories { get; set; }
    }
}
