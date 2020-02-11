using System.ComponentModel.DataAnnotations;

namespace MyCalisthenicApp.Models.ShopEntities
{
    public class OrderProduct
    {
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public int Quantity { get; set; }

        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [Range(DataValidations.OrderProductPriceMinValue, double.MaxValue)]
        public decimal Price { get; set; }

    }
}
