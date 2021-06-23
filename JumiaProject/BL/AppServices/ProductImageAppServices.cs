using BL.ViewModels;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.AppServices
{
   public class ProductImageAppServices:Basices.AppServiceBase
    {
        public List<productImageViewModel> GetAllProductImage()
        {
            var productsimage = TheUnitOfWork.Productimage.GetAllProductImage();
            return Mapper.Map<List<productImageViewModel>>(productsimage);
        }


        public productImageViewModel GetPoductimage(int id)
        {
            return Mapper.Map<productImageViewModel>(TheUnitOfWork.Productimage.GetById(id));
        }
        public bool SaveNewProductImage(productImageViewModel roductImageViewModel)
        {
            bool result = false;
            var productimage = Mapper.Map<ProductImage>(roductImageViewModel);
            if (TheUnitOfWork.Productimage.Insert(productimage))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }

        public bool UpdateProductImage(productImageViewModel roductImageViewModel)
        {
            var productimage = Mapper.Map<ProductImage>(roductImageViewModel);
            TheUnitOfWork.Productimage.Update(productimage);
            TheUnitOfWork.Commit();

            return true;
        }

        //public List<ProductDetailsViewModel> SearchFor(string productToSearch)
        //{
        //    return GetAllProductDetail(productToSearch);
        //}
        public bool DeleteProductImage(int id)
        {
            bool result = false;
            TheUnitOfWork.Productimage.Delete(id);
            result = TheUnitOfWork.Commit() > new int();
            return result;
        }

        public bool CheckProductImageExists(productImageViewModel roductImageViewModel)
        {
            ProductImage productimage = Mapper.Map<ProductImage>(roductImageViewModel);
            return TheUnitOfWork.Productimage.CheckProductImagetExists(productimage);
        }
    }
}
