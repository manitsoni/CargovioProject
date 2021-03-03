using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Business;
using Business.User.Manager;
using Business.User.Manager.Interface;
using BusinessEntities.CommonEntities;
using Common;
namespace Cargovio.Areas.User.Controllers
{
    public class UserModuleController : ApiController
    {
        private IUserManager userManager;
        private int UserId =0;
        private string UserType = "";
        public UserModuleController(IUserManager user)
        {
            userManager = user;
        }
        [Route("User/Api/UserModule/Registration")]
        [HttpPost]
        public IHttpActionResult Registration(UserRegistrationEntities user,string _userType)
        {
            try
            {
                user.IsActive = true;
                user.CreatedDate = DateTime.Now;
                user.UpdatedDate = DateTime.Now;
                UserType = _userType;
                if (_userType == "CustomerAdmin")
                {
                    user.UserTypeId = 2;
                }
                else if(_userType =="Customer")
                {
                    user.UserTypeId = 3;
                }
                UserId = userManager.UserRegistration(user);
                if (UserId == 0)
                {
                    return NotFound();
                }
                else{
                    return Ok();
                }
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        [Route("User/Api/UserModule/CompanyRegister")]
        [HttpPost]
        public IHttpActionResult CompanyRegister(CompanyDetailsEntities company)
        {
            try
            {
                if (UserId != 0 && UserType =="Customer")
                {
                    company.IsActibe = true;
                    company.CreatedDate = DateTime.Now;
                    company.UserId = UserId;
                    return Ok(userManager.CompanyDetails(company));
                }
                else
                {
                    return NotFound();
                }
               
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        [Route("User/Api/UserModule/OfficeRegister")]
        [HttpPost]
        public IHttpActionResult OfficeRegister(OfficeDetailsEntities office)
        {
            try
            {
                if (UserId !=0 && UserType == "CustomerAdmin")
                {
                    office.IsActive = true;
                    office.CreatedDate = DateTime.Now;
                    office.UserId = UserId;
                    return Ok(userManager.OfficeDetails(office));

                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {

                return NotFound();
            }
        }
        [Route("User/Api/UserModule/Login")]
        [HttpPost]
        public IHttpActionResult Login(string Email,string Password)
        {
            try
            {
                int _userId = userManager.Login(Email, Password);
                if (_userId == 0)
                {
                    return NotFound();
                }
                else
                {
                    userManager.BindToSession(_userId).ToList();
                    return Ok();
                }
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        [Route("User/Api/UserModule/LogOut")]
        [HttpPost]
        public IHttpActionResult LogOut()
        {
            try
            {
                SessionProxyUser.IsUserLogin = false;
                return Ok();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
