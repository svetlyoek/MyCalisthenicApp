namespace MyCalisthenicApp.ViewModels.Addresses
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using MyCalisthenicApp.Models;
    using MyCalisthenicApp.ViewModels.Cities;

    public class AddressAdminEditViewModel
    {
        public string Id { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        [Required]
        [MaxLength(DataValidations.AddressCountryNameMaxLength)]
        public string Country { get; set; }

        [MaxLength(DataValidations.AddressDescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        [MaxLength(DataValidations.AddressStreetMaxLength)]
        public string Street { get; set; }

        [MaxLength(DataValidations.AddressBuildingNumberMaxLength)]
        public string BuildingNumber { get; set; }

        [Required]
        public string CityId { get; set; }

        public virtual CityAdminViewModel City { get; set; }

        public string UserId { get; set; }
    }
}
