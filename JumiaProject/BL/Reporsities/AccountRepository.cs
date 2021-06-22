using DAL.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Reporsities
{
   public class AccountRepository:Basices.BaseRepository<applicationUser>
    {
        ApplicationUserManager manager;

        public AccountRepository(DbContext db) : base(db)
        {
            manager = new ApplicationUserManager(db);
        }
       
        
        public applicationUser GetAccountById(string id)
        {
            return GetFirstOrDefault(a => a.Id == id);
        }
        public List<applicationUser> GetAllAccounts()
        {
            return GetAll().ToList();
        }
        public applicationUser FindById(string id)
        {
            applicationUser result = manager.FindById(id);
            return result;
        }
        public applicationUser Find(string username, string password)
        {
            applicationUser result = manager.Find(username, password);
            return result;
        }
        public IdentityResult Register(applicationUser user)
        {
            IdentityResult result = manager.Create(user, user.PasswordHash);
            return result;
        }
        public IdentityResult AssignToRole(string userid, string rolename)
        {
            IdentityResult result = manager.AddToRole(userid, rolename);
            return result;
        }
        public bool updatePassword(applicationUser user)
        {
            user.PasswordHash = manager.PasswordHasher.HashPassword(user.PasswordHash);
            IdentityResult result = manager.Update(user);
            return true;
        }

        public bool UpdateAccount(applicationUser user)
        {
            IdentityResult result = manager.Update(user);
            return true;
        }
    }
}
