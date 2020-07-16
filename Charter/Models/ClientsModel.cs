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
        private int ClientId { get; set; }

        [Display(Name = "First Name ")]
        private string FirstName { get; set; }

        [Display(Name = "Last Name ")]
        private string LastName { get; set; }

        [Display(Name = "Email Address ")]
        private string EmailAddress { get; set; }

        [Display(Name = "Telephone ")]
        private string Telephone { get; set; }

        [ForeignKey("AddressId")]
        public int? AddressId { get; set; }
        public AddressModel AddressModel { get; set; }

        [ForeignKey("CaptainId")]
        public int? CaptainId { get; set; }
        public CaptainsModel CaptainsModel { get; set; }
    }
}
