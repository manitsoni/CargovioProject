using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Common;
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
        private Helper helper = new Helper();
        public BookingController(IBookingManager booking)
        {
            bookingManager = booking;
        }
        [HttpPost]
        [Route("Customer/Api/Book")]
        public IHttpActionResult Book(CommonBookingEntities objCommon)
        {
            try
            {
                //Add Source Address To DB
                SourceAddressEntities se = new SourceAddressEntities();
                se.CompanyName = objCommon.CompanyName;
                se.CreatedDate = DateTime.Now;
                se.CustomerName = SessionProxyUser.Name;
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
                de.CustomerName = SessionProxyUser.Name;
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
                pe.CreatedBy = SessionProxyUser.UserID;
                pe.Height = objCommon.Height;
                pe.IsActive = true;
                pe.Lenght = objCommon.Lenght;
                pe.Packagename = objCommon.Packagename;
                pe.Quantity = objCommon.Quantity;
                pe.UserId = SessionProxyUser.UserID;
                pe.Weight = objCommon.Weight;
                pe.Width = objCommon.Width;
                int PackageId = bookingManager.AddPackage(pe);
                CargovioDbEntities db = new CargovioDbEntities();
               
                //Get OfficeId
                

                string City = SessionProxyUser.City;
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
                be.CreatedBy = SessionProxyUser.UserID;
                be.CreatedDate = DateTime.Now;
                be.DestinationId = DestinationId;
                be.OfficeId = OfficeId;
                be.ShipmentId = helper.GetShipmentNumber();
                be.SourceId = SourceId;
                be.TransactionId = 101;
                be.UpdatedBy = SessionProxyUser.UserID;
                be.UpdatedDate = DateTime.Now;
                be.Userid = SessionProxyUser.UserID;
                int BookingId = bookingManager.AddBooking(be);

                //Add Tracking Info in DB
                TrackingEntities te = new TrackingEntities();
                te.BookingId = BookingId;
                te.CargoStatusTypeId = 1;
                te.CreatedBy = SessionProxyUser.UserID;
                te.CurrentLocation = SessionProxyUser.City;
                te.IsActive = true;
                te.IsDelivered = false;
                te.UpdatedBy = OfficeUserId;
                int TrackingId = bookingManager.AddTracking(te);

                return Ok(TrackingId);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        
    }
}
