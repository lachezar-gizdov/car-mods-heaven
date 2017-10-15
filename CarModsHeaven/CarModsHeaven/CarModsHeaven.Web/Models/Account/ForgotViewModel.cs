using System.ComponentModel.DataAnnotations;

namespace CarModsHeaven.Web.Models.Contact
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}