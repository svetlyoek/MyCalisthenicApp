namespace MyCalisthenicApp.Models
{
    using MyCalisthenicApp.Data.Common.Models;
    using MyCalisthenicApp.Models.Enums;
    using MyCalisthenicApp.Models.ShopEntities;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Program : BaseDeletableEntity<string>
    {
        public Program()
        {
            this.IsDeleted = false;
            this.CreatedOn = DateTime.UtcNow;
        }

        public ProgramType Type { get; set; }

        [Required]
        [MaxLength(DataValidations.ProgramDescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        public string ImageId { get; set; }

        public Image Image { get; set; }

        [Required]
        public string CategoryId { get; set; }

        public virtual ProgramCategory Category { get; set; }

    }
}
