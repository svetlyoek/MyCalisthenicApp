namespace MyCalisthenicApp.ViewModels.Orders
{
    using System.ComponentModel.DataAnnotations;

    public class AddressInputViewModel
    {
        [Required]
        public string FullName { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string PostCode { get; set; }

        [Required]
        public string Address { get; set; }

        public string BuildingNumber { get; set; }

        public string DeliveryInstructions { get; set; }
    }
}
