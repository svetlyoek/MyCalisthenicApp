namespace MyCalisthenicApp.Models
{
    using System;

    using MyCalisthenicApp.Data.Common.Models;

    public class Membership : BaseDeletableEntity<string>
    {
        public Membership()
        {
            this.Id = Guid.NewGuid().ToString();
            this.CreatedOn = DateTime.UtcNow;
            this.IsDeleted = false;
            this.MonthlyPrice = DataValidations.MembershipMonthlyPrice;
            this.YearlyPrice = DataValidations.MembershipYearlyPrice;
        }

        public string Name { get; set; }

        public decimal MonthlyPrice { get; set; }

        public decimal YearlyPrice { get; set; }
    }
}
