namespace MyCalisthenicApp.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using MyCalisthenicApp.Data.Common.Models;

    public class Membership : BaseDeletableEntity<string>
    {
        public Membership()
        {
            this.Id = Guid.NewGuid().ToString();
            this.CreatedOn = DateTime.UtcNow;
            this.IsDeleted = false;
        }

        [Required]
        [MaxLength(DataValidations.MembershipNameMaxLength)]
        public string Name { get; set; }

        public decimal? MonthlyPrice { get; set; }

        public decimal? YearlyPrice { get; set; }
    }
}
