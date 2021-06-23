using BL.Basices;
using BL.ViewModels;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.AppServices
{
   public class BrandsAppServices:AppServiceBase
    {
        public List<BrandViewModel> GetAllBrands()
        {
            return Mapper.Map<List<BrandViewModel>>(TheUnitOfWork.Brands.GetAllBrands());
        }
        public BrandViewModel GetBrand(int id)
        {
            return Mapper.Map<BrandViewModel>(TheUnitOfWork.Brands.GetBrandsById(id));
        }
        public bool SaveNewBrand(BrandViewModel brandViewModel)
        {
            bool result = false;
            var brand = Mapper.Map<Brand>(brandViewModel);
            if (TheUnitOfWork.Brands.Insert(brand))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }
        public bool UpdateBrand(BrandViewModel brandsViewModel)
        {
            var brand = Mapper.Map<Brand>(brandsViewModel);
            TheUnitOfWork.Brands.Update(brand);
            TheUnitOfWork.Commit();
            return true;
        }
        public bool DeleteBrand(int id)
        {
            bool result = false;
            TheUnitOfWork.Brands.Delete(id);
            result = TheUnitOfWork.Commit() > new int();
            return result;
        }
        public bool CheckBrandExists(BrandViewModel brandViewModel)
        {
            Brand brand = Mapper.Map<Brand>(brandViewModel);
            return TheUnitOfWork.Brands.CheckBrandsExists(brand);
        }
    }
}
