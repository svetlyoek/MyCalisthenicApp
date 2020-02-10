namespace MyCalisthenicApp.Models.TrainingEntities
{
    using System.ComponentModel.DataAnnotations;

    public class Exercise : BaseEntity<int>
    {

        [MaxLength(30)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string Description { get; set; }

        public string Image { get; set; }

        public string Video { get; set; }

    }
}
