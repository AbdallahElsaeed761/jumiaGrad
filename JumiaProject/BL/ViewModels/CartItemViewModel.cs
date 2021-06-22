using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ViewModels
{
    public class CartItemViewModel
    {
        public int CartItemId { get; set; }
        [Required]
        public int Quantity { get; set; }
        public float TotalPrice { get; set; }

       
        public int ProductId { get; set; }
        

        
        public int CartId { get; set; }
        [DefaultValue(false)]
        public bool Isdeleted { get; set; }
      
    }
}
