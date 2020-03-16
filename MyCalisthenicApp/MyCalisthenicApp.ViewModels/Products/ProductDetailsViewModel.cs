namespace MyCalisthenicApp.ViewModels.Products
{
    using System.Collections.Generic;

    using MyCalisthenicApp.ViewModels.Comments;

    public class ProductDetailsViewModel
    {
        public string Id { get; set; }

        public IEnumerable<string> Images { get; set; }

        public string Description { get; set; }

        public bool IsSoldOut { get; set; }

        public IEnumerable<CommentViewModel> Comments { get; set; }

        public string Name { get; set; }

        public string Category { get; set; }

        public int? Rating { get; set; }

        public string Size { get; set; }

        public string Color { get; set; }

        public decimal Price { get; set; }
    }
}
