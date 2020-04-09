namespace MyCalisthenicApp.ViewModels.Suppliers
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using MyCalisthenicApp.Models;

    public class SupplierAdminEditViewModel
    {
        public string Id { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        [Required]
        [MaxLength(DataValidations.SupplierNameMaxLength)]
        public string Name { get; set; }

        public decimal PriceToHome { get; set; }

        public decimal PriceToOffice { get; set; }

        public string LogoUrl { get; set; }

        public bool IsDefault { get; set; }
    }
}
