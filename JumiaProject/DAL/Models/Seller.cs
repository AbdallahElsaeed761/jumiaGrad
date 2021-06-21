using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class Seller
    {
        [Key,ForeignKey("ApplicationUser")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string SellerId { get; set; }
        public virtual applicationUser ApplicationUser { get; set; }
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