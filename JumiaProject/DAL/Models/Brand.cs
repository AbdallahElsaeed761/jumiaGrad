using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
   public class Brand 
    {
        public int BrandId { get; set; }
        [Required]
        [StringLength(50,MinimumLength =2)]
        public string BrandName { get; set; }
        [DefaultValue(false)]
        public bool Isdeleted { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public DateTime UpdateAt { get; set; }
        public virtual List<Product> Products { get; set; }
        public virtual List<SubCategory> SubCategories { get; set; }

    }
  
}
