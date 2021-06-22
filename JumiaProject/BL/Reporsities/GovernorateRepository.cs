using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Reporsities
{
    public class GovernorateRepository:Basices.BaseRepository<Governorate>
    {
        private DbContext _dbcontext;

        public GovernorateRepository(DbContext dbcontext):base(dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public List<Governorate> GetAllGovernorate()
        {
            return GetAll().ToList();
        }
        public bool InsertGovernorate(Governorate governorate)
        {
            return Insert(governorate);
        }
        public void UpdateGovernorate(Governorate governorate)
        {
            Update(governorate);
        }
        public void DeleteGovernorate(int id)
        {
            Delete(id);
        }

        public bool CheckGovernorateExists(Governorate governorate)
        {
            return GetAny(l => l.GovernorateId == governorate.GovernorateId);
        }
        public Governorate GetOGovernorateById(int id)
        {
            return GetFirstOrDefault(l => l.GovernorateId == id);
        }
    }
}
