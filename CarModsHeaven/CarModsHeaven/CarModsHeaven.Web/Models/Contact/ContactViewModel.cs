using System.ComponentModel.DataAnnotations;

namespace CarModsHeaven.Web.Models.Contact
{
    public class ContactViewModel
    {
        [Required]
        [Display(Name = "Full Name")]
        [StringLength(20, MinimumLength = 5)]
        public string SenderName { get; set; }

        [Required]
        [EmailAddress]
        public string SenderEmail { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        public string Content { get; set; }
    }
}