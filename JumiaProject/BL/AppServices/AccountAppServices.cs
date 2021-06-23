using BL.Basices;
using BL.ViewModels;
using DAL.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.AppServices
{
   public class AccountAppServices:AppServiceBase
    {
        //Login
        public List<RegisterViewModel> GetAllAccounts()
        {
            return Mapper.Map<List<RegisterViewModel>>(TheUnitOfWork.Account.GetAllAccounts().Where(ac => ac.Adminlocked == "false"));
        }
        public RegisterViewModel GetAccountById(string id)
        {
            return Mapper.Map<RegisterViewModel>(TheUnitOfWork.Account.GetAccountById(id));
        }
        //public bool DeleteAccount(string id)
        //{
        //    bool result = false;
        //    applicationUser user = TheUnitOfWork.Account.GetAccountById(id);
        //    user.isDeleted = true;
        //    TheUnitOfWork.Account.Update(user);
        //    result = TheUnitOfWork.Commit() > new int();

        //    return result;
        //}
        public applicationUser Find(string name, string passworg)
        {
            var user = TheUnitOfWork.Account.Find(name, passworg);

            if (user != null)
                return user;
            return null;
        }
        public IdentityResult Register(RegisterViewModel user)
        {
            applicationUser identityUser =
                Mapper.Map<RegisterViewModel, applicationUser>(user);
            return TheUnitOfWork.Account.Register(identityUser);
        }
        public IdentityResult AssignToRole(string userid, string rolename)
        {
            return TheUnitOfWork.Account.AssignToRole(userid, rolename);
        }
        public bool UpdatePassword(string userID, string newPassword)
        {
            applicationUser identityUser = TheUnitOfWork.Account.FindById(userID);
            identityUser.PasswordHash = newPassword;
            return TheUnitOfWork.Account.updatePassword(identityUser);
        }
    }
}
