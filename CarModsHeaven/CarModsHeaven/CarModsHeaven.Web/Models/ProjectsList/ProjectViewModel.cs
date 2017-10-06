using System;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using CarModsHeaven.Data.Models;
using CarModsHeaven.Data.Models.Enums;
using CarModsHeaven.Web.Infrastructure;

namespace CarModsHeaven.Web.Models.ProjectsList
{
    public class ProjectViewModel : IMapFrom<Project>, IHaveCustomMappings
    {
        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        [Display(Name = "Project Title")]
        public string Title { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        [Display(Name = "Car Brand")]
        public string CarBrand { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        [Display(Name = "Car Model")]
        public string CarModel { get; set; }

        [Required]
        [Display(Name = "Car Year")]
        public int CarYear { get; set; }

        [Required]
        [Display(Name = "Modifications Type")]
        public ModificationsType ModificationsType { get; set; }

        [Required]
        [Display(Name = "Modifications List")]
        public string ModificationsList { get; set; }

        public User Owner { get; set; }

        public double Score { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? CreatedOn { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Project, ProjectViewModel>()
                .ForMember(projectViewModel => projectViewModel.Owner, cfg => cfg.MapFrom(project => project.Owner))
                .ForMember(projectViewModel => projectViewModel.CreatedOn, cfg => cfg.MapFrom(project => project.CreatedOn));
        }
    }
}