using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Model;
using Data.CustomerAdmin.Repoitory.Interface;
using Common;
using BusinessEntities.Customer;
using BusinessEntities.CommonEntities;
namespace Data.CustomerAdmin.Repoitory
{
    public class CustomerRepository : ICustomerRepository
    {
        public IList<CommonCustomerEntities> GetAllCustomer(int Officeid)
        {
            var Data = (from ur in db.UserRegistrations
                        join cd in db.CompanyDetails on ur.Id equals cd.UserId
                        where ur.IsVerify == true && ur.OfficeId == Officeid
                        select new CommonCustomerEntities
                        {
                            Addressline1 = ur.Addressline1,
                            Addressline2 = ur.Addressline2,
                            City = ur.City,
                            CompanyName = cd.CompanyName,
                            CompanySize = cd.CompanySize,
                            ContactNo = ur.ContactNo,
                            Country = ur.Country,
                            CreatedDate = ur.CreatedDate,
                            C_City = cd.City,
                            C_Country = cd.Country,
                            C_State = cd.State,
                            Email = ur.Email,
                            State = ur.State,
                            Id = ur.Id,
                            IsActive = ur.IsActive,
                            IsVerify = ur.IsVerify,

                            PinCode = ur.PinCode,
                            UpdatedDate = ur.UpdatedDate,
                            Username = ur.Username,
                            UserTypeId = ur.UserTypeId,
                            WebSiteLink = cd.WebSiteLink
                        }).ToList();

            return Data;
        }
        private CargovioDbEntities db = new CargovioDbEntities();
        public IList<CommonBookingEntities> GetMyShipments(int OfficeId)
        {

            var BookingData = (from tr in db.Trackings
                               join bd in db.tblBookings on tr.BookingId equals bd.ID
                               join cr in db.CargoStatusTypes on tr.CargoStatusTypeId equals cr.Id
                               join da in db.tblDestinations on bd.DestinationId equals da.ID
                               join sa in db.tblSources on bd.SourceId equals sa.ID
                               join ur in db.UserRegistrations on bd.Userid equals ur.Id
                               join cd in db.CompanyDetails on ur.Id equals cd.UserId
                               join pd in db.tblPackageDetails on bd.PackageDetailsId equals pd.Id
                               where bd.OfficeId == OfficeId && tr.IsCurrent == true && bd.IsCurrent == true && tr.IsDelivered == false && bd.IsDelivered == false
                               select new CommonBookingEntities
                               {
                                   ID = bd.ID,
                                   Amount = bd.Amount,
                                   EmailId = ur.Email,
                                   SourceCity = sa.SourceCity,
                                   SourcePincode = sa.SourcePincode,
                                   DestinationCity = da.DestinationCity,
                                   DestinationPincode = da.DestinationPincode,
                                   Packagename = pd.Packagename,
                                   Quantity = pd.Quantity,
                                   ShipmentId = bd.ShipmentId,
                                   CargoLocation = tr.CurrentLocation,
                                   CargoStatus = cr.StatusName,
                                   CompanyName = cd.CompanyName,
                                   CustomerName = ur.Username,
                                   Weight = pd.Weight,
                                   Width = pd.Width,
                                   DestinationAddress1 = da.DestinationAddress1,
                                   DestinationAddress2 = da.DestinationAddress2,
                                   DestinationCompanyName = da.CompanyName,
                                   DestinationCountry = da.DestinationCountry,
                                   DestinationCustomerName = da.CustomerName,
                                   DestinationDocumentName = da.DestinationDocumentName,
                                   DestinationDocumentNumber = da.DestinationDocumentNumber,
                                   DestinationEmailId = da.Emailid,
                                   DestinationPhone = da.Phone,
                                   DestinationState = da.DestinationState,
                                   Phone = ur.ContactNo,
                                   Height = pd.Height,
                                   Lenght = pd.Lenght,
                                   PaymentType = bd.PaymentType,
                                   SourceAddress1 = sa.SourceAddress1,
                                   SourceAddress2 = sa.SourceAddress2,
                                   SourceCountry = sa.SourceCountry,
                                   SourceState = sa.SourceState,
                                   CreatedDate = bd.CreatedDate.ToString()


                               }).ToList();
            return BookingData;
        }

        public IQueryable<CargoStatusType> GetCargoStatus()
        {
            return db.CargoStatusTypes;
        }

        public IQueryable<Office> GetAllOffice()
        {
            return db.Offices.Where(m => m.IsActive == true);
        }

        public IList<CommonBookingEntities> GetOldShipments(int OfficeId)
        {
            var BookingData = (from tr in db.Trackings
                               join bd in db.tblBookings on tr.BookingId equals bd.ID
                               join cr in db.CargoStatusTypes on tr.CargoStatusTypeId equals cr.Id
                               join da in db.tblDestinations on bd.DestinationId equals da.ID
                               join sa in db.tblSources on bd.SourceId equals sa.ID
                               join ur in db.UserRegistrations on bd.Userid equals ur.Id
                               join cd in db.CompanyDetails on ur.Id equals cd.UserId
                               join pd in db.tblPackageDetails on bd.PackageDetailsId equals pd.Id
                               where bd.OfficeId == OfficeId && tr.IsCurrent == false && bd.IsCurrent == false
                               select new CommonBookingEntities
                               {
                                   ID = bd.ID,
                                   Amount = bd.Amount,
                                   EmailId = ur.Email,
                                   SourceCity = sa.SourceCity,
                                   SourcePincode = sa.SourcePincode,
                                   DestinationCity = da.DestinationCity,
                                   DestinationPincode = da.DestinationPincode,
                                   Packagename = pd.Packagename,
                                   Quantity = pd.Quantity,
                                   ShipmentId = bd.ShipmentId,
                                   CargoLocation = tr.CurrentLocation,
                                   CargoStatus = cr.StatusName,
                                   CompanyName = cd.CompanyName,
                                   CustomerName = ur.Username,
                                   Weight = pd.Weight,
                                   Width = pd.Width,
                                   DestinationAddress1 = da.DestinationAddress1,
                                   DestinationAddress2 = da.DestinationAddress2,
                                   DestinationCompanyName = da.CompanyName,
                                   DestinationCountry = da.DestinationCountry,
                                   DestinationCustomerName = da.CustomerName,
                                   DestinationDocumentName = da.DestinationDocumentName,
                                   DestinationDocumentNumber = da.DestinationDocumentNumber,
                                   DestinationEmailId = da.Emailid,
                                   DestinationPhone = da.Phone,
                                   DestinationState = da.DestinationState,
                                   Phone = ur.ContactNo,
                                   Height = pd.Height,
                                   Lenght = pd.Lenght,
                                   PaymentType = bd.PaymentType,
                                   SourceAddress1 = sa.SourceAddress1,
                                   SourceAddress2 = sa.SourceAddress2,
                                   SourceCountry = sa.SourceCountry,
                                   SourceState = sa.SourceState,
                                   CreatedDate = bd.CreatedDate.ToString()


                               }).ToList();
            return BookingData;
        }

        public bool UpdateTracking(int Statusid, int BookingId, int OfficeId, int Userid)
        {
            var data = db.Trackings.Where(m => m.BookingId == BookingId).ToList();
            var bookingdata = db.tblBookings.Where(m => m.ID == BookingId).ToList();
            int? CreatedBy = 0;
            foreach (var item in data)
            {
                CreatedBy = item.CreatedBy;
                break;
            }
            Tracking te;
            tblBooking be;
            foreach (var item in data)
            {
                te = db.Trackings.Find(item.Id);
                te.IsCurrent = false;
                db.Entry(te).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                te = null;
            }
            foreach (var item in bookingdata)
            {
                be = db.tblBookings.Find(item.ID);
                be.IsCurrent = false;
                db.Entry(be).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                be = null;
            }
            bool cntr = true;
            int newBookingId = 0;
            foreach (var item in bookingdata)
            {

                if (cntr)
                {
                    tblBooking newBooking = new tblBooking();
                    newBooking.Amount = item.Amount;
                    newBooking.CreatedBy = item.CreatedBy;
                    newBooking.CreatedDate = item.CreatedDate;
                    newBooking.DestinationId = item.DestinationId;
                    newBooking.IsActive = true;
                    newBooking.Userid = CreatedBy;
                    newBooking.IsCurrent = true;
                    newBooking.IsDelivered = false;
                    newBooking.IsPickUp = true;
                    newBooking.OfficeId = OfficeId;
                    newBooking.PackageDetailsId = item.PackageDetailsId;
                    newBooking.PaymentType = item.PaymentType;
                    newBooking.ShipmentId = item.ShipmentId;
                    newBooking.SourceId = item.SourceId;
                    newBooking.TransactionId = item.TransactionId;
                    newBooking.UpdatedBy = Userid;
                    newBooking.UpdatedDate = DateTime.Now;
                    db.tblBookings.Add(newBooking);
                    db.SaveChanges();
                    newBookingId = newBooking.ID;
                    cntr = false;
                    break;
                }
            }
            var officelist = db.Offices.Where(m => m.Id == OfficeId).FirstOrDefault();
            string City = officelist.BranchLocation;
            Tracking te1 = new Tracking();
            te1.IsActive = true;
            te1.IsCurrent = true;
            te1.IsDelivered = false;
            te1.UpdatedBy = Userid;
            te1.CreatedBy = CreatedBy;
            te1.CargoStatusTypeId = Statusid;
            te1.CurrentLocation = City;
            te1.BookingId = newBookingId;
            db.Trackings.Add(te1);
            db.SaveChanges();
            return true;
        }

        public bool DeliveredTracking(int Statusid, int BookingId, int OfficeId, int Userid)
        {
            var data = db.Trackings.Where(m => m.BookingId == BookingId).ToList();
            var bookingdata = db.tblBookings.Where(m => m.ID == BookingId).ToList();
            int? CreatedBy = 0;
            foreach (var item in data)
            {
                CreatedBy = item.CreatedBy;
                break;
            }
            Tracking te;
            tblBooking be;
            foreach (var item in data)
            {
                te = db.Trackings.Find(item.Id);
                te.IsCurrent = false;
                db.Entry(te).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                te = null;
            }
            foreach (var item in bookingdata)
            {
                be = db.tblBookings.Find(item.ID);
                be.IsCurrent = false;
                db.Entry(be).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                be = null;
            }
            bool cntr = true;
            int newBookingId = 0;
            foreach (var item in bookingdata)
            {

                if (cntr)
                {
                    tblBooking newBooking = new tblBooking();
                    newBooking.Amount = item.Amount;
                    newBooking.CreatedBy = item.CreatedBy;
                    newBooking.CreatedDate = item.CreatedDate;
                    newBooking.DestinationId = item.DestinationId;
                    newBooking.IsActive = true;
                    newBooking.Userid = CreatedBy;
                    newBooking.IsCurrent = true;
                    newBooking.IsDelivered = true;
                    newBooking.IsPickUp = true;
                    newBooking.OfficeId = OfficeId;
                    newBooking.PackageDetailsId = item.PackageDetailsId;
                    newBooking.PaymentType = item.PaymentType;
                    newBooking.ShipmentId = item.ShipmentId;
                    newBooking.SourceId = item.SourceId;
                    newBooking.TransactionId = item.TransactionId;
                    newBooking.UpdatedBy = Userid;
                    newBooking.UpdatedDate = DateTime.Now;
                    db.tblBookings.Add(newBooking);
                    db.SaveChanges();
                    newBookingId = newBooking.ID;
                    cntr = false;
                    break;
                }
            }
            var officelist = db.Offices.Where(m => m.Id == OfficeId).FirstOrDefault();
            string City = officelist.BranchLocation;
            Tracking te1 = new Tracking();
            te1.IsActive = true;
            te1.IsCurrent = true;
            te1.IsDelivered = true;
            te1.UpdatedBy = Userid;
            te1.CreatedBy = CreatedBy;
            te1.CargoStatusTypeId = Statusid;
            te1.CurrentLocation = City;
            te1.BookingId = newBookingId;
            db.Trackings.Add(te1);
            db.SaveChanges();
            return true;
        }

        public IList<CommonBookingEntities> GetDeliveredShipments(int OfficeId)
        {
            var BookingData = (from tr in db.Trackings
                               join bd in db.tblBookings on tr.BookingId equals bd.ID
                               join cr in db.CargoStatusTypes on tr.CargoStatusTypeId equals cr.Id
                               join da in db.tblDestinations on bd.DestinationId equals da.ID
                               join sa in db.tblSources on bd.SourceId equals sa.ID
                               join ur in db.UserRegistrations on bd.Userid equals ur.Id
                               join cd in db.CompanyDetails on ur.Id equals cd.UserId
                               join pd in db.tblPackageDetails on bd.PackageDetailsId equals pd.Id
                               where bd.OfficeId == OfficeId && tr.IsDelivered == true && bd.IsDelivered == true
                               select new CommonBookingEntities
                               {
                                   ID = bd.ID,
                                   Amount = bd.Amount,
                                   EmailId = ur.Email,
                                   SourceCity = sa.SourceCity,
                                   SourcePincode = sa.SourcePincode,
                                   DestinationCity = da.DestinationCity,
                                   DestinationPincode = da.DestinationPincode,
                                   Packagename = pd.Packagename,
                                   Quantity = pd.Quantity,
                                   ShipmentId = bd.ShipmentId,
                                   CargoLocation = tr.CurrentLocation,
                                   CargoStatus = cr.StatusName,
                                   CompanyName = cd.CompanyName,
                                   CustomerName = ur.Username,
                                   Weight = pd.Weight,
                                   Width = pd.Width,
                                   DestinationAddress1 = da.DestinationAddress1,
                                   DestinationAddress2 = da.DestinationAddress2,
                                   DestinationCompanyName = da.CompanyName,
                                   DestinationCountry = da.DestinationCountry,
                                   DestinationCustomerName = da.CustomerName,
                                   DestinationDocumentName = da.DestinationDocumentName,
                                   DestinationDocumentNumber = da.DestinationDocumentNumber,
                                   DestinationEmailId = da.Emailid,
                                   DestinationPhone = da.Phone,
                                   DestinationState = da.DestinationState,
                                   Phone = ur.ContactNo,
                                   Height = pd.Height,
                                   Lenght = pd.Lenght,
                                   PaymentType = bd.PaymentType,
                                   SourceAddress1 = sa.SourceAddress1,
                                   SourceAddress2 = sa.SourceAddress2,
                                   SourceCountry = sa.SourceCountry,
                                   SourceState = sa.SourceState,
                                   CreatedDate = bd.CreatedDate.ToString(),
                                   UpdatedDate = bd.UpdatedDate.ToString()
                                   

                               }).ToList();
            return BookingData;
        }

        public IList<GetQuotationEntities> GetQuotation(int OfficeId)
        {
            var Data = (from qe in db.tblQuotations
                        join pe in db.tblPackageDetails on qe.PackageDeatilsId equals pe.Id
                        join ur in db.UserRegistrations on qe.UserId equals ur.Id
                        where ur.Id == OfficeId && qe.PackageDeatilsId == pe.Id
                        select new GetQuotationEntities
                        {
                            CreatedBy = qe.CreateBy,
                            CreatedDate = (qe.CreatedDate).ToString(),
                            DestinationAddress1 = qe.DestinationAddress1,
                            DestinationAddress2 = qe.DestinationAddress2,
                            DestinationCity = qe.DestinationCity,
                            DestinationCountry = qe.DestinationCountry,
                            DestinationPincode = qe.DestinationPincode,
                            DestinationState = qe.DestinationState,
                            Height = pe.Height,
                            Amount = qe.Amount,
                            IsActive = qe.IsActive,
                            Lenght = pe.Lenght,
                            PackageDetailsId = pe.Id,
                            PackageId = pe.Id,
                            Packagename = pe.Packagename,
                            Quantity = pe.Quantity,
                            QuotationId = qe.Id,
                            SourceAddress1 = qe.SourceAddress1,
                            SourceAddress2 = qe.SourceAddress2,
                            SourceCity = qe.SourceCity,
                            SourceCountry = qe.SourceCountry,
                            SourcePincode = qe.SourcePincode,
                            SourceState = qe.SourceState,
                            UpdatedBy = qe.UpdatedBy,
                            UpdatedDate = qe.UpdatedDate.ToString(),
                            UserId = qe.UserId,
                            Weight = pe.Weight,
                            Width = pe.Width
                        }).ToList();
            return Data;
        }
    }
}
