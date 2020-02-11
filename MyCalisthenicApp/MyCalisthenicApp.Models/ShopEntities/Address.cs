namespace MyCalisthenicApp.Models.ShopEntities
{
    using MyCalisthenicApp.Data.Common.Models;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Address : BaseDeletableEntity<int>
    {
        public Address()
        {
            this.Orders = new HashSet<Order>();
        }

        [Required]
        [MaxLength(DataValidations.AddressCountryNameMaxLength)]
        public string Country { get; set; }

        [MaxLength(DataValidations.AddressDescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        [MaxLength(DataValidations.AddressStreetMaxLength)]
        public string Street { get; set; }

        [Required]
        [MaxLength(DataValidations.AddressBuildingNumberMaxLength)]
        public string BuildingNumber { get; set; }

        public int CityId { get; set; }

        public virtual City City { get; set; }

        public int ApplicationUserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
