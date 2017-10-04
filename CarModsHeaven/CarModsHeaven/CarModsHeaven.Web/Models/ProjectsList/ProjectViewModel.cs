using CarModsHeaven.Data.Models;
using CarModsHeaven.Data.Models.Enums;
using CarModsHeaven.Web.Infrastructure;
using System;
using System.ComponentModel.DataAnnotations;
using AutoMapper;

namespace CarModsHeaven.Web.Models.ProjectsList
{
    public class ProjectViewModel : IMapFrom<Project>, IHaveCustomMappings
    {
        [Display(Name = "Project Title")]
        public string Title { get; set; }

        [Display(Name = "Car Brand")]
        public string CarBrand { get; set; }

        [Display(Name = "Car Model")]
        public string CarModel { get; set; }

        [Display(Name = "Car Year")]
        public int CarYear { get; set; }

        [Display(Name = "Modifications Type")]
        public ModificationsType ModificationsType { get; set; }

        [Display(Name = "Short Story")]
        public string ShortStory { get; set; }

        public User Owner { get; set; }

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