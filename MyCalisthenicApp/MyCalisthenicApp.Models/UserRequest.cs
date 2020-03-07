namespace MyCalisthenicApp.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using MyCalisthenicApp.Data.Common.Models;

    public class UserRequest : BaseDeletableEntity<string>
    {
        public UserRequest()
        {
            this.Id = Guid.NewGuid().ToString();
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

        [Required]
        [MaxLength(DataValidations.UserRequestContentMaxLength)]
        public string Content { get; set; }

        public bool Seen { get; set; }
    }
}
