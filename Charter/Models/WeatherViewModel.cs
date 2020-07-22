using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Charter.Models
{
    public class WeatherViewModel
    {
        [NotMapped]
        public string mainTemp { get; set; }
        [NotMapped]
        public string feelsLike { get; set; }
        [NotMapped]
        public string maxTemp { get; set; }
        [NotMapped]
        public string pressure { get; set; }
        [NotMapped]
        public string seaLevel { get; set; }
        [NotMapped]
        public string windSpeed { get; set; }
        [NotMapped]
        public string description { get; set; }
    }
}


