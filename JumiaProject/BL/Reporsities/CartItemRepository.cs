using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Reporsities
{
   public class CartItemRepository:Basices.BaseRepository<CartItem>
    {
        private DbContext _dbcontext;

        public CartItemRepository(DbContext dbcontext):base(dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public List<CartItem> GetAllCartItem()
        {
            return GetAll().Include(op => op.Product).ToList();
        }

        public bool InsertCartItem(CartItem cartItem)
        {
            return Insert(cartItem);
        }
        public void UpdateCartItem(CartItem cartItem)
        {
            Update(cartItem);
        }
    }
}
