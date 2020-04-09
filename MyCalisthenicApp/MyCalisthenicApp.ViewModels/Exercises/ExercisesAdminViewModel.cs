namespace MyCalisthenicApp.ViewModels.Exercises
{
    using System;
    using System.Collections.Generic;

    public class ExercisesAdminViewModel
    {
        public string Id { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public DateTime? CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string VideoUrl { get; set; }

        public string ProgramCategoryId { get; set; }

        public string ProgramCategoryName { get; set; }

        public List<string> ImagesUrl { get; set; }
    }
}
