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
        public int AddressId { get; set; }

        [Display(Name = "Address ")]
        public string Address { get; set; }

        [Display(Name = "City ")]
        public string City { get; set; }

        [Display(Name = "State ")]
        public string State { get; set; }

        [Display(Name = "Zip Code ")]
        public string ZipCode { get; set; }
    }
}
