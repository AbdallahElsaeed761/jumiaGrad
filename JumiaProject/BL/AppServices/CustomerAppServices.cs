using BL.ViewModels;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.AppServices
{
    public class CustomerAppServices:Basices.AppServiceBase
    {

        public List<CustomerViewModel> GetAllCustomer()
        {
            return Mapper.Map<List<CustomerViewModel>>(TheUnitOfWork.Customer.GetAllCustomer());
        }
        public CustomerViewModel GetCustomer(int id)
        {
            return Mapper.Map<CustomerViewModel>(TheUnitOfWork.Customer.GetById(id));
        }
        public bool SaveNewCustomer(CustomerViewModel customerViewModel)
        {

            bool result = false;
            var customer = Mapper.Map<Customer>(customerViewModel);
            if (TheUnitOfWork.Customer.Insert(customer))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }
        public bool UpdateCustomer(CustomerViewModel customerViewModel)
        {
            var customer = Mapper.Map<Customer>(customerViewModel);
            TheUnitOfWork.Customer.Update(customer);
            TheUnitOfWork.Commit();

            return true;
        }


        public bool DeleteCustomer(int id)
        {
            bool result = false;

            TheUnitOfWork.Customer.Delete(id);
            result = TheUnitOfWork.Commit() > new int();

            return result;
        }

        public bool CheckCustomerExists(CustomerViewModel customerViewModel)
        {
            Customer customer = Mapper.Map<Customer>(customerViewModel);
            return TheUnitOfWork.Customer.CheckCustomerExists(customer);
        }
    }
}
