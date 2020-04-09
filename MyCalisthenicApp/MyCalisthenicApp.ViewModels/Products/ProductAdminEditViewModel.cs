namespace MyCalisthenicApp.ViewModels.Products
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using MyCalisthenicApp.Models;

    public class ProductAdminEditViewModel
    {
        public string Id { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        [Required]
        [MaxLength(DataValidations.ProductNameMaxLength)]
        public string Name { get; set; }

        public string CategoryName { get; set; }

        public bool CategoryIsDeleted { get; set; }

        public decimal Price { get; set; }

        public string Size { get; set; }

        public string Color { get; set; }

        public string Sort { get; set; }

        public string Type { get; set; }

        public int? Rating { get; set; }

        [Required]
        [MaxLength(DataValidations.ProductDescriptionMaxLength)]
        public string Description { get; set; }

        public bool IsSoldOut { get; set; }

        [Required]
        public string CategoryId { get; set; }

        [NotMapped]
        public IEnumerable<string> Categories { get; set; }
    }
}
