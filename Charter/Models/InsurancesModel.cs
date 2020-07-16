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
        private int InsuranceId { get; set; }

        [Display(Name = "Company Name ")]
        private string CompanyName { get; set; }

        [Display(Name = "Due Date ")]
        private DateTime DueDate { get; set; }

        [Display(Name ="Amount Due ")]
        private double AmountDue { get; set; }

    }
}
