using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Reporsities
{
   public class CustomerRepository:Basices.BaseRepository<Customer>
    {
        private DbContext _dbcontext;

        public CustomerRepository(DbContext dbContext):base(dbContext)
        {
            _dbcontext = dbContext;
        }
        public List<Customer> GetAllCustomer()
        {
            return GetAll().ToList();
        }
        public bool InsertCustomer(Customer customer)
        {
            return Insert(customer);
        }
        public void UpdateCustomer(Customer customer)
        {
            Update(customer);
        }
        public void DeleteCustomer(int id)
        {
            Delete(id);
        }

        public bool CheckCustomerExists(Customer customer)
        {
            return GetAny(l => l.CustomerId == customer.CustomerId);
        }
        public Customer GetOCustomerById(string id)
        {
            return GetFirstOrDefault(l => l.CustomerId == id);
        }
    }
}
