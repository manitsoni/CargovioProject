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
    }
}
