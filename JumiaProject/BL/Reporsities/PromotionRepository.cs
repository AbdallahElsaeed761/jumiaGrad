using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace BL.Reporsities
{
   public class PromotionRepository:Basices.BaseRepository<Promotions>
    {
        private DbContext _dbcontext;

        public PromotionRepository(DbContext dbcontext):base(dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public List<Promotions> GetAllPromotions()
        {
            return GetAll().ToList();
        }
        public bool InsertPromotions(Promotions promotion)
        {
            return Insert(promotion);
        }
        public void UpdatePromotions(Promotions promotion)
        {
            Update(promotion);
        }
        public void DeletePromotions(int id)
        {
            Delete(id);
        }
        public bool CheckPromotionExists(Promotions promotion)
        {
            return GetAny(l => l.PromotionsId == promotion.PromotionsId);
        }
        public Promotions GetPromotionsById(int id)
        {
            return GetFirstOrDefault(l => l.PromotionsId == id);
        }
    }
}
