using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ViewModels
{
     public class ReviewViewModel
    {
        public string CustomerId { get; set; }
       
        [Range(minimum: 0, maximum: 5)]
        public double? review { get; set; }
        public string comment { get; set; }
        public int ProductId { get; set; }
        [DefaultValue(false)]
        public bool Isdeleted { get; set; }
       
    }
}
