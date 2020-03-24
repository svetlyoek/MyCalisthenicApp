namespace MyCalisthenicApp.Models.ShopEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using MyCalisthenicApp.Data.Common.Models;
    using MyCalisthenicApp.Models.ShopEntities.Enums;

    public class Order : BaseDeletableEntity<string>
    {
        public Order()
        {
            this.Id = Guid.NewGuid().ToString();
            this.IsDeleted = false;
            this.CreatedOn = DateTime.UtcNow;
            this.Products = new HashSet<OrderProduct>();
        }

        public OrderStatus? Status { get; set; }

        public PaymentStatus PaymentStatus { get; set; }

        public DateTime? EstimatedDeliveryDate { get; set; }

        public DateTime? DisptachDate { get; set; }

        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [Range(DataValidations.OrderTotalPriceMinValue, double.MaxValue)]
        public decimal TotalPrice { get; set; }

        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [Range(DataValidations.OrderMembershipTotalPriceMinValue, double.MaxValue)]
        public decimal? MembershipPrice { get; set; }

        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [Range(DataValidations.OrderTotalPriceMinValue, double.MaxValue)]
        public decimal? Discount { get; set; }

        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [Range(DataValidations.OrderTotalPriceMinValue, double.MaxValue)]
        public decimal? DeliveryPrice { get; set; }

        public string EasyPayNumber { get; set; }

        public PaymentType? PaymentType { get; set; }

        [Required]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public string DeliveryAddressId { get; set; }

        public virtual Address DeliveryAddress { get; set; }

        public virtual ICollection<OrderProduct> Products { get; set; }
    }
}
