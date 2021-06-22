using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ViewModels
{
    public class InventoryproductViewModel
    {
        [Required]
        public int Quantity { get; set; }
        [DefaultValue(false)]
        public bool Isdeleted { get; set; }
        
        public int ProductId { get; set; }
        

     
        public int InventoryId { get; set; }
    }
}
