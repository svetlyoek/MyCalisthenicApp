namespace MyCalisthenicApp.ViewModels.Addresses
{
    using System;

    using MyCalisthenicApp.ViewModels.Cities;

    public class AddressesAdminViewModel
    {
        public string Id { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public DateTime? CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public string Country { get; set; }

        public string Description { get; set; }

        public string Street { get; set; }

        public string BuildingNumber { get; set; }

        public string CityId { get; set; }

        public virtual CityAdminViewModel City { get; set; }

        public string UserId { get; set; }
    }
}
