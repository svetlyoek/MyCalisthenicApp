namespace MyCalisthenicApp.ViewModels.Coupons
{
    using System.ComponentModel.DataAnnotations;

    public class CouponViewModel
    {
        [Required]
        public string Coupon { get; set; }
    }
}
