using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Model;
using System.Net;
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
                               where bd.Userid == _userId && tr.IsDelivered == false && tr.IsCurrent == true && bd.IsCurrent == true
                               select new CommonBookingEntities
                               {
                                   Amount = bd.Amount,
                                   ID = bd.ID,
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
        public IList<CommonBookingEntities> GetBookingDetails(string ShipmentId,int Userid)
        {
            var data = db.tblBookings.Where(m => m.ShipmentId == ShipmentId).FirstOrDefault();
            //int Userid = Convert.ToInt32(data.Userid);
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

        public double getRate(string City1, string City2)
        {
            try
            {
                double lat1, lat2, long1, long2;
                var CityLatLong1 = db.tblLatLongs.Where(m => m.CityName == City1).FirstOrDefault();
                var CityLatLong2 = db.tblLatLongs.Where(m => m.CityName == City2).FirstOrDefault();
                lat1 = Convert.ToDouble(CityLatLong1.LatAddress);
                long1 = Convert.ToDouble(CityLatLong1.LongAddress);
                lat2 = Convert.ToDouble(CityLatLong2.LatAddress);
                long2 = Convert.ToDouble(CityLatLong2.LongAddress);
                double Km = distance(lat1, lat2, long1, long2);
                double rate = Km * 25;
                double value = rate;
                int factor = 100;
                int nearestMultiple = (int)Math.Round((value / (double)factor), MidpointRounding.AwayFromZero) * factor;
                return nearestMultiple;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        static double toRadians(double angleIn10thofaDegree)
        {
            return (angleIn10thofaDegree *
                        Math.PI) / 180;
        }
        static double distance(double lat1, double lat2, double lon1, double lon2)
        {
            lon1 = toRadians(lon1);
            lon2 = toRadians(lon2);
            lat1 = toRadians(lat1);
            lat2 = toRadians(lat2);
            double dlon = lon2 - lon1;
            double dlat = lat2 - lat1;
            double a = Math.Pow(Math.Sin(dlat / 2), 2) +
                    Math.Cos(lat1) * Math.Cos(lat2) *
                    Math.Pow(Math.Sin(dlon / 2), 2);

            double c = 2 * Math.Asin(Math.Sqrt(a));

            // Radius of earth in
            // kilometers. Use 3956
            // for miles
            double r = 6371;

            // calculate the result
            return (c * r);
        }

        public IQueryable<Office> GetMyOffice(int Userid)
        {
            try
            {
                var data = db.UserRegistrations.Where(m => m.Id == Userid).FirstOrDefault();
                int oid = Convert.ToInt32(data.OfficeId);
                return (db.Offices.Where(m => m.Id == oid));
            }
            catch (Exception ex) 
            {
                throw;
            }
        }

        public IList<CommonBookingEntities> GetOldBooking(int id)
        {
            var BookingData = (from tr in db.Trackings
                               join bd in db.tblBookings on tr.BookingId equals bd.ID
                               join cr in db.CargoStatusTypes on tr.CargoStatusTypeId equals cr.Id
                               join da in db.tblDestinations on bd.DestinationId equals da.ID
                               join sa in db.tblSources on bd.SourceId equals sa.ID
                               join ur in db.UserRegistrations on bd.Userid equals ur.Id
                               join pd in db.tblPackageDetails on bd.PackageDetailsId equals pd.Id
                               where bd.Userid == id && tr.IsDelivered == true && tr.IsDelivered == true
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
                                   UpdatedDate = bd.UpdatedDate.ToString()

                               }).ToList();
            return BookingData;
        }
        public tblPackageDetail GetPackageById(int packageId)
        {
            tblPackageDetail pd = db.tblPackageDetails.Find(packageId);
            return pd;
        }
        public bool UpdatePackage(tblPackageDetail pd)
        {
            db.Entry(pd).State = System.Data.Entity.EntityState.Modified;
            return db.SaveChanges() > 0;
        }
    }
}
