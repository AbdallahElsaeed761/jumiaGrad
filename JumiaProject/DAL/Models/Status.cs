using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class Status
    {
        public int StatusId { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 5)]
        public string StatusName { get; set; }
        [DefaultValue(false)]
        public bool Isdeleted { get; set; }

        public virtual List<Cart> Carts { get; set; }

    }
}