using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class InventoryProduct
    {

        [Required]
        public int Quantity { get; set; }
        [DefaultValue(false)]
        public bool Isdeleted { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        
        [ForeignKey("Inventory")]
        public int InventoryId { get; set; }
        public virtual Inventory Inventory { get; set; }
    }
   
}