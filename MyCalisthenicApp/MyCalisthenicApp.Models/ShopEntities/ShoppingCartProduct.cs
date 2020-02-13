namespace MyCalisthenicApp.Models.ShopEntities
{
    using System.ComponentModel.DataAnnotations;

    public class ShoppingCartProduct
    {
        public int ShoppingCartId { get; set; }

        public virtual ShoppingCart ShoppingCart { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        [Range(DataValidations.ShoppingCartProductQuantityMinValue, DataValidations.ShoppingCartProductQuantityMaxValue)]
        public int? Quantity { get; set; }

    }
}
