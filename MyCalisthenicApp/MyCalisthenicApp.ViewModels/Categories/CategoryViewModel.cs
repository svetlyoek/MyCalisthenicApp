namespace MyCalisthenicApp.ViewModels.Categories
{
    using System.Collections.Generic;

    using MyCalisthenicApp.ViewModels.Exercises;

    public class CategoryViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public int? LikeCount { get; set; }

        public IEnumerable<ExercisesViewModel> Exercises { get; set; }
    }
}
