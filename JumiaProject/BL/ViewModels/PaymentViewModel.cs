using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ViewModels
{
    public class PaymentViewModel
    {
        public int PaymentId { get; set; }
        [Required]
        [MinLength(16), MaxLength(16)]
        public string cardNumber { get; set; }

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
       
    }
}
