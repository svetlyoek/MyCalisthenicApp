namespace MyCalisthenicApp.ViewModels.Programs
{
    using System;
    using System.Collections.Generic;

    public class ProgramsAdminViewModel
    {
        public string Id { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public string Title { get; set; }

        public string Type { get; set; }

        public string Description { get; set; }

        public int? Rating { get; set; }

        public string MembershipType { get; set; }

        public string CategoryId { get; set; }

        public string CategoryName { get; set; }

        public List<string> ImagesUrl { get; set; }
    }
}
