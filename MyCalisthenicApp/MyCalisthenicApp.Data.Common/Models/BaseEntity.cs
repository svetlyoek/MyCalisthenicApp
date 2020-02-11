namespace MyCalisthenicApp.Data.Common.Models
{
    using MyCalisthenicApp.Data.Common.Contracts;
    using System;
    using System.ComponentModel.DataAnnotations;

    public abstract class BaseEntity<TKey> : IAuditInfo
    {
        [Key]
        public TKey Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
