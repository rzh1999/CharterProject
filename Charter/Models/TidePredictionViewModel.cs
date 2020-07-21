using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Charter.Models
{
    public class TidePredictionViewModel
    {
        [NotMapped]
        public List<String> Time { get; set; }
        [NotMapped]
        public List<String> Height { get; set; }
        [NotMapped]
        public List<String> Tide { get; set; }
    }
}
