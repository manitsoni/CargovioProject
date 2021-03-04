using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities.Customer;
namespace Business.Customer.Manager.Interface
{
    public interface IBookingRepository
    {
        int AddPackage(PackageEntities pe);
        int AddSourceAddress();
        int AddDestinationAddress();
        int AddBooking();
        int AddTracking();
    }
}
