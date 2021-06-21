using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class Cart
    {
        public int CartId { get; set; }
        public float Cost { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ShippingDate { get; set; }
        public DateTime DueDate { get; set; }

        [DefaultValue(false)]
        public bool Approved { get; set; }
        [ForeignKey("Customer")]
        public string CustomerID { get; set; }
        public virtual Customer Customer { get; set; }
        [DefaultValue(false)]
        public bool Isdeleted { get; set; }


        [ForeignKey("Employee")]
        public string EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        [ForeignKey("Status")]
        public int? StatusId { get; set; }
        public virtual Status Status { get; set; }
        public virtual List<CartItem> CartItems { get; set; }
    }
   

}