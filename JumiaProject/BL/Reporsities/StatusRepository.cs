using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Reporsities
{
    public class StatusRepository:Basices.BaseRepository<Status>
    {
        private DbContext _dbcontext;

        public StatusRepository(DbContext dbcontext) : base(dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public List<Status> GetAllStatus()
        {
            return GetAll().ToList();
        }

        public bool InsertStatus(Status status)
        {
            return Insert(status);
        }
        public void Updatestatus(Status status)
        {
            Update(status);
        }
        public void DeleteStatus(int id)
        {
            Delete(id);
        }
        public Status GetStatusByID(int id)
        {
            return GetFirstOrDefault(l => l.StatusId == id);
        }
    }
}
