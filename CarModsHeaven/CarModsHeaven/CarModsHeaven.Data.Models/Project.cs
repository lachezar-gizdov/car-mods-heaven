using CarModsHeaven.Data.Models.Abstracts;
using CarModsHeaven.Data.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace CarModsHeaven.Data.Models
{
    public class Project : BaseDataModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string CarBrand { get; set; }

        [Required]
        public string CarModel { get; set; }

        public ModificationsType ModificationsType { get; set; }

        [Required]
        public int CarYear { get; set; }

        [Required]
        public string ShortStory { get; set; }

        public virtual User Owner { get; set; }
    }
}
