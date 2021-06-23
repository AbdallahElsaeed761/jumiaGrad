using BL.ViewModels;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.AppServices
{
    public class SellerAppServices:Basices.AppServiceBase
    {
        public List<SellerViewModel> GetAllSeller()
        {
            return Mapper.Map<List<SellerViewModel>>(TheUnitOfWork.Seller.GetAllSeller());
        }
        public SellerViewModel GetSeller(int id)
        {
            return Mapper.Map<SellerViewModel>(TheUnitOfWork.Seller.GetById(id));
        }
        public bool SaveNewSeller(SellerViewModel sellerViewModel)
        {

            bool result = false;
            var seller = Mapper.Map<Seller>(sellerViewModel);
            if (TheUnitOfWork.Seller.Insert(seller))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }
        public bool UpdateSeller(SellerViewModel sellerViewModel)
        {
            var seller = Mapper.Map<Seller>(sellerViewModel);
            TheUnitOfWork.Seller.Update(seller);
            TheUnitOfWork.Commit();

            return true;
        }


        public bool DeleteSeller(int id)
        {
            bool result = false;

            TheUnitOfWork.Seller.Delete(id);
            result = TheUnitOfWork.Commit() > new int();

            return result;
        }

        public bool CheckSellerExists(SellerViewModel sellerViewModel)
        {
            Seller seller = Mapper.Map<Seller>(sellerViewModel);
            return TheUnitOfWork.Seller.CheckSellerExists(seller);
        }
    }
}
