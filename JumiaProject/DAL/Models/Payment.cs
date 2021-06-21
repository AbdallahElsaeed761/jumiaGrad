using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public string type { get; set; }
        public float amount { get; set; }
        public DateTime CreatedAt { get; set; }

        //[ForeignKey("ShippingDetail")]
        //public int ShippingDetailId { get; set; }

        //public virtual ShippingDetails ShippingDetail { get; set; }
    }
}