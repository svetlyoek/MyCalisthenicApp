namespace MyCalisthenicApp.ViewModels.Suppliers
{
    using System;

    public class SupplierAdminViewModel
    {
        public string Id { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public string Name { get; set; }

        public decimal PriceToHome { get; set; }

        public decimal PriceToOffice { get; set; }

        public string LogoUrl { get; set; }

        public bool IsDefault { get; set; }
    }
}
