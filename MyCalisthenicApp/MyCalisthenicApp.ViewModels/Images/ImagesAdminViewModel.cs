namespace MyCalisthenicApp.ViewModels.Images
{
    using System;

    public class ImagesAdminViewModel
    {
        public string Id { get; set; }

        public string Url { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public string ProductId { get; set; }

        public string PostId { get; set; }

        public string ExerciseId { get; set; }

        public string ProgramId { get; set; }
    }
}
