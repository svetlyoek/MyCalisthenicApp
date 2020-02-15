namespace MyCalisthenicApp.Models.ShopEntities
{
    using MyCalisthenicApp.Data.Common.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class City : BaseDeletableEntity<string>
    {
        public City()
        {
            this.IsDeleted = false;
            this.CreatedOn = DateTime.UtcNow;
            this.Addresses = new HashSet<Address>();
        }

        [Required]
        [MaxLength(DataValidations.CityNameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(DataValidations.CityPostCodeMaxLength)]
        public string PostCode { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }


    }
}
