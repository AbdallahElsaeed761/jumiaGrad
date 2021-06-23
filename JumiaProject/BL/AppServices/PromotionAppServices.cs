using BL.ViewModels;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.AppServices
{
    public class PromotionAppServices:Basices.AppServiceBase
    {
        public List<PromotionViewModel> GetAllPromotion()
        {
            var promotions = TheUnitOfWork.Promotion.GetAllPromotions();
            return Mapper.Map<List<PromotionViewModel>>(promotions);
        }
        public List<PromotionViewModel> GetAllPromotionWhere(string sellerId)
        {
            var searchRes = TheUnitOfWork.Promotion.GetWhere(p => p.SellerId == sellerId);
            return Mapper.Map<List<PromotionViewModel>>(searchRes);
        }
       
        public PromotionViewModel GetPromotion(int id)
        {
            return Mapper.Map<PromotionViewModel>(TheUnitOfWork.Promotion.GetPromotionsById(id));
        }
        public bool SaveNewPromotion(PromotionViewModel promotionViewModel)
        {
            bool result = false;
            var promotion = Mapper.Map<Promotions>(promotionViewModel);
            if (TheUnitOfWork.Promotion.Insert(promotion))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }

        public bool UpdatePromotion(PromotionViewModel promotionViewModel)
        {
            var promtion = Mapper.Map<Promotions>(promotionViewModel);
            TheUnitOfWork.Promotion.Update(promtion);
            TheUnitOfWork.Commit();

            return true;
        }
       
        public List<PromotionViewModel> SearchFor(string productToSearch)
        {
            return GetAllPromotionWhere(productToSearch);
        }
        public bool DeletePromotion(int id)
        {
            bool result = false;
            TheUnitOfWork.Promotion.Delete(id);
            result = TheUnitOfWork.Commit() > new int();
            return result;
        }

        public bool CheckPromotionExists(PromotionViewModel promotionViewModel)
        {
            Promotions promotions = Mapper.Map<Promotions>(promotionViewModel);
            return TheUnitOfWork.Promotion.CheckPromotionExists(promotions);
        }
    }
}