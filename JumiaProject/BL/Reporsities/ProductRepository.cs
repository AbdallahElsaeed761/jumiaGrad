using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Reporsities
{
   public class ProductRepository:Basices.BaseRepository<Product>
    {
        private DbContext _dbcontext;

        public ProductRepository(DbContext dbcontext):base(dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public List<Product> GetAllProducts()
        {
            return GetAll().ToList();
        }
        public bool InsertProduct(Product product)
        {
            return Insert(product);
        }
        public void UpdateProduct(Product product)
        {
            Update(product);
        }
        public void DeleteProduct(int id)
        {
            Delete(id);
        }
        public bool CheckProductExists(Product product)
        {
            return GetAny(l => l.ProductId == product.ProductId);
        }
        public Product GetProductById(int id)
        {
            return GetFirstOrDefault(l => l.ProductId == id);
        }
    }
}
