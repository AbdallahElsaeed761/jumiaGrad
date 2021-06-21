using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class ProductImage
    {
        [ForeignKey("Product")]

        public int ProductId { get; set; }


        public string Image { get; set; }

        [DefaultValue(false)]
        public bool Isdeleted { get; set; }
        public virtual Product Product { get; set; }
    }
}