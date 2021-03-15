using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessEntities.Customer;
using Business.CustomerAdmin.Manager.Interface;
using Data.Model;
namespace Cargovio.Areas.CustomerAdmin.Controllers
{
    public class CustomerAdminManageController : ApiController
    {
        public ICustomerAdminManager customer;
        CargovioDbEntities db = new CargovioDbEntities();
        public CustomerAdminManageController(ICustomerAdminManager cust)
        {
            customer = cust;
        }
        [HttpGet]
        [Route("CustomerAdmin/Api/GetMyShipments/{Userid}")]
        public IHttpActionResult GetMyShipments(string Userid)
        {
            try
            {
                CargovioDbEntities db = new CargovioDbEntities();
                int id = Convert.ToInt32(Userid);
                var data = db.UserRegistrations.Where(m => m.Id == id).FirstOrDefault();
                int OfficeId = Convert.ToInt32(data.OfficeId);
                return Ok(customer.GetMyShipments(OfficeId));
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        [HttpGet]
        [Route("CustomerAdmin/Api/GetStatus")]
        public IHttpActionResult GetStatus()
        {
            try
            {
                return Ok(customer.GetCargoStatus());
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        [HttpGet]
        [Route("CUstomerAdmin/Api/GetOffice")]
        public IHttpActionResult GetOffice()
        {
            try
            {
                return Ok(customer.GetOffice());
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }

        [HttpGet]
        [Route("CustomerAdmin/Api/GetCustomer/{Userid}")]
        public IHttpActionResult GetAllCustomer(int Userid)
        {
            try
            {
                var data = db.UserRegistrations.Where(m => m.Id == Userid).FirstOrDefault();
                int OfficeId = Convert.ToInt32(data.OfficeId);
                return Ok(customer.GetCustomer(OfficeId).ToList());
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }

        [HttpPost]
        [Route("CustomerAdmin/Api/UpdateTracking")]
        public IHttpActionResult UpdateTracking(string sid,string bid,string oid,string uid)
        {
            try
            {
                int StatusId = Convert.ToInt32(sid);
                int BookingId = Convert.ToInt32(bid);
                int OfficeId = Convert.ToInt32(oid);
                int Userid = Convert.ToInt32(uid);

                var data = db.CargoStatusTypes.Where(m => m.Id == StatusId).FirstOrDefault();
                var StatusName = data.StatusName;

                var data1 = db.tblBookings.Where(m => m.ID == BookingId).FirstOrDefault();
                int destid = Convert.ToInt32(data1.DestinationId);
                var destdata = db.tblDestinations.Where(m => m.ID == destid).FirstOrDefault();
                var destcity = destdata.DestinationCity;

                var officedata = db.Offices.Where(m => m.Id == OfficeId).FirstOrDefault();
                var CurrentCity = officedata.BranchLocation;
                string sname = StatusName.ToString();
                if (sname == "Delivered" && CurrentCity == destcity)
                {
                    //code for delivered product
                    customer.DeliveredShipment(StatusId, BookingId, OfficeId, Userid);
                }
                else
                {
                    customer.UpdateTracking(StatusId, BookingId, OfficeId, Userid);
                }
                
                return Ok();
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        [HttpGet]
        [Route("CustomerAdmin/Api/GetOldShipments/{Userid}")]
        public IHttpActionResult GetOldShipments(int Userid)
        {
            try
            {
                var data = db.Offices.Where(m => m.UserId == Userid).FirstOrDefault();
                int Officeid = data.Id;
                return Ok(customer.GetOldShipments(Officeid).ToList());
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }

        [HttpGet]
        [Route("CustomerAdmin/Api/Getdeliveredshipments/{Userid}")]
        public IHttpActionResult Getdeliveredshipments(int Userid)
        {
            try
            {
                var data = db.Offices.Where(m => m.UserId == Userid).FirstOrDefault();
                int Officeid = data.Id;
                return Ok(customer.GetDeliveredShipments(Officeid).ToList());
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }

        [HttpGet]
        [Route("CustomerAdmin/Api/GetQuotation/{UserId}")]
        public IHttpActionResult GetQuotation(int Userid)
        {
            try
            {
                var data = db.Offices.Where(m => m.UserId == Userid).FirstOrDefault();
                int Officeid = data.Id;
                return Ok(customer.GetQuotationlist(Officeid).ToList());
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
    }
}
