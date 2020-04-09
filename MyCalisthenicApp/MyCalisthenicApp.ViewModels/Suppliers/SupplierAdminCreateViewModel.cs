namespace MyCalisthenicApp.ViewModels.Suppliers
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using MyCalisthenicApp.Models;

    public class SupplierAdminCreateViewModel
    {
        [Required]
        [MaxLength(DataValidations.SupplierNameMaxLength)]
        public string Name { get; set; }

        [Range(DataValidations.SupplierPriceMinValue, double.MaxValue)]
        public decimal PriceToHome { get; set; }

        [Range(DataValidations.SupplierPriceMinValue, double.MaxValue)]
        public decimal PriceToOffice { get; set; }

        public string LogoUrl { get; set; }
    }
}
