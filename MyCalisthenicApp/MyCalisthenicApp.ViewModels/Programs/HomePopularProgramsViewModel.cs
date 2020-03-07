namespace MyCalisthenicApp.ViewModels.Programs
{
    using System.ComponentModel.DataAnnotations;

    using MyCalisthenicApp.ViewModels.Validations;

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
