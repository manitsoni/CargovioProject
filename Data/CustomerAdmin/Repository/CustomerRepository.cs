using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Model;
using Data.CustomerAdmin.Repoitory.Interface;
using Common;
using BusinessEntities.Customer;
namespace Data.CustomerAdmin.Repoitory
{
    public class CustomerRepository : ICustomerRepository
    {
        public IQueryable<UserRegistration> GetAllCustomer(int Officeid)
        {
            throw new NotImplementedException();
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
                               where bd.OfficeId == OfficeId
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

        public IList<CargoStatusType> GetCargoStatus()
        {
            return db.CargoStatusTypes.ToList();
        }

        public IList<Office> GetAllOffice()
        {
            return db.Offices.Where(m => m.IsActive == true).ToList();
        }
            
    }
}
