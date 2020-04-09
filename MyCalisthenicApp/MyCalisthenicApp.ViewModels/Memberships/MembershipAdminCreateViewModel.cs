namespace MyCalisthenicApp.ViewModels.Memberships
{
    using System.ComponentModel.DataAnnotations;

    using MyCalisthenicApp.Models;

    public class MembershipAdminCreateViewModel
    {
        [Required]
        [MaxLength(DataValidations.MembershipNameMaxLength)]
        public string Name { get; set; }

        [Range(DataValidations.MembershipPriceMinValue, double.MaxValue)]
        public decimal? MonthlyPrice { get; set; }

        [Range(DataValidations.MembershipPriceMinValue, double.MaxValue)]
        public decimal? YearlyPrice { get; set; }
    }
}
