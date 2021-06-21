using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class CartItem
    {
        public int CartItemId { get; set; }
        [Required]
        public int Quantity { get; set; }
        public float TotalPrice { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        [ForeignKey("Cart")]
        public int CartId { get; set; }
        [DefaultValue(false)]
        public bool Isdeleted { get; set; }
        public virtual Cart Cart { get; set; }
    }
}