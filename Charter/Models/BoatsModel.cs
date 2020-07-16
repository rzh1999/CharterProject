using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Charter.Models
{
    public class BoatsModel
    {
        [Key]
        public int BoatId { get; set; }

        [Display(Name = "Make ")]
        public string BoatMake { get; set; }

        [Display(Name = "Model ")]
        public string Model { get; set; }

        [Display(Name = "Engine ")]
        public string Engine { get; set; }

        [Display(Name = "Engine Hours ")]
        public int EngineHours { get; set; }

        [Display(Name = "Usage Amount ")]
        public int UsageAmountHours { get; set; }

        [Display(Name = "Gas Costs ")]
        public double GasCotst { get; set; }

        [Display(Name = "Fuel Capacity ")]
        public double FuelCapacity { get; set; }

        [ForeignKey("CaptainId")]

        public int? CaptainId { get; set; }
        public CaptainsModel CaptainsModel { get; set; }

        [ForeignKey("InsuranceId")]

        public int? InsuranceId { get; set; }
        public InsurancesModel InsurancesModel { get; set; }
    }
}
