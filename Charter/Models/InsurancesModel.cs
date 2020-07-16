using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Charter.Models
{
    public class InsurancesModel
    {
        [Key]
        public int InsuranceId { get; set; }

        [Display(Name = "Company Name ")]
        public string CompanyName { get; set; }

        [Display(Name = "Due Date ")]
        public DateTime DueDate { get; set; }

        [Display(Name ="Amount Due ")]
        public double AmountDue { get; set; }

    }
}
