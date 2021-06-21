using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class Review
    {

        [ForeignKey("Customer")]
        public string CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        [Range(minimum: 0, maximum: 5)]
        public double? review { get; set; }
        public string comment { get; set; }
        public int ProductId { get; set; }
        [DefaultValue(false)]
        public bool Isdeleted { get; set; }
        public virtual Product Product { get; set; }
       

    }
}