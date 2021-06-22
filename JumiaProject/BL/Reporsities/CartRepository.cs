using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Reporsities
{
   public class CartRepository:Basices.BaseRepository<Cart>
    {
        private DbContext _dbcontext;

        public CartRepository(DbContext dbContext ):base(dbContext)
        {
            _dbcontext = dbContext;
        }
        public List<Cart> GetAllCarts()
        {
            return GetAll().ToList();
        }
        public bool InsertCart(Cart cart)
        {
            return Insert(cart);
        }
        public void UpdateCart(Cart cart)
        {
            Update(cart);
        }
        public void DeleteCart(int id)
        {
            Delete(id);
        }
        public bool CheckCartExists(Cart cart)
        {
            return GetAny(l => l.CartId == cart.CartId);
        }
        public Cart GetProductById(int id)
        {
            return GetFirstOrDefault(l => l.CartId == id);
        }
    }
}
