namespace MyCalisthenicApp.Models
{
    using MyCalisthenicApp.Data.Common.Models;
    using MyCalisthenicApp.Models.Enums;
    using MyCalisthenicApp.Models.ShopEntities;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Program : BaseDeletableEntity<string>
    {
        public Program()
        {
            this.IsDeleted = false;
            this.CreatedOn = DateTime.UtcNow;
            this.Images = new HashSet<Image>();
        }

        [Required]
        [MaxLength(DataValidations.ProgramTitleMaxLength)]
        public string Title { get; set; }

        public ProgramType Type { get; set; }

        [Required]
        [MaxLength(DataValidations.ProgramDescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        public string CategoryId { get; set; }

        public virtual ProgramCategory Category { get; set; }

        public virtual ICollection<Image> Images { get; set; }

    }
}
