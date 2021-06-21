using System.ComponentModel;

namespace DAL.Models
{
    public class View
    {
        public string CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }


        [DefaultValue(false)]
        public bool IsFav { get; set; }
    }
  
}