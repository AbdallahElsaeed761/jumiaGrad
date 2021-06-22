using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ViewModels
{
     public class BrandSubCatViewmodel
    {
        [Required]
        public int BrandId { get; set; }
        [Required]
        public int SubCatId { get; set; }
    }
}
