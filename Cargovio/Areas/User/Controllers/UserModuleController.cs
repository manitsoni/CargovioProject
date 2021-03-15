﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Business;
using Business.User.Manager;
using Business.User.Manager.Interface;
using BusinessEntities.CommonEntities;

using Data.Model;
using Cargovio.Areas.User.Models;
using System.Net.Mail;
using System.IO;

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
                    user.OfficeId = 11;
                    user.UserTypeId = 2;
                }
                else if(_userType =="Customer")
                {
                    var City = user.City;
                    var data = db.Offices.Where(m => m.BranchLocation == City).FirstOrDefault();
                    int OfficeId = data.Id;
                    if (OfficeId  > 0)
                    {
                        user.OfficeId = OfficeId;
                    }
                    else
                    {
                        user.OfficeId = 11;
                    }
                   
                    user.IsVerify = false;
                    user.UserTypeId = 3;
                }
                UserId = userManager.UserRegistration(user);
                string FilePath = "D:\\CargovioProject\\Cargovio\\Common\\MailFormat\\UserRegistration.html";
                StreamReader str = new StreamReader(FilePath);
                string MailText = str.ReadToEnd();


                DateTime time = DateTime.Now;

                MailText = MailText.Replace("{UserName}", user.UserName);
                //MailText = MailText.Replace("{BookingDate}", entity.BookingDate.ToString());
                //MailText = MailText.Replace("{BookingTime}", time.ToString("t"));
                //MailText = MailText.Replace("{PickupAddress}", entity.PickupAddress);
                //MailText = MailText.Replace("{DropAddress}", entity.DropAddress);
                //MailText = MailText.Replace("{Dealer}", dealer.Name);
                //MailText = MailText.Replace("{PhoneNumber}", dealer.PhoneNumber);
                //MailText = MailText.Replace("{Service}", htmlContentService);
                //MailText = MailText.Replace("{Total}", totalAmmount.ToString());
                str.Close();

                MailMessage mail = new MailMessage();
                mail.To.Add(user.Email);
                mail.From = new MailAddress("automobile.onthego@gmail.com");
                mail.Subject = "Appontment Booked";
                string Body = MailText;
                mail.Body = Body;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential("automobile.onthego@gmail.com", "Password@123");
                smtp.EnableSsl = true;
                smtp.Send(mail);
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
                    if (OfficeId > 0)
                    {
                        UserRegistration ur = new UserRegistration();
                        ur = db.UserRegistrations.Find(office.UserId);
                        ur.OfficeId = OfficeId;
                        db.Entry(ur).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        return Ok("Account Created Success!");
                    }
                    else
                    {
                        UserRegistration ur = db.UserRegistrations.Find(office.UserId);
                        db.Entry(ur).State = System.Data.Entity.EntityState.Deleted;
                        db.SaveChanges();
                        return Ok("Office Already Exists!");
                    }
                   

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
                //SessionProxyUser.IsUserLogin = false;
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
