﻿using System.ComponentModel.DataAnnotations;

namespace CarModsHeaven.Web.Models.Account
{
    public class ContactViewModel
    {
        [Required]
        [StringLength(20, MinimumLength = 5)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        public string Message { get; set; }
    }
}