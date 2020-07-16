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
        private int CaptainId { get; set; }

        [Display(Name = "First Name ")]
        private string FirstName { get; set; }

        [Display(Name = "Last Name ")]
        private string LastName { get; set; }

        [Display(Name = "Business Name")]
        private string BusinessName { get; set; }

        [Display(Name = "Adress ")]
        private string Address { get; set; }

        [Display(Name = "City ")]
        private string City { get; set; }

        [Display(Name = "State ")]
        private string State { get; set; }

        [Display(Name = "Zip Code ")]
        private string ZipCode { get; set; }

        [Display(Name = "Lattitude ")]
        private double Lattitude;

        [Display(Name = "Longitude ")]
        private double Longitude { get; set; }

        [ForeignKey("IdentityUser")]
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }
    }
}
