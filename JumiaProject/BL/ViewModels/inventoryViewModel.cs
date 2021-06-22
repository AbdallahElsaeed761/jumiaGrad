using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ViewModels
{
    public class inventoryViewModel
    {
        public int InventoryId { get; set; }
        
        [Required]
        public string City { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string BuildingNumber { get; set; }

        
        public string sellerId { get; set; }
        
        public bool Isdeleted { get; set; }
    }
}
