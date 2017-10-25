﻿using System.ComponentModel.DataAnnotations;

namespace CarModsHeaven.Web.Models.Account
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}