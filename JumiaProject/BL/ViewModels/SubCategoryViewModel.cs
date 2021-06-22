using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ViewModels
{
    public class SubCategoryViewModel
    {
        public int SubCategoryId { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; }
        public string Image { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        [DefaultValue(false)]
        public bool Isdeleted { get; set; }
        
        public int? CategoryId { get; set; }
        
        public virtual List<Product> List { get; set; }
        public virtual List<Brand> Brands { get; set; }

    }
}
