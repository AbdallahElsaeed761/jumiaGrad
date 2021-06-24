using BL.ViewModels;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.AppServices
{
   public class ViewsAppServices:Basices.AppServiceBase
    {
        public List<ViewsViewModel> GetAllViews()
        {
            return Mapper.Map<List<ViewsViewModel>>(TheUnitOfWork.View.GetAllview());
        }
        public ViewsViewModel Getviews(int id)
        {
            if (id < 0)
                throw new ArgumentNullException();
            return Mapper.Map<ViewsViewModel>(TheUnitOfWork.View.GetById(id));
        }

        public bool insertview(ReviewViewModel reviewViewModel)
        {
            bool result = false;
            var review = Mapper.Map<View>(reviewViewModel);
            if (TheUnitOfWork.View.Insert(review))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }
        public bool CreateUserWishlist(string customerId)
        {
            bool result = false;
            View userview = new View() { CustomerId = customerId };
            if (TheUnitOfWork.View.Insert(userview))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }


        public bool UpdateReview(ViewsViewModel ViewsViewModel)
        {
            var review = Mapper.Map<View>(ViewsViewModel);
            TheUnitOfWork.View.Update(review);
            TheUnitOfWork.Commit();
            return true;
        }
        public bool DeleteReview(int id)
        {
             if (id < 0)
                throw new ArgumentNullException();
            bool result = false;
            TheUnitOfWork.View.Delete(id);
            result = TheUnitOfWork.Commit() > new int();
            return result;
        }
    }
}
