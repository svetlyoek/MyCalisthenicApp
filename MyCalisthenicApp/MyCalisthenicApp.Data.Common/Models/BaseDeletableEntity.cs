namespace MyCalisthenicApp.Data.Common.Models
{
    using System;

    using MyCalisthenicApp.Data.Common.Contracts;

    public class BaseDeletableEntity<TKey> : BaseEntity<TKey>, IDeletableEntity
    {
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
