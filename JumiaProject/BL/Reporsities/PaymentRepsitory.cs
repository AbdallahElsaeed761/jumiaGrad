using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Reporsities
{
   public class PaymentRepsitory:Basices.BaseRepository<Payment>
    {
        private DbContext _dbcontext;

        public PaymentRepsitory(DbContext dbcontext):base(dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public bool InsertPayment(Payment payment)
        {
            return Insert(payment);
        }
        public void UpdatePayment(Payment payment)
        {
            Update(payment);
        }
        public void DeletePayment(int id)
        {
            Delete(id);
        }

        public bool CheckPaymentExists(Payment payment)
        {
            return GetAny(l => l.PaymentId == payment.PaymentId);
        }
        public Payment GetPaymentById(int id)
        {
            return GetFirstOrDefault(l => l.PaymentId == id);
        }
    }
}
