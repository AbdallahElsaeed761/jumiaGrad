using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Reporsities
{
    public class SellerRepository : Basices.BaseRepository<Seller>
    {
        private DbContext _dbcontext;

        public SellerRepository(DbContext dbcontext) : base(dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public List<Seller> GetAllSeller()
        {
            return GetAll().ToList();
        }
        public bool InsertSeller(Seller seller)
        {
            return Insert(seller);
        }
        public void UpdateSeller(Seller seller)
        {
            Update(seller);
        }
        public void DeleteSeller(int id)
        {
            Delete(id);
        }

        public bool CheckSellerExists(Seller seller)
        {
            return GetAny(l => l.SellerId == seller.SellerId);
        }
        public Seller GetOSellerById(string id)
        {
            return GetFirstOrDefault(l => l.SellerId == id);
        }
    }
}
