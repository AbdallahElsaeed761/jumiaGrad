using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace BL.Reporsities
{
   public class SubCategoryRepository:Basices.BaseRepository<SubCategory>
    {
        private DbContext _dbcontext;

        public SubCategoryRepository(DbContext dbcontext) : base(dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public List<SubCategory> GetAllSubCategory()
        {
            return GetAll().ToList();
        }

        public bool InsertSubCategory(SubCategory subCategory)
        {
            return Insert(subCategory);
        }
        public void UpdateSubCategory(SubCategory subCategory)
        {
            Update(subCategory);
        }
        public void DeleteSubCategory(int id)
        {
            Delete(id);
        }
        public SubCategory GetSubCategoryByID(int id)
        {
            return GetFirstOrDefault(l => l.CategoryId == id);
        }
    }
}
