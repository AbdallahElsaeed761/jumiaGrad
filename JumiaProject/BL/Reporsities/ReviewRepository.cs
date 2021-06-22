using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace BL.Reporsities
{
   public class ReviewRepository:Basices.BaseRepository<Review>
    {
        private DbContext _dbcontext;

        public ReviewRepository(DbContext dbcontext):base(dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public List<Review> GetAllReview()
        {
            return GetAll().ToList();
        }

        public bool InsertReview(Review review)
        {
            return Insert(review);
        }
        public void UpdateReview(Review review)
        {
            Update(review);
        }
        public void DeleteReview(int id)
        {
            Delete(id);
        }
        public Review GetReviewByCutomerID(string id)
        {
            return GetFirstOrDefault(l => l. CustomerId== id);
        }
    }
}
