namespace MyCalisthenicApp.ViewModels.Images
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class ImageAdminEditViewModel
    {
        public string Id { get; set; }

        [Required]
        public string Url { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public string ProductId { get; set; }

        public string PostId { get; set; }

        public string ExerciseId { get; set; }

        public string ProgramId { get; set; }

        [NotMapped]
        public IEnumerable<string> Posts { get; set; }

        [NotMapped]
        public IEnumerable<string> Products { get; set; }

        [NotMapped]
        public IEnumerable<string> Programs { get; set; }

        [NotMapped]
        public IEnumerable<string> Exercises { get; set; }
    }
}
