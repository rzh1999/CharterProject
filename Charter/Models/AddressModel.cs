using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Charter.Models
{
    public class AddressModel
    {
        [Key]
        private int AddressId { get; set; }

        [Display(Name = "Address ")]
        private string Address { get; set; }

        [Display(Name = "City ")]
        private string City { get; set; }

        [Display(Name = "State ")]
        private string State { get; set; }

        [Display(Name = "Zip Code ")]
        private string ZipCode { get; set; }
    }
}
