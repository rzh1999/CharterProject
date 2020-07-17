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

        [Display(Name = "Cost ")]
        public double BaitCost { get; set; }

        [Display(Name = "Death Count ")]
        public int DeathCount { get; set; }

        [ForeignKey("CaptainsModel")]
        public int? CaptainId { get; set; }
        public CaptainsModel CaptainsModel { get; set; }


    }
}
