namespace MyCalisthenicApp.Models.ShopEntities
{
    using System.ComponentModel.DataAnnotations;

    public class OrderProduct
    {
        [Required]
        public string OrderId { get; set; }

        public virtual Order Order { get; set; }

        [Required]
        public string ProductId { get; set; }

        public virtual Product Product { get; set; }

        public int Quantity { get; set; }

        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [Range(DataValidations.OrderProductPriceMinValue, double.MaxValue)]
        public decimal Price { get; set; }
    }
}
