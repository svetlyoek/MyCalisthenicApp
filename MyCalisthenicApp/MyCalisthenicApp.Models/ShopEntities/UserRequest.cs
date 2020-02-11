namespace MyCalisthenicApp.Models.ShopEntities
{
    using MyCalisthenicApp.Data.Common.Models;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class UserRequest : BaseDeletableEntity<int>
    {
        [Required]
        [MaxLength(DataValidations.UserRequestNameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(DataValidations.UserRequestTitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MaxLength(DataValidations.UserRequestContentMaxLength)]
        public string Content { get; set; }

        public bool Seen { get; set; }

        public DateTime? PublishDate { get; set; }
    }
}
