namespace MyCalisthenicApp.Data.Common.Models
{
    using MyCalisthenicApp.Data.Common.Contracts;
    using System;

    public class BaseDeletableEntity<TKey> : BaseEntity<TKey>, IDeletableEntity
    {
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
