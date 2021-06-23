
using BL.ViewModels;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.AppServices
{
   public class InventoryAppServices:Basices.AppServiceBase
    {
        public List<inventoryViewModel> GetAllInventory()
        {
            return Mapper.Map<List<inventoryViewModel>>(TheUnitOfWork.Inventory.GetAllInventory());
        }
        public inventoryViewModel Get(int id)
        {
            return Mapper.Map<inventoryViewModel>(TheUnitOfWork.Inventory.GetById(id));
        }
        public bool SaveNewInventory(inventoryViewModel nventoryViewModel)
        {

            bool result = false;
            var inventory = Mapper.Map<Inventory>(nventoryViewModel);
            if (TheUnitOfWork.Inventory.Insert(inventory))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }
        public bool UpdateInventory(inventoryViewModel nventoryViewModel)
        {
            var inventory = Mapper.Map<Inventory>(nventoryViewModel);
            TheUnitOfWork.Inventory.Update(inventory);
            TheUnitOfWork.Commit();

            return true;
        }


        public bool DeleteInventory(int id)
        {
            bool result = false;

            TheUnitOfWork.Inventory.Delete(id);
            result = TheUnitOfWork.Commit() > new int();

            return result;
        }

        public bool CheckInventoryExists(inventoryViewModel nventoryViewModel)
        {
            Inventory inventory = Mapper.Map<Inventory>(nventoryViewModel);
            return TheUnitOfWork.Inventory.CheckInventoryExists(inventory);
        }
    }
}
