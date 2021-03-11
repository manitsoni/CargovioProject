using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Model;
using Data.Customer.Repository.Interface;
using Common;
using BusinessEntities.Customer;
namespace Data.Customer.Repository
{
    public class BookingRepository : IBookingRepository
    {
        private CargovioDbEntities db = new CargovioDbEntities();

        public int AddBooking(tblBooking objBooking)
        {
            db.tblBookings.Add(objBooking);
            db.SaveChanges();
            return (objBooking.ID);
        }

        public int AddDestinationAddress(tblDestination objDAddress)
        {
            db.tblDestinations.Add(objDAddress);
            db.SaveChanges();
            return (objDAddress.ID);
        }

        public int AddPackage(tblPackageDetail objPackage)
        {
            db.tblPackageDetails.Add(objPackage);
            db.SaveChanges();
            return (objPackage.Id);
        }

        public int AddSourceAddress(tblSource objSAddress)
        {
            db.tblSources.Add(objSAddress);
            db.SaveChanges();
            return (objSAddress.ID);
        }

        public int AddTracking(Tracking objTracking)
        {
            db.Trackings.Add(objTracking);
            db.SaveChanges();
            return (objTracking.Id);
        }

        public IList<CommonBookingEntities> GetBooking(int _userId)
        {
            var BookingData = (from tr in db.Trackings
                               join bd in db.tblBookings on tr.BookingId equals bd.ID
                               join cr in db.CargoStatusTypes on tr.CargoStatusTypeId equals cr.Id
                               join da in db.tblDestinations on bd.DestinationId equals da.ID
                               join sa in db.tblSources on bd.SourceId equals sa.ID
                               join ur in db.UserRegistrations on bd.Userid equals ur.Id
                               join pd in db.tblPackageDetails on bd.PackageDetailsId equals pd.Id
                               where bd.Userid == _userId && tr.IsDelivered == false
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
                                   CargoStatus = cr.StatusName
                                   
                               }).ToList();
            return BookingData;
        }
        public IList<CommonBookingEntities> GetBookingDetails(string ShipmentId)
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
                               where bd.Userid == Userid && tr.IsDelivered == false && bd.ShipmentId == ShipmentId
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
    }
}
