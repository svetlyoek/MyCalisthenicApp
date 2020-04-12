namespace MyCalisthenicApp.ViewModels.Orders
{
    using System;
    using System.Collections.Generic;

    using MyCalisthenicApp.ViewModels.OrderProducts;

    public class OrdersViewModel
    {
        public DateTime? CreatedOn { get; set; }

        public string Status { get; set; }

        public string PaymentStatus { get; set; }

        public DateTime? EstimatedDeliveryDate { get; set; }

        public DateTime? DisptachDate { get; set; }

        public decimal TotalPrice { get; set; }

        public decimal? MembershipPrice { get; set; }

        public decimal? Discount { get; set; }

        public decimal? DeliveryPrice { get; set; }

        public string DeliveryAddressCountry { get; set; }

        public string DeliveryAddressDescription { get; set; }

        public string DeliveryAddressStreet { get; set; }

        public string DeliveryAddressBuildingNumber { get; set; }

        public string DeliveryAddressCityName { get; set; }

        public string DeliveryAddressCityPostCode { get; set; }

        public virtual ICollection<OrderProductsViewModel> Products { get; set; }
    }
}
