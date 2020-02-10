namespace MyCalisthenicApp.Models.TrainingEntities
{
    using MyCalisthenicApp.Data.Common.Models;
    using MyCalisthenicApp.Models.TrainingEntities.Enums;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ProgramSubCategory : BaseEntity<int>
    {
        public ProgramSubCategory()
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
