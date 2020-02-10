namespace MyCalisthenicApp.Data.Common.Models
{
    using MyCalisthenicApp.Data.Common.Contracts;
    using System;

    public abstract class BaseEntity<T> : IDeletableEntity
    {
        public T Id { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
