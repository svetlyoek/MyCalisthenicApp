namespace MyCalisthenicApp.ViewModels.Images
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ImageAdminCreateViewModel
    {
        [Required]
        public string Url { get; set; }

        public string ProductId { get; set; }

        public string PostId { get; set; }

        public string ExerciseId { get; set; }

        public string ProgramId { get; set; }

        public IEnumerable<string> Products { get; set; }

        public IEnumerable<string> Posts { get; set; }

        public IEnumerable<string> Exercises { get; set; }

        public IEnumerable<string> Programs { get; set; }
    }
}
