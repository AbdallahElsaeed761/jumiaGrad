using BL.ViewModels;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.AppServices
{
   public class ReviewAppServices:Basices.AppServiceBase
    {
        public List<ReviewViewModel> GetAllReviews()
        {
            return Mapper.Map<List<ReviewViewModel>>(TheUnitOfWork.Review.GetAllReview());
        }
        public ReviewViewModel GetReviews(int id)
        {
            return Mapper.Map<ReviewViewModel>(TheUnitOfWork.Review.GetById(id));
        }

        public bool insertReview(ReviewViewModel reviewViewModel)
        {
            bool result = false;
            var review = Mapper.Map<Review>(reviewViewModel);
            if (TheUnitOfWork.Review.Insert(review))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }

        public bool UpdateReview(ReviewViewModel reviewViewModel)
        {
            var review = Mapper.Map<Review>(reviewViewModel);
            TheUnitOfWork.Review.Update(review);
            TheUnitOfWork.Commit();
            return true;
        }
        public bool DeleteReview(int id)
        {
            bool result = false;
            TheUnitOfWork.Review.Delete(id);
            result = TheUnitOfWork.Commit() > new int();
            return result;
        }
    }
}
