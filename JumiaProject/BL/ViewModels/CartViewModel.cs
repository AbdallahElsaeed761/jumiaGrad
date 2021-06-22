using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ViewModels
{
    public class CartViewModel
    {
        public int CartId { get; set; }
        public float Cost { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ShippingDate { get; set; }
        public DateTime DueDate { get; set; }

        [DefaultValue(false)]
        public bool Approved { get; set; }
        
        public string CustomerID { get; set; }
        
        [DefaultValue(false)]
        public bool Isdeleted { get; set; }


        
        public string EmployeeId { get; set; }
        
       
        public int? StatusId { get; set; }
        public virtual Status Status { get; set; }
       
    }
}
