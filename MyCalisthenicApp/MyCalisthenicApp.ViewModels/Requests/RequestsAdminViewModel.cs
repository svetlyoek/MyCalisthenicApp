namespace MyCalisthenicApp.ViewModels.Requests
{
    using System;

    public class RequestsAdminViewModel
    {
        public string Id { get; set; }

        public DateTime? CreatedOn { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string Content { get; set; }

        public bool Seen { get; set; }
    }
}
