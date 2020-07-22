using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Charter.Models
{
    public class BaitsModel
    {
        [Key]
        public int BaitId { get; set; }

        [Display(Name = "Bait Type ")]
        public string BaitType { get; set; }

        [Display(Name = "Bait Cost ")]
        public double BaitCost { get; set; }

        [Display(Name = "Bait Price ")]
        public double BaitPrice { get; set; }

        [Display(Name = "Price Per Dz. ")]
        public double PricePerDozen { get; set; }

        [Display(Name = "Death Count ")]
        public int DeathCount { get; set; }

        [Display(Name = "Amount In Thousands")]
        public int Amount { get; set; }

        [ForeignKey("CaptainsModel")]
        public int? CaptainId { get; set; }
        public CaptainsModel CaptainsModel { get; set; }


    }
}
