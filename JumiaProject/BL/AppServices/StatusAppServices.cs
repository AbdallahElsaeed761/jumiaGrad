using BL.ViewModels;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.AppServices
{
    public class StatusAppServices:Basices.AppServiceBase
    {
        public List<StatusViewModel> GetAllStatus()
        {
            return Mapper.Map<List<StatusViewModel>>(TheUnitOfWork.Status.GetAllStatus());
        }
        public StatusViewModel Getstatus(int id)
        {
            return Mapper.Map<StatusViewModel>(TheUnitOfWork.Status.GetById(id));
        }
        public bool SaveNewSatus(StatusViewModel statusViewModel)
        {

            bool result = false;
            var status = Mapper.Map<Status>(statusViewModel);
            if (TheUnitOfWork.Status.Insert(status))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }
        public bool UpdateStatus(StatusViewModel statusViewModel)
        {
            var status = Mapper.Map<Status>(statusViewModel);
            TheUnitOfWork.Status.Update(status);
            TheUnitOfWork.Commit();

            return true;
        }


        public bool DeleteSatus(int id)
        {
            bool result = false;

            TheUnitOfWork.Status.Delete(id);
            result = TheUnitOfWork.Commit() > new int();

            return result;
        }

       
    }
}
