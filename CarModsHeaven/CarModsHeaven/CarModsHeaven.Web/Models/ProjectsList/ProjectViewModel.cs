using CarModsHeaven.Data.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace CarModsHeaven.Web.Models.ProjectsList
{
    public class ProjectViewModel
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

        public string OwnerEmail { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? CreatedOn { get; set; }
    }
}