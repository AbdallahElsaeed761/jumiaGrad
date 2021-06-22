using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
namespace BL.Reporsities
{
    public class ShippedDetailsRepository : Basices.BaseRepository<ShippingDetails>
    {
        private DbContext _dbcontext;

        public ShippedDetailsRepository(DbContext dbcontext) : base(dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public List<ShippingDetails> GetAllShippingDetails()
        {
            return GetAll().ToList();
        }
        public bool InsertShippingDetails(ShippingDetails shippingDetails)
        {
            return Insert(shippingDetails);
        }
        public void UpdateShippingDetails(ShippingDetails shippingDetails)
        {
            Update(shippingDetails);
        }
        public void DeleteShippingDetails(int id)
        {
            Delete(id);
        }

        public bool CheckShippingDetailsExists(ShippingDetails shippingDetails)
        {
            return GetAny(l => l.ShippingDetailId == shippingDetails.ShippingDetailId);
        }
        public ShippingDetails GetOShippingDetailsById(int id)
        {
            return GetFirstOrDefault(l => l.ShippingDetailId == id);
        }
    }
}
