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
        private int BoatId { get; set; }

        [Display(Name = "Make ")]
        private string BoatMake { get; set; }

        [Display(Name = "Model ")]
        private string Model { get; set; }

        [Display(Name = "Engine ")]
        private string Engine { get; set; }

        [Display(Name = "Engine Hours ")]
        private int EngineHours { get; set; }

        [Display(Name = "Usage Amount ")]
        private int UsageAmountHours { get; set; }

        [Display(Name = "Gas Costs ")]
        private double GasCotst { get; set; }

        [Display(Name = "Fuel Capacity ")]
        private double FuelCapacity { get; set; }

        [ForeignKey("CaptainId")]

        public int? CaptainId { get; set; }
        public CaptainsModel CaptainsModel { get; set; }

        [ForeignKey("InsuranceId")]

        public int? InsuranceId { get; set; }
        public InsurancesModel InsurancesModel { get; set; }
    }
}
