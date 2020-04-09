namespace MyCalisthenicApp.ViewModels.Orders
{
    using System;

    public class OrdersAdminViewModel
    {
        public string Id { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public DateTime? CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public string Status { get; set; }

        public string PaymentStatus { get; set; }

        public DateTime? EstimatedDeliveryDate { get; set; }

        public DateTime? DisptachDate { get; set; }

        public decimal TotalPrice { get; set; }

        public decimal? MembershipPrice { get; set; }

        public decimal? Discount { get; set; }

        public decimal? DeliveryPrice { get; set; }

        public string EasyPayNumber { get; set; }

        public string PaymentType { get; set; }

        public string UserId { get; set; }

        public string DeliveryAddressId { get; set; }
    }
}
