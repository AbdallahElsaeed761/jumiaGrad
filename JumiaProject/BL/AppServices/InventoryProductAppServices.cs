using BL.ViewModels;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.AppServices
{
    public class InventoryProductAppServices:Basices.AppServiceBase
    {
        public List<InventoryproductViewModel> GetAllInventory()
        {
            return Mapper.Map<List<InventoryproductViewModel>>(TheUnitOfWork.Inventoryproduct.GetAllInventoryProduct());
        }
        public InventoryproductViewModel Get(int id)
        {
            return Mapper.Map<InventoryproductViewModel>(TheUnitOfWork.Inventoryproduct.GetById(id));
        }
        public bool SaveNewInventoryProduct(InventoryproductViewModel inventoryproductViewModel)
        {

            bool result = false;
            var inventoryproduct = Mapper.Map<InventoryProduct>(inventoryproductViewModel);
            if (TheUnitOfWork.Inventoryproduct.Insert(inventoryproduct))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }
        public bool UpdateInventoryProduct(InventoryproductViewModel inventoryproductViewModel)
        {
            var inventoryProduct = Mapper.Map<InventoryProduct>(inventoryproductViewModel);
            TheUnitOfWork.Inventoryproduct.Update(inventoryProduct);
            TheUnitOfWork.Commit();

            return true;
        }


        public bool DeleteInventoryProduct(int id)
        {
            bool result = false;

            TheUnitOfWork.Inventoryproduct.Delete(id);
            result = TheUnitOfWork.Commit() > new int();

            return result;
        }

        public bool CheckInventoryProductExists(InventoryproductViewModel inventoryproductViewModel)
        {
            InventoryProduct inventoryproduct = Mapper.Map<InventoryProduct>(inventoryproductViewModel);
            return TheUnitOfWork.Inventoryproduct.CheckInventoryProductExists(inventoryproduct);
        }
    }
}
