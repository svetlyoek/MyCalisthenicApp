﻿namespace MyCalisthenicApp.ViewModels.Blogs
{
    using MyCalisthenicApp.ViewModels.Validations;
    using System.ComponentModel.DataAnnotations;

    public class CommentInputViewModel
    {
        [Required]
        [MaxLength(WebValidations.CommentMessageMaxLength)]
        public string Message { get; set; }

        [Required]
        [MaxLength(WebValidations.ContactFullNameMaxLength)]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}