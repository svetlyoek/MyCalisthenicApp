namespace MyCalisthenicApp.Models.ShopEntities
{
    using MyCalisthenicApp.Data.Common.Models;
    using System.ComponentModel.DataAnnotations;

    public class Image : BaseDeletableEntity<int>
    {
        [Required]
        public string Url { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
