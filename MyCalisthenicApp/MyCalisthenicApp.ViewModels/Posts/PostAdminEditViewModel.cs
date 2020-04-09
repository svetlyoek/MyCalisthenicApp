namespace MyCalisthenicApp.ViewModels.Posts
{
    using MyCalisthenicApp.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Web.Mvc;

    public class PostAdminEditViewModel
    {
        public string Id { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        [Required]
        [MaxLength(DataValidations.PostTitleMaxLength)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public string AuthorId { get; set; }

        [Required]
        public string CategoryId { get; set; }

        public string CategoryName { get; set; }

        public bool CategoryIsDeleted { get; set; }

        public int? Rating { get; set; }

        public string Type { get; set; }

        public string VideoUrl { get; set; }

        public bool IsPublic { get; set; }

        [NotMapped]
        public IEnumerable<string> Categories { get; set; }
    }
}
