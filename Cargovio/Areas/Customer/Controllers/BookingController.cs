﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Cargovio.Areas.Customer.Models;
using AutoMapper;
using Data.Model;
using Cargovio.Models;
using BusinessEntities.Customer;
using Business.Customer.Manager;
using Business.Customer.Manager.Interface;

namespace Cargovio.Areas.Customer.Controllers
{
    public class BookingController : ApiController
    {
        private IBookingManager bookingManager;
        SMS sms = new SMS();
        private static Random random = new Random();
        CargovioDbEntities db = new CargovioDbEntities();
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
                be.Amount = Convert.ToInt32(objCommon.Amount) /100;
                be.CreatedBy = _userId;
                be.CreatedDate = DateTime.Now;
                be.DestinationId = DestinationId;
                be.OfficeId = OfficeId;
                be.PackageDetailsId = PackageId;
                be.PaymentType = objCommon.PaymentType;
                be.ShipmentId = h1.GetShipmentNumber();
                be.SourceId = SourceId;
                be.UpdatedBy = _userId;
                be.UpdatedDate = DateTime.Now;
                be.Userid = _userId;
                be.IsPickUp = false;
                be.IsActive = true;
                be.IsDelivered = false;
                be.IsCurrent = true;
                be.TransactionId = objCommon.TransactionId;
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
                te.IsCurrent = true;
                int TrackingId = bookingManager.AddTracking(te);
                string Message = "Your Booking Is Done With Cargovio.in From " + se.SourceCity + " To " + de.DestinationCity + " With Shipment Id " + be.ShipmentId;
                sms.Send(data.ContactNo, Message);
                string AdminMessage = "You Receive One New Booking From" + se.SourceCity + " To " + de.DestinationCity + " With Shipment Id " + be.ShipmentId;
                sms.Send("9737920098", AdminMessage);
                var data1 = db.UserRegistrations.Where(m => m.UserTypeId == 2 && m.OfficeId == OfficeId).FirstOrDefault();
                string CAdminMessage = "You Receive One New Booking From" + se.SourceCity + " To " + de.DestinationCity + " With Shipment Id " + be.ShipmentId;
                sms.Send(data1.ContactNo, CAdminMessage);
                return Ok(TrackingId);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        [HttpGet]
        [Route("Customer/Api/GetKM")]
        public IHttpActionResult GetRate(string City1,string City2)
        {
            try
            {
                int rate = Convert.ToInt32(bookingManager.getRate(City1, City2));
                
                return Ok(rate);
            }
            catch (Exception)
            {
                return NotFound();
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
        public IHttpActionResult GetBookingDetails(string ShipmentId,int Userid)
        {
            try
            {
                return Ok(bookingManager.GetBookingDetails(ShipmentId,Userid));
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
        [HttpGet]
        [Route("Customer/Api/UpdateBooking/{Bookingid}")]
        public IHttpActionResult UpdateBooking(string Bookingid)
        {
            try
            {
                int bookingid = Convert.ToInt32(Bookingid);
                var data = db.tblBookings.Where(m => m.ID == bookingid).FirstOrDefault();
                if (data.IsPickUp == false)
                {
                    int _packageId = Convert.ToInt32(data.PackageDetailsId);
                    var data1 = bookingManager.GetPackageById(_packageId);
                    return Ok(bookingManager.GetPackageById(_packageId));
                }
                else
                {
                    return Ok("Package Is Already Shipped!.....");
                }
               
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        [HttpPost]
        [Route("Customer/Api/UpdateById")]
        public IHttpActionResult UpdateById(PackageEntities pe)
        {
            try
            {
                return Ok(bookingManager.UpdatePackage(pe));
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        [HttpGet]
        [Route("Customer/Api/Getoldbookings/{Userid}")]
        public IHttpActionResult Getoldbookings(int Userid)
        {
            try
            {
                return Ok(bookingManager.GetOldBooking(Userid).ToList());
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        [HttpGet]
        [Route("Customer/Api/GetMyOffice/{Userid}")]
        public IHttpActionResult GetMyOffice(int Userid)
        {
            try
            {
                return Ok(bookingManager.GetMyoffice(Userid).ToList());
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
       


    }
}
