using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities.CommonEntities;
using Data.Admin.Repository.Interface;
using Data.Model;
using BusinessEntities.Customer;
namespace Data.Admin.Repository
{
    public class ManageCustomerRepository : IManageCustomerRepositoryByAdmin
    {
        CargovioDbEntities db = new CargovioDbEntities();

        public IList<CommonBookingEntities> getBookingDetails(string ShipmentId)
        {
            var data = db.tblBookings.Where(m => m.ShipmentId == ShipmentId).FirstOrDefault();
            int Userid = Convert.ToInt32(data.Userid);
            var BookingData = (from tr in db.Trackings
                               join bd in db.tblBookings on tr.BookingId equals bd.ID
                               join cr in db.CargoStatusTypes on tr.CargoStatusTypeId equals cr.Id
                               join da in db.tblDestinations on bd.DestinationId equals da.ID
                               join sa in db.tblSources on bd.SourceId equals sa.ID
                               join ur in db.UserRegistrations on bd.Userid equals ur.Id
                               join cd in db.CompanyDetails on ur.Id equals cd.UserId
                               join pd in db.tblPackageDetails on bd.PackageDetailsId equals pd.Id
                               where bd.Userid == Userid && tr.IsDelivered == false && bd.ShipmentId == ShipmentId && tr.IsCurrent == true && bd.IsCurrent == true
                               select new CommonBookingEntities
                               {
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

        public IList<CommonBookingEntities> getBookings()
        {
            var BookingData = (from tr in db.Trackings
                               join bd in db.tblBookings on tr.BookingId equals bd.ID
                               join cr in db.CargoStatusTypes on tr.CargoStatusTypeId equals cr.Id
                               join da in db.tblDestinations on bd.DestinationId equals da.ID
                               join sa in db.tblSources on bd.SourceId equals sa.ID
                               join ur in db.UserRegistrations on bd.Userid equals ur.Id
                               join pd in db.tblPackageDetails on bd.PackageDetailsId equals pd.Id
                               where tr.IsDelivered == false && tr.IsCurrent == true && bd.IsCurrent == true
                               select new CommonBookingEntities
                               {
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
                                   isActive = bd.IsActive,
                                   isPickup = bd.IsPickUp,
                                   isDelivered = bd.IsDelivered
                               }).ToList();
            return BookingData;
        }

        public IList<CommonCustomerEntities> getCostomers(int OfficeId)
        {
            var Data = (from ur in db.UserRegistrations
                        join cd in db.CompanyDetails on ur.Id equals cd.UserId
                        where ur.IsVerify == false && ur.OfficeId == OfficeId
                        
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
                            IsVerify= ur.IsVerify,
                          
                            PinCode = ur.PinCode,
                            UpdatedDate = ur.UpdatedDate,
                            Username = ur.Username,
                            UserTypeId = ur.UserTypeId,
                            WebSiteLink = cd.WebSiteLink
                        }).ToList();

            return Data;
        }

        public IList<CommonCustomerEntities> getCustomer()
        {
            var Data = (from ur in db.UserRegistrations
                        join cd in db.CompanyDetails on ur.Id equals cd.UserId
                        where ur.UserTypeId == 3
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

        public IList<CommonCustomerEntities> getCustomerAdmin()
        {
            var Data = (from ur in db.UserRegistrations
                        join od in db.Offices on ur.Id equals od.UserId
                        where ur.UserTypeId == 2
                        select new CommonCustomerEntities
                        {
                            Addressline1 = ur.Addressline1,
                            Addressline2 = ur.Addressline2,
                            City = ur.City,
                          
                            ContactNo = ur.ContactNo,
                            Country = ur.Country,
                            CreatedDate = ur.CreatedDate,
                           
                            Email = ur.Email,
                            State = ur.State,
                            Id = ur.Id,
                            IsActive = ur.IsActive,
                            IsVerify = ur.IsVerify,
                            PinCode = ur.PinCode,
                            UpdatedDate = ur.UpdatedDate,
                            Username = ur.Username,
                            UserTypeId = ur.UserTypeId,
                            OfficeLocation = od.BranchLocation,
                            C_City = od.City,
                            C_State = od.State,
                            C_Country = od.Country
                        }).ToList();

            return Data;
        }

        public IList<CommonBookingEntities> getDeliveredShipments()
        {
            var BookingData = (from tr in db.Trackings
                               join bd in db.tblBookings on tr.BookingId equals bd.ID
                               join cr in db.CargoStatusTypes on tr.CargoStatusTypeId equals cr.Id
                               join da in db.tblDestinations on bd.DestinationId equals da.ID
                               join sa in db.tblSources on bd.SourceId equals sa.ID
                               join ur in db.UserRegistrations on bd.Userid equals ur.Id
                               join pd in db.tblPackageDetails on bd.PackageDetailsId equals pd.Id
                               where tr.IsDelivered == true && tr.IsDelivered == true
                               select new CommonBookingEntities
                               {
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
                                   isActive = bd.IsActive,
                                   isPickup = bd.IsPickUp,
                                   isDelivered = bd.IsDelivered,
                                   UpdatedDate = bd.UpdatedDate.ToString()
                               }).ToList();
            return BookingData;
        }

        public IList<GetQuotationEntities> getQuotations()
        {
            var Data = (from qe in db.tblQuotations
                        join pe in db.tblPackageDetails on qe.PackageDeatilsId equals pe.Id
                        join ur in db.UserRegistrations on qe.UserId equals ur.Id
                        where qe.PackageDeatilsId == pe.Id
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
                            IsActive = qe.IsActive,
                            Length = pe.Lenght,
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

        public bool VerifyCustomer(int id)
        {
            UserRegistration ur = db.UserRegistrations.Find(id);
            ur.IsVerify = true;
            ur.UpdatedDate = DateTime.Now;
            return db.SaveChanges() >0;
        }
        
        public bool AddRates(RateData rate)
        {
            db.RateDatas.Add(rate);
            return db.SaveChanges() > 0;
        }

        public bool DeleteRate(int id)
        {
            RateData r = db.RateDatas.Find(id);
            r.IsActive = false;
            return db.SaveChanges() > 0;
        }

        public IQueryable<RateData> GetRate()
        {
            return db.RateDatas.Where(m => m.IsActive == true); ;
        }

        public IQueryable<RateData> GetRateById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
