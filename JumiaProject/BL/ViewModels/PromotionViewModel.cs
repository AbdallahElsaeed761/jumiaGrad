using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ViewModels
{
    public class PromotionViewModel
    {
        public int PromotionsId { get; set; }

        [Range(1, 100)]
        [Required]
        public float Discount { get; set; } // in precentage
        [Required]
        public string Description { get; set; }
        public string Image { get; set; }


        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [DefaultValue(false)]
        public bool Status { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string StatusControlled { get; set; }





        [DefaultValue(false)]
        public bool Isdeleted { get; set; }

       
        public string SellerId { get; set; }
       

        public virtual List<Product> Products { get; set; }
    }
}
