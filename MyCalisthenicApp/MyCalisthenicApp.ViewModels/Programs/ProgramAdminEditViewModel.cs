namespace MyCalisthenicApp.ViewModels.Programs
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using MyCalisthenicApp.Models;

    public class ProgramAdminEditViewModel
    {
        public string Id { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        [Required]
        [MaxLength(DataValidations.ProgramTitleMaxLength)]
        public string Title { get; set; }

        public string Type { get; set; }

        [Required]
        [MaxLength(DataValidations.ProgramDescriptionMaxLength)]
        public string Description { get; set; }

        public int? Rating { get; set; }

        public string MembershipType { get; set; }

        [Required]
        public string CategoryId { get; set; }

        public bool CategoryIsDeleted { get; set; }

        public string CategoryName { get; set; }

        public string CategoryDescription { get; set; }

        public int? CategoryRating { get; set; }

        [NotMapped]
        public IEnumerable<string> Categories { get; set; }
    }
}
