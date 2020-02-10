namespace MyCalisthenicApp.Models.TrainingEntities
{
    using MyCalisthenicApp.Data.Common.Models;
    using System.ComponentModel.DataAnnotations;

    public class Exercise : BaseEntity<int>
    {

        [MaxLength(30)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public string VideoUrl { get; set; }

    }
}
