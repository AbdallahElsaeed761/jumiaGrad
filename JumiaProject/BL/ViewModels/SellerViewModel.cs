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
    public class SellerViewModel
    {
        public string SellerId { get; set; }
        
        [DefaultValue(false)]
        public bool Isdeleted { get; set; }

        public virtual List<Inventory> Inventories { get; set; }
        public virtual List<Promotions> Promotions { get; set; }
        public string NationalCard { get; set; }
        public string Contract { get; set; }
        public string TaxCard { get; set; }
        public string CommercialRegistryCard { get; set; }

        [Required]
        public string StoreName { get; set; }
    }
}
