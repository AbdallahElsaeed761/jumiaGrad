﻿using AutoMapper;
using AutoMapper.Configuration;
using BL.Basices;
using BL.Interfaces;
using BL.ViewModels;
using DAL.Models;
using Microsoft.AspNet.Identity;
//using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.AppServices
{
   public class AccountAppServices:AppServiceBase
    {
        IConfiguration _configuration;
        CartAppServices _cartAppService;
        ViewsAppServices _viewsAppServices;
        public AccountAppServices(IUnitofWork theUnitOfWork, CartAppServices cartAppServices,ViewsAppServices viewsAppServices,
           IConfiguration configuration, IMapper mapper):base(theUnitOfWork,mapper)
        {
            _configuration = configuration;
            _cartAppService = cartAppServices;
            _viewsAppServices = viewsAppServices;

        }
        private void CreateCustomerCartAndView(string CustomerId)
        {
            _viewsAppServices.CreateUserWishlist(CustomerId);
            _cartAppService.CreateUserCart(CustomerId);
        }
        //Login
        public List<RegisterViewModel> GetAllAccounts()
        {
            return Mapper.Map<List<RegisterViewModel>>(TheUnitOfWork.Account.GetAllAccounts().Where(ac => ac.Adminlocked == "false"));
        }
        public RegisterViewModel GetAccountById(string id)
        {
            if (id == null)
                throw new ArgumentNullException();
            return Mapper.Map<RegisterViewModel>(TheUnitOfWork.Account.GetAccountById(id));
        }
        public bool DeleteAccount(string id)
        {
            if (id == null)
                throw new ArgumentNullException();
            bool result = false;
            applicationUser user = TheUnitOfWork.Account.GetAccountById(id);
            user.Adminlocked = "true";
            TheUnitOfWork.Account.Update(user);
            result = TheUnitOfWork.Commit() > new int();

            return result;
        }
        public applicationUser Find(string name, string passworg)
        {
            var user = TheUnitOfWork.Account.Find(name, passworg);

            if (user != null)
                return user;
            return null;
        }
        public applicationUser FindByName(string userName)
        {
            applicationUser user =  TheUnitOfWork.Account.FindByName(userName);

            if (user != null)
                return user;
            return null;
        }
        public bool checkUserNameExist(string userName)
        {
            var user =  TheUnitOfWork.Account.FindByName(userName);
            return user == null ? false : true;
        }

        //public IdentityResult Register(RegisterViewModel user)
        //{
        //     bool isExist =  checkUserNameExist (user.Fname);
        //    if(isExist)
        //        return IdentityResult.Failed(new IdentityError
        //        { Code = "error", Description = "user name already exist" });
        //    applicationUser identityUser =
        //        Mapper.Map<RegisterViewModel, applicationUser>(user);
        //    return TheUnitOfWork.Account.Register(identityUser);
        //}
        public IdentityResult Register(RegisterViewModel user)
        {
            bool isExist =  checkUserNameExist(user.UserName);
            if (isExist)
                //return IdentityResult.Failed(new 
                //{ Code = "error", Description = "user name already exist" });
                return IdentityResult.Failed("user name already exist");

            applicationUser identityUser = Mapper.Map<RegisterViewModel, applicationUser>(user);
            var result =  TheUnitOfWork.Account.Register(identityUser);
            // create user cart and View 
            if (result.Succeeded)
            {
                CreateCustomerCartAndView(identityUser.Id);
            }
            return result;
        }

        public IdentityResult AssignToRole(string userid, string rolename)
        {
            if (userid == null || rolename == null)
                return null;
            return TheUnitOfWork.Account.AssignToRole(userid, rolename);
        }
        public bool UpdatePassword(string userID, string newPassword)
        {
            applicationUser identityUser = TheUnitOfWork.Account.FindById(userID);
            identityUser.PasswordHash = newPassword;
            return TheUnitOfWork.Account.updatePassword(identityUser);
        }
        public bool Update(RegisterViewModel user)
        {
            //    ApplicationUserIdentity identityUser = TheUnitOfWork.Account.FindById(user.Id);

            //    Mapper.Map(user, identityUser);

            //    return TheUnitOfWork.Account.UpdateAccount(identityUser);


            applicationUser identityUser =  TheUnitOfWork.Account.FindById(user.Id);
            var oldPassword = identityUser.PasswordHash;
            Mapper.Map(user, identityUser);
            identityUser.PasswordHash = oldPassword;
            return  TheUnitOfWork.Account.UpdateAccount(identityUser);

        }
    }
}
