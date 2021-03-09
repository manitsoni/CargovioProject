using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using AutoMapper;
using Data.Model;
using BusinessEntities.Customer;
using Business.Customer.Manager;
using Business.Customer.Manager.Interface;
using Cargovio.Areas.Customer.Models;
namespace Cargovio.Areas.Customer.Controllers
{
    public class BookingController : ApiController
    {
        private IBookingManager bookingManager;
       
        private static Random random = new Random();
       
        public BookingController(IBookingManager booking)
        {
            bookingManager = booking;
        }
        [HttpPost]
        [Route("Customer/Api/Book/{Userid}")]
        public IHttpActionResult Book(CommonBookingEntities objCommon,string Userid)
        {
            try
            {
                CargovioDbEntities db = new CargovioDbEntities();
                //Add Source Address To DB
                int _userId = Convert.ToInt32(Userid);
                var data = db.UserRegistrations.Where(m => m.Id == _userId).FirstOrDefault();
                SourceAddressEntities se = new SourceAddressEntities();
                se.CompanyName = objCommon.CompanyName;
                se.CreatedDate = DateTime.Now;
                se.CustomerName = data.Username;
                se.DocumentName = objCommon.DocumentName;
                se.DocumentNumber = objCommon.DocumentNumber;
                se.EmailId = objCommon.EmailId;
                se.IsActive = true;
                se.Phone = objCommon.Phone;
                se.SourceAddress1 = objCommon.SourceAddress1;
                se.SourceAddress2 = objCommon.SourceAddress2;
                se.SourceCity = objCommon.SourceCity;
                se.SourceState = objCommon.SourceState;
                se.SourceCountry = objCommon.SourceCountry;
                se.SourcePincode = objCommon.SourcePincode;
                se.UpdatedDate = DateTime.Now;
                int SourceId = bookingManager.AddSourceAddress(se);

                //Add Destination Address To DB
                DestinationAddressEntities de = new DestinationAddressEntities();
                de.CompanyName = objCommon.DestinationCompanyName;
                de.CreatedDate = DateTime.Now;
                de.CustomerName = data.Username;
                de.DocumentName = objCommon.DestinationDocumentName;
                de.DocumentNumber = objCommon.DestinationDocumentNumber;
                de.EmailId = objCommon.DestinationEmailId;
                de.IsActive = true;
                de.Phone = objCommon.DestinationPhone;
                de.DestinationAddress1 = objCommon.DestinationAddress1;
                de.DestinationAddress2 = objCommon.DestinationAddress2;
                de.DestinationCity = objCommon.DestinationCity;
                de.DestinationState = objCommon.DestinationState;
                de.DestinationCountry = objCommon.DestinationCountry;
                de.DestinationPincode = objCommon.DestinationPincode;
                de.UpdatedDate = DateTime.Now;
                int DestinationId = bookingManager.AddDestinationAddress(de);

                //Add Package Details To DB
                PackageEntities pe = new PackageEntities();
                pe.CreatedBy = _userId;
                pe.Height = objCommon.Height;
                pe.IsActive = true;
                pe.Lenght = objCommon.Lenght;
                pe.Packagename = objCommon.Packagename;
                pe.Quantity = objCommon.Quantity;
                pe.UserId = _userId;
                pe.Weight = objCommon.Weight;
                pe.Width = objCommon.Width;
                int PackageId = bookingManager.AddPackage(pe);


                //Get OfficeId


                string City = data.City;
                int OfficeId;
                int oid = db.Offices.Where(m => m.City == City).Select(m => m.Id).First();
                int OfficeUserId = db.Offices.Where(m => m.City == City).Select(m => m.UserId).FirstOrDefault();
                if (oid > 0)
                {
                    OfficeId = oid;
                }
                else
                {
                    OfficeId = 3;
                }
                //Add Booking Data To DB
                BookingEntities be = new BookingEntities();
                be.Amount = 1500;
                be.CreatedBy = _userId;
                be.CreatedDate = DateTime.Now;
                be.DestinationId = DestinationId;
                be.OfficeId = OfficeId;
                //be.ShipmentId = helper.GetShipmentNumber();
                be.SourceId = SourceId;
                be.TransactionId = 101;
                be.UpdatedBy = _userId;
                be.UpdatedDate = DateTime.Now;
                be.Userid = _userId;
                int BookingId = bookingManager.AddBooking(be);

                //Add Tracking Info in DB
                TrackingEntities te = new TrackingEntities();
                te.BookingId = BookingId;
                te.CargoStatusTypeId = 1;
                te.CreatedBy = _userId;
                te.CurrentLocation = data.City;
                te.IsActive = true;
                te.IsDelivered = false;
                te.UpdatedBy = OfficeUserId;
                int TrackingId = bookingManager.AddTracking(te);
                return Ok(TrackingId);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        [HttpGet]
        [Route("Customer/Api/GetMyBooking/{Userid}")]
        public IHttpActionResult GetBooking(string Userid)
        {
            try
            {
                return Ok(bookingManager.GetBooking(Convert.ToInt32(Userid)));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("Customer/Api/GetMyBookingDetails")]
        public IHttpActionResult GetBookingDetails(string ShipmentId)
        {
            try
            {
                return Ok(bookingManager.GetBookingDetails(ShipmentId));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

    }
}
