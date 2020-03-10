namespace MyCalisthenicApp.ViewModels.Programs
{
    using MyCalisthenicApp.ViewModels.Categories;

    public class ProgramDetailsViewModel
    {
        public string Id { get; set; }

        public string ImageUrl { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Type { get; set; }

        public string MembershipType { get; set; }

        public CategoryViewModel Category { get; set; }
    }
}
