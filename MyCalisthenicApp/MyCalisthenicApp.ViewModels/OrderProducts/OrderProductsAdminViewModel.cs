namespace MyCalisthenicApp.ViewModels.OrderProducts
{
    using MyCalisthenicApp.ViewModels.Products;

    public class OrderProductsAdminViewModel
    {
        public string OrderId { get; set; }

        public string ProductId { get; set; }

        public virtual OrderProductViewModel Product { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }
    }
}
