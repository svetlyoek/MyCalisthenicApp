namespace MyCalisthenicApp.Models
{
    using MyCalisthenicApp.Data.Common.Models;
    using System.ComponentModel.DataAnnotations;

    public abstract class ApplicationUser : BaseEntity<int>
    {
        [MaxLength(100)]
        public string FullName { get; set; }

        [EmailAddress]
        [MaxLength(30)]
        public string Email { get; set; }

        [MaxLength(20)]
        public string PhoneNumber { get; set; }

    }
}
