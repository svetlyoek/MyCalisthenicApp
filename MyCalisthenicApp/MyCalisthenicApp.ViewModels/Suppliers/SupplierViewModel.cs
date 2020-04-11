namespace MyCalisthenicApp.ViewModels.Suppliers
{
    using System;

    public class SupplierViewModel
    {
        public string Name { get; set; }

        public DateTime CreatedOn { get; set; }

        public decimal PriceToHome { get; set; }

        public decimal PriceToOffice { get; set; }

        public string LogoUrl { get; set; }
    }
}
