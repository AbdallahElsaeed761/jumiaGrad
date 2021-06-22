using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ViewModels
{
    public class ShippingDetailsViewModel
    {
        public int ShippingDetailId { get; set; }

        public float PurshaesCost { get; set; }


        
        public int GovernorateId { get; set; }
        


        
        public int PaymentId { get; set; }
        

        public virtual Cart Carts { get; set; }
    }
}
