using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities.Customer;
using Data.Model;
using BusinessEntities.CustomerAdmin;

namespace Business.Customer.Manager.Interface
{
    public interface IBookingManager
    {
        int AddPackage(PackageEntities pe);
        int AddSourceAddress(SourceAddressEntities se);
        int AddDestinationAddress(DestinationAddressEntities de);
        int AddBooking(BookingEntities be);
        int AddTracking(TrackingEntities te);
        IList<CommonBookingEntities> GetBooking(int id);
        IList<CommonBookingEntities> GetOldBooking(int id);
        IList<CommonBookingEntities> GetBookingDetails(string ShipmentId,int Userid);

        PackageEntities GetPackageById(int packageId);
        bool UpdatePackage(PackageEntities pe);
        IList<OfficeList> GetMyoffice(int Userid);
        double getRate(string City1, string City2);
    }
}
