namespace MyCalisthenicApp.ViewModels.Programs
{
    using MyCalisthenicApp.ViewModels.Validations;
    using System.ComponentModel.DataAnnotations;

    public class HomePopularProgramsViewModel
    {
        [Required]
        public string Id { get; set; }

        [Required]
        [MaxLength(WebValidations.ProgramTitleMaxLength)]
        public string Title { get; set; }

        [Required]
        public string ImageUrl { get; set; }

    }

}

