﻿namespace MyCalisthenicApp.Models.ShopEntities
{
    using MyCalisthenicApp.Data.Common.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Address : BaseDeletableEntity<string>
    {
        public Address()
        {
            this.CreatedOn = DateTime.UtcNow;
            this.IsDeleted = false;
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

        [Required]
        public string CityId { get; set; }

        public virtual City City { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}