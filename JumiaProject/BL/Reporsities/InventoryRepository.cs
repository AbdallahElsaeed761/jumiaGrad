using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Reporsities
{
    public class InventoryRepository:Basices.BaseRepository<Inventory>
    {
        private DbContext _dbcontext;

        public InventoryRepository(DbContext dbcontext):base(dbcontext)
        {
            _dbcontext= dbcontext;
        }
        public List<Inventory> GetAllInventory()
        {
            return GetAll().ToList();
        }
        public bool InsertInventory(Inventory inventory)
        {
            return Insert(inventory);
        }
        public void UpdateInventory(Inventory inventory)
        {
            Update(inventory);
        }
        public void DeleteInventory(int id)
        {
            Delete(id);
        }

        public bool CheckInventoryExists(Inventory inventory)
        {
            return GetAny(l => l.InventoryId == inventory.InventoryId);
        }
        public Inventory GetOInventoryById(int id)
        {
            return GetFirstOrDefault(l => l.InventoryId == id);
        }
    }
}
