using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace BL.Reporsities
{
   public class ProductimageRepository:Basices.BaseRepository<ProductImage>
    {
        private DbContext _dbcontext;

        public ProductimageRepository(DbContext dbcontext):base(dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public List<ProductImage> GetAllProductImage()
        {
            return GetAll().ToList();
        }
        public bool InsertProductImage(ProductImage productImage)
        {
            return Insert(productImage);
        }
        public void UpdateProductImage(ProductImage productImage)
        {
            Update(productImage);
        }
        public void DeleteProductImage(int id)
        {
            Delete(id);
        }
        public bool CheckProductImagetExists(ProductImage productImage)
        {
            return GetAny(l => l.ProductId == productImage.ProductId);
        }
        public ProductImage GetProductImageById(int id)
        {
            return GetFirstOrDefault(l => l.ProductId == id);
        }
    }
}
