using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class Customer
    {
        [Key, ForeignKey("ApplicationUser")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string CustomerId { get; set; }
        [DefaultValue(false)]
        public bool Isdeleted { get; set; }

        public virtual applicationUser ApplicationUser { get; set; }

        public virtual List<View> Views { get; set; }
        public virtual List<Review> Reviews { get; set; }
        public virtual List<Cart> Carts { get; set; }

    }
}