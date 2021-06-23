using BL.ViewModels;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.AppServices
{
    public class ShippedDetailsAppServices:Basices.AppServiceBase
    {
        public List<ShippingDetailsViewModel> GetAllShippedDetails()
        {
            var shippingDetails = TheUnitOfWork.ShippedDetails.GetAllShippingDetails();
            return Mapper.Map<List<ShippingDetailsViewModel>>(shippingDetails);
        }


        public ShippingDetailsViewModel GetShippedDetails(int id)
        {
            return Mapper.Map<ShippingDetailsViewModel>(TheUnitOfWork.ShippedDetails.GetById(id));
        }
        public bool SaveNewShippedDetails(ShippingDetailsViewModel shippingDetailsViewModel)
        {
            bool result = false;
            var shippingDetails = Mapper.Map<ShippingDetails>(shippingDetailsViewModel);
            if (TheUnitOfWork.ShippedDetails.Insert(shippingDetails))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }

        public bool UpdateShippedDetails(ShippingDetailsViewModel shippingDetailsViewModel)
        {
            var shippingDetails = Mapper.Map<ShippingDetails>(shippingDetailsViewModel);
            TheUnitOfWork.ShippedDetails.Update(shippingDetails);
            TheUnitOfWork.Commit();

            return true;
        }

        //public List<ProductDetailsViewModel> SearchFor(string productToSearch)
        //{
        //    return GetAllProductDetail(productToSearch);
        //}
        public bool DeleteshippedDetails(int id)
        {
            bool result = false;
            TheUnitOfWork.ShippedDetails.Delete(id);
            result = TheUnitOfWork.Commit() > new int();
            return result;
        }

        public bool CheckShippedDetailsExists(ShippingDetailsViewModel shippingDetailsViewModel)
        {
            ShippingDetails shippingDetails = Mapper.Map<ShippingDetails>(shippingDetailsViewModel);
            return TheUnitOfWork.ShippedDetails.CheckShippingDetailsExists(shippingDetails);
        }
    }
}
