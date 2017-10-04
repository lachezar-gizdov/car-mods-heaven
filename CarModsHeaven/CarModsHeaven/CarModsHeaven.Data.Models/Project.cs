using System.ComponentModel.DataAnnotations;
using CarModsHeaven.Data.Models.Abstracts;
using CarModsHeaven.Data.Models.Enums;

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

        [Required]
        public int CarYear { get; set; }

        [Required]
        public ModificationsType ModificationsType { get; set; }

        [Required]
        public string ModificationsList { get; set; }

        public virtual User Owner { get; set; }
    }
}
