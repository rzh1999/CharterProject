using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Charter.Models
{
    public class ClientsModel
    {
        [Key]
        public int ClientId { get; set; }

        [Display(Name = "First Name ")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name ")]
        public string LastName { get; set; }

        [Display(Name = "Email Address ")]
        public string EmailAddress { get; set; }

        [Display(Name = "Telephone ")]
        public string Telephone { get; set; }

        [ForeignKey("AddressModel")]
        public int? AddressId { get; set; }
        public AddressModel AddressModel { get; set; }

        [ForeignKey("CaptainsModel")]
        public int? CaptainId { get; set; }
        public CaptainsModel CaptainsModel { get; set; }
    }
}
