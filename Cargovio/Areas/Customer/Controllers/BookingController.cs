using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Cargovio.Areas.Customer.Models;
using AutoMapper;
using Data.Model;
using BusinessEntities.Customer;
using Business.Customer.Manager;
using Business.Customer.Manager.Interface;

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
        [Route("Customer/Api/BookCargo/{Userid}")]
        public IHttpActionResult Book(CommonBookingEntities objCommon,string Userid)
        {
            try
            {
                CargovioDbEntities db = new CargovioDbEntities();
                //Add Source Address To DB
                int _userId = Convert.ToInt32(Userid);
                var data = db.UserRegistrations.Where(m => m.Id == _userId).FirstOrDefault();
                var company = db.CompanyDetails.Where(m => m.UserId == _userId).FirstOrDefault();
                SourceAddressEntities se = new SourceAddressEntities();
                se.CompanyName = company.CompanyName;
                se.CreatedDate = DateTime.Now;
                se.CustomerName = data.Username;
                se.DocumentName = objCommon.DocumentName;
                se.DocumentNumber = objCommon.DocumentNumber;
                se.EmailId = data.Email;
                se.IsActive = true;
                se.Phone = data.ContactNo;
                se.UserId = data.Id;
                se.SourceAddress1 = objCommon.SourceAddress1;
                se.SourceAddress2 = objCommon.SourceAddress2;
                se.SourceCity = objCommon.SourceCity;
                se.SourceState = objCommon.SourceState;
                se.SourceCountry = objCommon.SourceCountry;
                se.SourcePincode = objCommon.SourcePincode;
                se.CreatedBy = data.Id;
                se.SourceDocumentName = objCommon.DestinationDocumentName;
                se.SourceDocumentNumber = objCommon.DestinationDocumentNumber;
                int SourceId = bookingManager.AddSourceAddress(se);

                //Add Destination Address To DB
                DestinationAddressEntities de = new DestinationAddressEntities();
                de.CompanyName = objCommon.DestinationCompanyName;
                de.CreatedDate = DateTime.Now;
                de.CustomerName = data.Username;
                de.DocumentName = objCommon.DestinationDocumentName;
                de.DocumentNumber = objCommon.DestinationDocumentNumber;
                de.EmailId = data.Email;
                de.IsActive = true;
                de.Phone = data.ContactNo;
                de.DestinationAddress1 = objCommon.DestinationAddress1;
                de.DestinationAddress2 = objCommon.DestinationAddress2;
                de.DestinationCity = objCommon.DestinationCity;
                de.DestinationState = objCommon.DestinationState;
                de.DestinationCountry = objCommon.DestinationCountry;
                de.DestinationPincode = objCommon.DestinationPincode;
                de.UpdatedDate = DateTime.Now;
                de.UserId = data.Id;
                de.DocumentName = objCommon.DestinationDocumentName;
                de.DocumentNumber = objCommon.DestinationDocumentNumber;
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


                string City = objCommon.SourceCity;
                int OfficeId;
                int oid = db.Offices.Where(m => m.BranchLocation == City).Select(m => m.Id).First();
                int OfficeUserId = db.Offices.Where(m => m.City == City).Select(m => m.UserId).FirstOrDefault();
                if (oid > 0)
                {
                    OfficeId = oid;
                }
                else
                {
                    OfficeId = 36;
                }
                //Add Booking Data To DB
                BookingEntities be = new BookingEntities();
                Helper h1 = new Helper();
                be.Amount = 1500;
                be.CreatedBy = _userId;
                be.CreatedDate = DateTime.Now;
                be.DestinationId = DestinationId;
                be.OfficeId = OfficeId;
                be.PackageDetailsId = PackageId;
                be.PaymentType = "COD";
                be.ShipmentId = h1.GetShipmentNumber();
                be.SourceId = SourceId;
                be.TransactionId = 101;
                be.UpdatedBy = _userId;
                be.UpdatedDate = DateTime.Now;
                be.Userid = _userId;
                be.IsPickUp = false;
                be.IsActive = true;
                be.IsDelivered = false;
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
        [Route("Customer/Api/GetMyBookingDetails/{ShipmentId}")]
        public IHttpActionResult GetBookingDetails(string ShipmentId)
        {
            try
            {
                return Ok(bookingManager.GetBookingDetails(ShipmentId));
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }

    }
}
