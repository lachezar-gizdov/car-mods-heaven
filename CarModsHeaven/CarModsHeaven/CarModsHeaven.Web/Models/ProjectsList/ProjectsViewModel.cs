using System;
using System.ComponentModel.DataAnnotations;

namespace CarModsHeaven.Web.Models.ProjectsList
{
    public class ProjectsViewModel
    {
        public string Title { get; set; }

        public string CarBrand { get; set; }

        public string CarModel { get; set; }

        public int CarYear { get; set; }

        public string ShortStory { get; set; }

        public string OwnerEmail { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? CreatedOn { get; set; }
    }
}