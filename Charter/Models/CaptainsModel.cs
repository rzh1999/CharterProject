using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Charter.Models
{
    public class CaptainsModel
    {
        [Key]
        public int CaptainId { get; set; }

        [Display(Name = "First Name ")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name ")]
        public string LastName { get; set; }

        [Display(Name = "Business Name")]
        public string BusinessName { get; set; }

        [Display(Name = "Adress ")]
        public string Address { get; set; }

        [Display(Name = "City ")]
        public string City { get; set; }

        [Display(Name = "State ")]
        public string State { get; set; }

        [Display(Name = "Zip Code ")]
        public string ZipCode { get; set; }

        [Display(Name = "Lattitude ")]
        public double Lattitude { get; set; }

        [Display(Name = "Longitude ")]
        public double Longitude { get; set; }

        [ForeignKey("IdentityUser")]
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }
    }
}
