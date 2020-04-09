namespace MyCalisthenicApp.ViewModels.Programs
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using MyCalisthenicApp.Models;
    using MyCalisthenicApp.Models.Enums;
    using MyCalisthenicApp.Models.TrainingEntities.Enums;

    public class ProgramAdminCreateViewModel
    {
        [Required]
        [MaxLength(DataValidations.ProgramTitleMaxLength)]
        public string Title { get; set; }

        public ProgramType Type { get; set; }

        [Required]
        [MaxLength(DataValidations.ProgramDescriptionMaxLength)]
        public string Description { get; set; }

        public int? Rating { get; set; }

        public MembershipType MembershipType { get; set; }

        [Required]
        public string CategoryId { get; set; }

        public IEnumerable<string> Categories { get; set; }
    }
}
