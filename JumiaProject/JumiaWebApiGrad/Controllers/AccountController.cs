using BL.AppServices;
using BL.StatisClass;
using BL.ViewModels;
using DAL.Models;
using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace JumiaWebApiGrad.Controllers
{
    public class AccountController : ApiController
    {
        private AccountAppServices _accountAppService;
        private CartAppServices _cartAppService;
        private ViewsAppServices _viewAppService;
        private RoleAppServices _roleAppService;
        IHttpContextAccessor _httpContextAccessor;
        public AccountController(
             AccountAppServices accountAppService,
            CartAppServices cartAppService,
            ViewsAppServices viewAppService,
            RoleAppServices roleAppService,
            IHttpContextAccessor httpContextAccessor
            )
        {
            _accountAppService = accountAppService;
            _cartAppService = cartAppService;
            _viewAppService = viewAppService;
            _roleAppService = roleAppService;
            _httpContextAccessor = httpContextAccessor;
        }
        [HttpPost]
        public IHttpActionResult RegisterUser([FromBody] RegisterViewModel model)
        {

            return  Register(model, UserRoles.Customer);

        }
        private IHttpActionResult Register(RegisterViewModel model, string roleName)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result =  _accountAppService.Register(model);

            if (!result.Succeeded)
                return StatusCode(HttpStatusCode.InternalServerError);

            applicationUser identityUser =  _accountAppService.Find(model.UserName, model.Password);
            #region oldCreateCartWishlist
            ////create cart for new user
            //CartViewModel cartViewModel = new CartViewModel() { ApplicationUserIdentity_Id = identityUser.Id };
            //_cartAppService.SaveNewCart(cartViewModel);

            //WishlistViewModel wishlistViewModel = new WishlistViewModel() { ApplicationUserIdentity_Id = identityUser.Id };
            //_wishlistAppService.SaveNewWishlist(wishlistViewModel);
            #endregion
            //create roles
            //await _roleAppService.CreateRoles();
             _accountAppService.AssignToRole(identityUser.Id, roleName);
            return Ok( "User created successfully!");

        }
    }
}
