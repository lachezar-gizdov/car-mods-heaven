using CarModsHeaven.Data.Models.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarModsHeaven.Data.Models
{
    public class Project : BaseDataModel
    {
        public string Title { get; set; }

        public string CarBrand { get; set; }

        public string CarModel { get; set; }

        public int CarYear { get; set; }

        public string ShortStory { get; set; }

        public virtual User Owner { get; set; }
    }
}
