using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Reporsities
{
   public class BrandsRepository:Basices.BaseRepository<Brand>
    {
        private DbContext _dbcontext;

        public BrandsRepository(DbContext dbContext):base(dbContext)
        {
            _dbcontext = dbContext;
        }
        public List<Brand> GetAllBrands()
        {
            return GetAll().ToList();
        }
        public bool InsertBrands(Brand brands)
        {
            return Insert(brands);
        }
        public void UpdateBrands(Brand brands)
        {
            Update(brands);
        }
        public void DeleteBrands(int id)
        {
            Delete(id);
        }
        public bool CheckBrandsExists(Brand brands)
        {
            return GetAny(l => l.BrandId == brands.BrandId);
        }
        public Brand GetBrandsById(int id)
        {
            return GetFirstOrDefault(l => l.BrandId == id);
        }
    }
}
