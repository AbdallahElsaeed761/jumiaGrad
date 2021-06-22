using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
namespace BL.Reporsities
{
   public class ViewRepository:Basices.BaseRepository<View>
    {
        private DbContext _dbcontext;

        public ViewRepository(DbContext dbcontext) : base(dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public List<View> GetAllview()
        {
            return GetAll().ToList();
        }

        public bool Insertview(View view)
        {
            return Insert(view);
        }
        public void Updateview(View view)
        {
            Update(view);
        }
        public void Deleteview(int id)
        {
            Delete(id);
        }
        public View GetviewByCutomerID(string id)
        {
            return GetFirstOrDefault(l => l.CustomerId == id);
        }
    }
}
