using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ViewModels
{
     public class BrandViewModel
    {
        
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public string BrandName { get; set; }
    }
}
