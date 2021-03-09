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
using Cargovio.Helper;
using Data.Model;
using Cargovio.Areas.User.Models;
namespace Cargovio.Areas.User.Controllers
{
    public class UserModuleController : ApiController
    {
        private IUserManager userManager;
        private int UserId;
        CargovioDbEntities db = new CargovioDbEntities();
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
                    user.IsVerify = true;
                    user.OfficeId = 2;
                    user.UserTypeId = 2;
                }
                else if(_userType =="Customer")
                {
                    var City = user.City;
                    var data = db.Offices.Where(m => m.City == City).FirstOrDefault();
                    int OfficeId = data.Id;
                    if (OfficeId  > 0)
                    {
                        user.OfficeId = OfficeId;
                    }
                    else
                    {
                        user.OfficeId = 6;
                    }
                   
                    user.IsVerify = false;
                    user.UserTypeId = 3;
                }
                UserId = userManager.UserRegistration(user);
                if (UserId == 0)
                {
                    return NotFound();
                }
                else{
                    return Ok(UserId);
                }
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        [Route("User/Api/UserModule/CompanyRegister")]
        [HttpPost]
        public IHttpActionResult CompanyRegister(CompanyDetailsEntities company)
        {
            try
            {
                if (company.UserId > 0)
                {
                    company.IsActive = true;
                    company.CreatedDate = DateTime.Now;
                    company.CopmanyAddress1 = company.City;
                    company.CopmanyAddress2 = company.City;
                    return Ok(userManager.CompanyDetails(company));
                }
                else
                {
                    return Ok("Please Register First!");
                }

            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        [Route("User/Api/UserModule/OfficeRegister")]
        [HttpPost]
        public IHttpActionResult OfficeRegister(OfficeDetailsEntities office)
        {
            try
            {
                if (office.UserId !=0)
                {
                    
                    office.IsActive = true;
                    office.CreatedDate = DateTime.Now;
                    office.UserId = office.UserId;
                    office.OfficeLocation = office.City;
                    int OfficeId = userManager.OfficeDetails(office);
                    UserRegistration ur = new UserRegistration();
                    ur = db.UserRegistrations.Find(office.UserId);
                    ur.OfficeId = OfficeId;
                    db.Entry(ur).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return Ok(OfficeId);

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
                //int TypeId = Convert.ToInt32(db.UserRegistrations.Where(m => m.Id == _userId).Select(m => m.UserTypeId));
                if (_userId == 0)
                {
                    return NotFound();
                }
                else
                {
                    //userManager.BindToSession(_userId).ToList();
                    // BindToSession(_userId);

                    return Ok(_userId);
                }
            }
            catch (NullReferenceException ex)
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

       
        [HttpGet]
        [Route("User/Api/UserModule/GetTypeId/{Userid}")]
        public IHttpActionResult GetTypeId(int Userid)
        {
            var data = db.UserRegistrations.Where(m => m.Id == Userid).FirstOrDefault();
            int TypeId = data.UserTypeId;
            return Ok(TypeId);
        }
    }
}
