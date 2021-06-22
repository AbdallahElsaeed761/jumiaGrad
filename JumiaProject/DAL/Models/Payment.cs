using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public string type { get; set; }
        public float amount { get; set; }
        [DataType(DataType.Date), Required]
        [DisplayFormat(DataFormatString = "{​​​​​​​0:yyyy/MM/dd}​​​​​​​", ApplyFormatInEditMode = true)]
        public DateTime CreatedAt { get; set; }

        [Required]
        [MinLength(16), MaxLength(16)]
        public string cardName { get; set; }

        [Required]
        public string cardOwnerName { get; set; }

        public string userID { get; set; }
        

        //[ForeignKey("ShippingDetail")]
        //public int ShippingDetailId { get; set; }

        //public virtual ShippingDetails ShippingDetail { get; set; }
    }
}