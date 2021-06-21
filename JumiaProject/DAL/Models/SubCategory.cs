using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class SubCategory
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
        [ForeignKey("Category")]
        public int? CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public virtual List<Product> List { get; set; }
        public virtual List<Brand> Brands { get; set; }


    }
   
}