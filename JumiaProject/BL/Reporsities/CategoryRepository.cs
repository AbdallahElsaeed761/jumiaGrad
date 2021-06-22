using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Reporsities
{
   public class CategoryRepository:Basices.BaseRepository<Category>
    {
        private DbContext _dbcontext;

        public CategoryRepository(DbContext dbcontext):base(dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public List<Category> GetAllCategory()
        {
            return GetAll().ToList();
        }

        public bool InsertCategory(Category category)
        {
            return Insert(category);
        }
        public void UpdateCategory(Category category)
        {
            Update(category);
        }
        public void DeleteCategory(int id)
        {
            Delete(id);
        }

        public bool CheckCategoryExists(Category category)
        {
            return GetAny(l => l.CategoryId == category.CategoryId);
        }
        public Category GetOCategoryById(int id)
        {
            return GetFirstOrDefault(l => l.CategoryId == id);
        }
    }
}
