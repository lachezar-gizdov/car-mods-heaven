using CarModsHeaven.Data.Models;
using CarModsHeaven.Web.Infrastructure;
using System.ComponentModel.DataAnnotations;
using AutoMapper;

namespace CarModsHeaven.Web.Models.Contact
{
    public class ContactViewModel : IMapFrom<ContactEmail>, IHaveCustomMappings
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

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<ContactEmail, ContactViewModel>()
                .ForMember(contactViewModel => contactViewModel.SenderName, cfg => cfg.MapFrom(contactEmail => contactEmail.SenderName))
                .ForMember(contactViewModel => contactViewModel.SenderEmail, cfg => cfg.MapFrom(contactEmail => contactEmail.SenderEmail));
        }
    }
}