using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessEntities.CommonEntities;
using Data.Model;
using Cargovio.Models;
using Business.Admin.Manager.Interface;
using BusinessEntities.Admin;
namespace Cargovio.Areas.Admin.Controllers
{
    public class ManageCustomerController : ApiController
    {
        IManageCustomerByAdminManager cManager;
        CargovioDbEntities db = new CargovioDbEntities();
        SMS sms = new SMS();
        public ManageCustomerController(IManageCustomerByAdminManager mg)
        {
            cManager = mg;
        }
        [HttpGet]
        [Route("Admin/Api/GetCustomer/{Userid}")]
        public IHttpActionResult GetCustomers(string Userid)
        {
            try
            {
                int id = Convert.ToInt32(Userid);
                var data = db.UserRegistrations.Where(m => m.Id == id).FirstOrDefault();
                int OfficeId = Convert.ToInt32(data.OfficeId);
                return Ok(cManager.getCustomer(OfficeId));
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        [HttpPost]
        [Route("Admin/Api/VerifyCustomer/{Userid}")]
        public IHttpActionResult VerifyCustomer(string Userid)
        {
            try
            {
                int uid = Convert.ToInt32(Userid);
                var data = db.UserRegistrations.Where(m => m.Id == uid).FirstOrDefault();
                string Message = "Your Verification Is Done With Cargovio.in Now You Can Login On Cargovio.in And Use The Service Provide By Us. Thankyou";
                sms.Send(data.ContactNo, Message);
                return Ok(cManager.VerifyCustomer(Convert.ToInt32(Userid)));
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        [HttpGet]
        [Route("Admin/Api/Getcustomer")]
        public IHttpActionResult GetCustomer()
        {
            try
            {
                return Ok(cManager.getAllCustomers().ToList());
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        [HttpGet]
        [Route("Admin/Api/Getcustomeradmin")]
        public IHttpActionResult GetCustomeradmin()
        {
            try
            {
                return Ok(cManager.getCustomerAdmins().ToList());
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        [HttpGet]
        [Route("Admin/Api/GetBooking")]
        public IHttpActionResult GetBookings()
        {
            try
            {
                return Ok(cManager.getBookings().ToList());
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        [HttpGet]
        [Route("Admin/Api/GetBookingdetails/{ShipmentId}")]
        public IHttpActionResult GetBookingdetails(string ShipmentId)
        {
            try
            {
                return Ok(cManager.getBookingDetails(ShipmentId).ToList());
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        [HttpGet]
        [Route("Admin/Api/GetQuotationlist")]
        public IHttpActionResult GetQuotationList()
        {
            try
            {
                return Ok(cManager.getQuotations().ToList());
            }
            catch (Exception _ex)
            {
                return Ok(_ex);
            }
        }
        [HttpGet]
        [Route("Admin/Api/Getdeliveredshipments")]
        public IHttpActionResult Getdeliveredshipments()
        {
            try
            {
                return Ok(cManager.getDeliveredShipments());
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        [HttpPost]
        [Route("Admin/Api/Rates/Add")]
        public object AddRates(RatesModel rate)
        {
            rate.CreatedDate = DateTime.Now;
            rate.IsActive = true;
            cManager.AddRates(rate);
            return Ok();
        }
        [HttpGet]
        [Route("Admin/Api/Rates/Get")]
        public IHttpActionResult GetRates()
        {
            try
            {
                return Ok(cManager.GetRates());
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpDelete]
        [Route("Admin/Api/Rates/DeleteRate")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                return Ok(cManager.DeleteRates(id));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
