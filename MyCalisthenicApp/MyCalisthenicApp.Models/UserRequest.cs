namespace MyCalisthenicApp.Models
{
    using MyCalisthenicApp.Data.Common.Models;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class UserRequest : BaseDeletableEntity<string>
    {
        public UserRequest()
        {
            this.IsDeleted = false;
            this.CreatedOn = DateTime.UtcNow;
            this.Seen = false;
        }

        [Required]
        [MaxLength(DataValidations.UserRequestFullNameMaxLength)]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        [Required]
        [MaxLength(DataValidations.UserRequestContentMaxLength)]
        public string Content { get; set; }

        public bool Seen { get; set; }

        public DateTime? PublishDate { get; set; }
    }
}
