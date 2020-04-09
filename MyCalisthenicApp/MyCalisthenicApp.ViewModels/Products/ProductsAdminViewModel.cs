namespace MyCalisthenicApp.ViewModels.Products
{
    using System;
    using System.Collections.Generic;

    public class ProductsAdminViewModel
    {
        public string Id { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public DateTime? CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Size { get; set; }

        public string Color { get; set; }

        public string Sort { get; set; }

        public string Type { get; set; }

        public int? Rating { get; set; }

        public string Description { get; set; }

        public bool IsSoldOut { get; set; }

        public string CategoryId { get; set; }

        public string CategoryName { get; set; }

        public List<string> ImagesUrl { get; set; }
    }
}
