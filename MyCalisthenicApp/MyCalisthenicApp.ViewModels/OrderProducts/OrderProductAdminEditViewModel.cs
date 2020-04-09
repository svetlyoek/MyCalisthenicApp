namespace MyCalisthenicApp.ViewModels.OrderProducts
{
    using System.ComponentModel.DataAnnotations;

    public class OrderProductAdminEditViewModel
    {
        [Required]
        public string OrderId { get; set; }

        [Required]
        public string ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }
    }
}
