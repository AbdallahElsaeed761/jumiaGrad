using BL.ViewModels;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.AppServices
{
    public class ProductDetailsAppServices:Basices.AppServiceBase
    {
        public List<ProductDetailsViewModel> GetAllProductDetail()
        {
            var productsDetails = TheUnitOfWork.ProductDetails.GetAllProductDetail();
            return Mapper.Map<List<ProductDetailsViewModel>>(productsDetails);
        }
        
       
        public ProductDetailsViewModel GetPoductDetail(int id)
        {
            return Mapper.Map<ProductDetailsViewModel>(TheUnitOfWork.ProductDetails.GetById(id));
        }
        public bool SaveNewProductDetail(ProductDetailsViewModel productDetailsViewModel)
        {
            bool result = false;
            var productdetail = Mapper.Map<ProductDetail>(productDetailsViewModel);
            if (TheUnitOfWork.ProductDetails.Insert(productdetail))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }

        public bool UpdateProductDetail(ProductDetailsViewModel productDetailsViewModel)
        {
            var productdetail = Mapper.Map<ProductDetail>(productDetailsViewModel);
            TheUnitOfWork.ProductDetails.Update(productdetail);
            TheUnitOfWork.Commit();

            return true;
        }
       
        //public List<ProductDetailsViewModel> SearchFor(string productToSearch)
        //{
        //    return GetAllProductDetail(productToSearch);
        //}
        public bool DeleteProductDetail(int id)
        {
            bool result = false;
            TheUnitOfWork.ProductDetails.Delete(id);
            result = TheUnitOfWork.Commit() > new int();
            return result;
        }

        public bool CheckProductDetailExists(ProductDetailsViewModel productDetailsViewModel)
        {
            ProductDetail productDetail = Mapper.Map<ProductDetail>(productDetailsViewModel);
            return TheUnitOfWork.ProductDetails.CheckProductDetailExists(productDetail);
        }
    }
}
