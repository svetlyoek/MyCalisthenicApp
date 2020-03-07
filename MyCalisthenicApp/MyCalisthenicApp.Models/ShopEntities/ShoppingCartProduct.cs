namespace MyCalisthenicApp.Models.ShopEntities
{
    using System.ComponentModel.DataAnnotations;

    public class ShoppingCartProduct
    {
        [Required]
        public string ShoppingCartId { get; set; }

        public virtual ShoppingCart ShoppingCart { get; set; }

        [Required]
        public string ProductId { get; set; }

        public virtual Product Product { get; set; }

        [Range(DataValidations.ShoppingCartProductQuantityMinValue, DataValidations.ShoppingCartProductQuantityMaxValue)]
        public int? Quantity { get; set; }
    }
}
