namespace MyCalisthenicApp.Models.TrainingEntities
{
    using MyCalisthenicApp.Models.TrainingEntities.Enums;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class SubCategory : BaseEntity<int>
    {
        public SubCategory()
        {
            this.Exercises = new HashSet<Exercise>();
        }


        [MaxLength(30)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string Description { get; set; }

        public MembershipType MembershipType { get; set; }

        public virtual ICollection<Exercise> Exercises { get; set; }
    }
}
