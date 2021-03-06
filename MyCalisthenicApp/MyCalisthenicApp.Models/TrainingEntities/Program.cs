﻿namespace MyCalisthenicApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using MyCalisthenicApp.Data.Common.Models;
    using MyCalisthenicApp.Models.Enums;
    using MyCalisthenicApp.Models.ShopEntities;
    using MyCalisthenicApp.Models.TrainingEntities.Enums;

    public class Program : BaseDeletableEntity<string>
    {
        public Program()
        {
            this.Id = Guid.NewGuid().ToString();
            this.IsDeleted = false;
            this.CreatedOn = DateTime.UtcNow;
            this.Images = new HashSet<Image>();
            this.Comments = new HashSet<Comment>();
            this.LikesUsersNames = new List<string>();
        }

        [Required]
        [MaxLength(DataValidations.ProgramTitleMaxLength)]
        public string Title { get; set; }

        public ProgramType Type { get; set; }

        [Required]
        [MaxLength(DataValidations.ProgramDescriptionMaxLength)]
        public string Description { get; set; }

        public int? Rating { get; set; }

        public MembershipType MembershipType { get; set; }

        [Required]
        public string CategoryId { get; set; }

        public virtual ProgramCategory Category { get; set; }

        public List<string> LikesUsersNames { get; set; }

        public virtual ICollection<Image> Images { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
