namespace MyCalisthenicApp.Web.ViewModels.Programs
{
    using MyCalisthenicApp.Web.Validations;
    using System.ComponentModel.DataAnnotations;

    public class HomePopularProgramsViewModel
    {

        [Required]
        [MaxLength(WebValidations.ProgramTitleMaxLength)]
        public string Title { get; set; }

        [Required]
        public string ImageUrl { get; set; }

    }

}

