namespace MyCalisthenicApp.ViewModels.Cities
{
    using System.ComponentModel.DataAnnotations;

    using MyCalisthenicApp.Models;

    public class CityAdminViewModel
    {
        public string Id { get; set; }

        [Required]
        [MaxLength(DataValidations.CityNameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(DataValidations.CityPostCodeMaxLength)]
        public string PostCode { get; set; }
    }
}
