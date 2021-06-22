using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Reporsities
{
   public  class InventoryproductRepository:Basices.BaseRepository<InventoryProduct>
    {
        private DbContext _dbcontext;

        public InventoryproductRepository(DbContext dbcontext):base(dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public List<InventoryProduct> GetAllInventoryProduct()
        {
            return GetAll().ToList();
        }
        public bool InsertInventoryProduct(InventoryProduct inventoryProduct)
        {
            return Insert(inventoryProduct);
        }
        public void UpdateInventoryProduct(InventoryProduct inventoryProduct)
        {
            Update(inventoryProduct);
        }
        public void DeleteInventoryProduct(int id)
        {
            Delete(id);
        }

        public bool CheckInventoryProductExists(InventoryProduct inventoryProduct)
        {
            return GetAny(l => l.ProductId == inventoryProduct.ProductId);
        }
        public InventoryProduct GetOInventoryProductById(int id)
        {
            return GetFirstOrDefault(l => l.ProductId == id);
        }
    }
}
