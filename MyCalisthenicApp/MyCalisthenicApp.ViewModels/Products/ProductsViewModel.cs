namespace MyCalisthenicApp.ViewModels.Products
{
    using System;

    public class ProductsViewModel
    {
        public string Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public string ImageUrl { get; set; }

        public int? Rating { get; set; }

        public string Category { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Sort { get; set; }
    }
}
