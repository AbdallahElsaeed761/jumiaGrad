using BL.ViewModels;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.AppServices
{
    public class GovernorateAppServices:Basices.AppServiceBase
    {
        public List<GovernorateViewModel> GetAllGovernorate()
        {
            return Mapper.Map<List<GovernorateViewModel>>(TheUnitOfWork.Governorate.GetAllGovernorate());
        }
        public GovernorateViewModel Get(int id)
        {
            return Mapper.Map<GovernorateViewModel>(TheUnitOfWork.Governorate.GetById(id));
        }
        public bool SaveNewGovernorate(GovernorateViewModel governorateViewModel)
        {

            bool result = false;
            var governorate = Mapper.Map<Governorate>(governorateViewModel);
            if (TheUnitOfWork.Governorate.Insert(governorate))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }
        public bool UpdateGovernorate(GovernorateViewModel governorateViewModel)
        {
            var governorate = Mapper.Map<Governorate>(governorateViewModel);
            TheUnitOfWork.Governorate.Update(governorate);
            TheUnitOfWork.Commit();

            return true;
        }


        public bool DeleteGovernorate(int id)
        {
            bool result = false;

            TheUnitOfWork.Governorate.Delete(id);
            result = TheUnitOfWork.Commit() > new int();

            return result;
        }

        public bool CheckGovernorateExists(GovernorateViewModel governorateViewModel)
        {
            Governorate governorate = Mapper.Map<Governorate>(governorateViewModel);
            return TheUnitOfWork.Governorate.CheckGovernorateExists(governorate);
        }
    }
}
