﻿using System.ComponentModel.DataAnnotations;

namespace ASP6_SinAuth.Models.ViewModels
{
    public class RoleModification
    {
        [Required]
        public string RoleName { get; set; }

        public string RoleId { get; set; }

        public string[] AddIds { get; set; }

        public string[]? DeleteIds { get; set; }
    }
}
