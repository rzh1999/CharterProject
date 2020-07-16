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
        private int BaitId { get; set; }

        [Display(Name = "Bait Type ")]
        private string BaitType { get; set; }

        [Display(Name = "Cost ")]
        private double BaitCost { get; set; }

        [Display(Name = "Death Count ")]
        private int DeathCount { get; set; }

        [ForeignKey("CaptainId")]
        public int? CaptainId { get; set; }
        public CaptainsModel CaptainsModel { get; set; }


    }
}
