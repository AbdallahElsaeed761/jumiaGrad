using BL.ViewModels;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.AppServices
{
   public class EmployeeAppServices:Basices.AppServiceBase
    {

        public List<EmployeeModelView> GetAllEmployee()
        {
            return Mapper.Map<List<EmployeeModelView>>(TheUnitOfWork.Employee.GetAllEmployee());
        }
        public EmployeeModelView GetEmployee(int id)
        {
            return Mapper.Map<EmployeeModelView>(TheUnitOfWork.Employee.GetById(id));
        }
        public bool SaveNewEmployee(EmployeeModelView employeeModelView)
        {

            bool result = false;
            var employee = Mapper.Map<Employee>(employeeModelView);
            if (TheUnitOfWork.Employee.Insert(employee))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }
        public bool UpdateEmployee(EmployeeModelView employeeModelView)
        {
            var employee = Mapper.Map<Employee>(employeeModelView);
            TheUnitOfWork.Employee.Update(employee);
            TheUnitOfWork.Commit();

            return true;
        }


        public bool DeleteEmployee(int id)
        {
            bool result = false;

            TheUnitOfWork.Employee.Delete(id);
            result = TheUnitOfWork.Commit() > new int();

            return result;
        }

        public bool CheckEmployeeExists(EmployeeModelView employeeModelView)
        {
            Employee employee = Mapper.Map<Employee>(employeeModelView);
            return TheUnitOfWork.Employee.CheckEmployeeExists(employee);
        }
    }
}
