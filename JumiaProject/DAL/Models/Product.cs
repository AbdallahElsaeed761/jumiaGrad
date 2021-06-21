using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string ProductName { get; set; }
        [Required]
        [Range(5, maximum: 100000)]
        public float Price { get; set; }
        public double? Discount { get; set; }
        public string RangeDate { get; set; }
        [Required]
        [StringLength(maximumLength: 1000, MinimumLength = 50)]
        public string Description { get; set; }
        [Required]
        [StringLength(maximumLength: 10000, MinimumLength = 50)]
        public string Details { get; set; }//stored html
        [Required]
        [StringLength(maximumLength: 20, MinimumLength = 3)]
        public string Manufacture { get; set; }

        public double Rate { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Size { get; set; }
        [Required]
        public string Color { get; set; }
        [NotMapped]
        [Required]
        [Range(1, 1000)]
        public int Quantity { get; set; }

        [Required]
        public int QuantitySealed { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; }
        public virtual List<ProductImage> ProductImages { get; set; }
        public virtual List<ProductDetail> ProductDetails { get; set; }
        [Required]
        [ForeignKey("Brand")]
        public int BrandId { get; set; }

        public virtual Brand Brand { get; set; }
        [Required]
        [ForeignKey("subCategory")]
        public int SubCategotyId { get; set; }
        public virtual SubCategory subCategory { get; set; }
        [ForeignKey("Promotions")]
        public int? PromotionId { get; set; }
        public virtual Promotions Promotions { get; set; }

        public virtual List<Review> Reviews { get; set; }
        public virtual List<View> Views { get; set; }
        public virtual List<InventoryProduct> InventoryProducts { get; set; }
        [DefaultValue(false)]
        public bool IsdeletedBySeller { get; set; }
        [DefaultValue(false)]
        public bool Active { get; set; }

    }

}