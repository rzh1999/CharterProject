using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Charter.Models
{
    public class MessagesModel
    {
        [Key]
        public int MessageId { get; set; }

        [Display(Name ="Screen Name: ")]
        public string ScreenName { get; set; }
        public string Message { get; set; }
    }
}
