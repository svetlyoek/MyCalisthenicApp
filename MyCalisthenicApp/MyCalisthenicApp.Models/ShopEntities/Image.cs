namespace MyCalisthenicApp.Models.ShopEntities
{
    using MyCalisthenicApp.Data.Common.Models;
    using MyCalisthenicApp.Models.BlogEntities;
    using MyCalisthenicApp.Models.TrainingEntities;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Image : BaseDeletableEntity<string>
    {
        public Image()
        {
            this.IsDeleted = false;
            this.CreatedOn = DateTime.UtcNow;
        }

        [Required]
        public string Url { get; set; }

        public string ProductId { get; set; }

        public virtual Product Product { get; set; }

        public string PostId { get; set; }

        public virtual Post Post { get; set; }

        public string ExerciseId { get; set; }

        public virtual Exercise Exercise { get; set; }

        public string ProgramId { get; set; }

        public virtual Program Program { get; set; }

    }
}
