using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Reporsities
{
   public class EmployeeRepository:Basices.BaseRepository<Employee>
    {
        private DbContext _dbcontext;

        public EmployeeRepository(DbContext dbcontext):base(dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public List<Employee> GetAllEmployee()
        {
            return GetAll().ToList();
        }
        public bool InsertEmployee(Employee employee)
        {
            return Insert(employee);
        }
        public void UpdateEmployee(Employee employee)
        {
            Update(employee);
        }
        public void DeleteEmployee(int id)
        {
            Delete(id);
        }

        public bool CheckEmployeeExists(Employee employee)
        {
            return GetAny(l => l.EmployeeId == employee.EmployeeId);
        }
        public Employee GetOEmployeeById(string id)
        {
            return GetFirstOrDefault(l => l.EmployeeId == id);
        }
    }
}
