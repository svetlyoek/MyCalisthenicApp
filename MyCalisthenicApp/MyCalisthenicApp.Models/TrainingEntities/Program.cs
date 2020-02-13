namespace MyCalisthenicApp.Models
{
    using MyCalisthenicApp.Data.Common.Models;
    using MyCalisthenicApp.Models.Enums;
    using MyCalisthenicApp.Models.ShopEntities;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Program : BaseDeletableEntity<int>
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

        public int ImageId { get; set; }

        public Image Image { get; set; }

        public int CategoryId { get; set; }

        public virtual ProgramCategory Category { get; set; }

    }
}
