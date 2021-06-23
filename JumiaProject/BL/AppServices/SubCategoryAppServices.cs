using BL.ViewModels;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.AppServices
{
   public class SubCategoryAppServices:Basices.AppServiceBase
    {

        public List<SubCategoryViewModel> GetAllSubCateogries()
        {
            return Mapper.Map<List<SubCategoryViewModel>>(TheUnitOfWork.SubCategory.GetAllSubCategory());
        }
        public SubCategoryViewModel GetSubCategory(int id)
        {
            return Mapper.Map<SubCategoryViewModel>(TheUnitOfWork.SubCategory.GetById(id));
        }
        public bool SaveNewSubCategory(SubCategoryViewModel subCategoryViewModel)
        {

            bool result = false;
            var subcategory = Mapper.Map<SubCategory>(subCategoryViewModel);
            if (TheUnitOfWork.SubCategory.Insert(subcategory))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }
        public bool UpdateSubCategory(SubCategoryViewModel subCategoryViewModel)
        {
            var subcategory = Mapper.Map<SubCategory>(subCategoryViewModel);
            TheUnitOfWork.SubCategory.Update(subcategory);
            TheUnitOfWork.Commit();

            return true;
        }


        public bool DeletesubCategory(int id)
        {
            bool result = false;

            TheUnitOfWork.SubCategory.Delete(id);
            result = TheUnitOfWork.Commit() > new int();

            return result;
        }

       
    }
}
