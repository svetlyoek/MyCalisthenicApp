namespace MyCalisthenicApp.ViewModels.Products
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.AspNetCore.Mvc;

    public class ProductsPageViewModel
    {
        public IEnumerable<ProductsViewModel> Products { get; set; }

        public int ProductPerPage { get; set; }

        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; }

        public int PageCount()
        {
            return Convert.ToInt32(Math.Ceiling(this.Products.Count() / (double)this.ProductPerPage));
        }

        public IEnumerable<ProductsViewModel> PaginatedProducts()
        {
            int start = (this.CurrentPage - 1) * this.ProductPerPage;

            return this.Products.Skip(start).Take(this.ProductPerPage);
        }
    }
}
