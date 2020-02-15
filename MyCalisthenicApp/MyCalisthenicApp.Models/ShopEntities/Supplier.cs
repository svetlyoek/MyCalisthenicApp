namespace MyCalisthenicApp.Models.ShopEntities
{
    using MyCalisthenicApp.Data.Common.Models;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Supplier : BaseDeletableEntity<string>
    {
        public Supplier()
        {
            this.CreatedOn = DateTime.UtcNow;
            this.IsDeleted = false;
            this.IsDefault = true;
        }

        [Required]
        [MaxLength(DataValidations.SupplierNameMaxLength)]
        public string Name { get; set; }

        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [Range(DataValidations.SupplierPriceMinValue, double.MaxValue)]
        public decimal PriceToHome { get; set; }

        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [Range(DataValidations.SupplierPriceMinValue, double.MaxValue)]
        public decimal PriceToOffice { get; set; }

        public bool IsDefault { get; set; }
    }
}
