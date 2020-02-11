namespace MyCalisthenicApp.Models.ShopEntities
{
    using MyCalisthenicApp.Data.Common.Models;
    using MyCalisthenicApp.Models.ShopEntities.Enums;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Order : BaseDeletableEntity<int>
    {
        public Order()
        {
            this.Products = new HashSet<OrderProduct>();
        }

        public OrderStatus Status { get; set; }

        public PaymentStatus PaymentStatus { get; set; }

        public DateTime? OrderDate { get; set; }

        public DateTime? EstimatedDeliveryDate { get; set; }

        public DateTime? DisptachDate { get; set; }

        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [Range(DataValidations.OrderTotalPriceMinValue, double.MaxValue)]
        public decimal TotalPrice { get; set; }

        public decimal? Discount { get; set; }

        public decimal DeliveryPrice { get; set; }

        public string Recipient { get; set; }

        public string RecipientPhoneNumber { get; set; }

        public string InvoiceNumber { get; set; }

        public string EasyPayNumber { get; set; }

        public PaymentType PaymentType { get; set; }

        public int ApplicationUserId { get; set; }

        public ApplicationUser User { get; set; }

        public virtual ICollection<OrderProduct> Products { get; set; }

        public int AddressId { get; set; }

        public virtual Address DeliveryAddress { get; set; }
    }
}
