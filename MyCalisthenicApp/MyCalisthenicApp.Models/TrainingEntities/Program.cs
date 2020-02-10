namespace MyCalisthenicApp.Models
{
    using MyCalisthenicApp.Models.Enums;
    using System.ComponentModel.DataAnnotations;

    public class Program : BaseEntity<int>
    {

        public ProgramType Type { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        public string Image { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

    }
}
