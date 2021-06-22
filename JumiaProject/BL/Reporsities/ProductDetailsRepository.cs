using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;


namespace BL.Reporsities
{
   public class ProductDetailsRepository:Basices.BaseRepository<ProductDetail>
    {
        private DbContext _dbcontext;

        public ProductDetailsRepository(DbContext dbcontext):base(dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public List<ProductDetail> GetAllProductDetail()
        {
            return GetAll().ToList();
        }
        public bool InsertProductDetail(ProductDetail productDetail)
        {
            return Insert(productDetail);
        }
        public void UpdateProductDetail(ProductDetail productDetail)
        {
            Update(productDetail);
        }
        public void DeleteProductDetail(int id)
        {
            Delete(id);
        }
        public bool CheckProductDetailExists(ProductDetail productDetail)
        {
            return GetAny(l => l.ProductDetailId == productDetail.ProductDetailId);
        }
        public ProductDetail GetProductDetailById(int id)
        {
            return GetFirstOrDefault(l => l.ProductDetailId == id);
        }
    }
}
